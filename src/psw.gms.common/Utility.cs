using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using PSW.Common.Crypto;

namespace PSW.GMS.Common
{
    public class Utility
    {
        private const string AesIV256 = @"!QAZ2WSX#EDC4RFV";
        private const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";

        /// <summary>
        /// Gets SHA256 Hash of incoming string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String GetSHA256(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        /// <summary>
        /// Checks if incoming type inherits from Generic Type 
        /// </summary>
        /// <param name="givenType"></param>
        /// <param name="genericType"></param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            Type baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }


        /// <summary>
        /// Masks incoming CNICs
        /// </summary>
        /// <param name="CNICs"></param>
        /// <returns>List<string> list of modified CNICs (masked)</returns>
        public static List<string> maskCNIC(List<string> CNICs)
        {
            List<string> maskedCNIC = new List<string>();

            foreach (string cnic in CNICs)
            {
                string sub1 = cnic.Substring(0, 5);
                string sub2 = cnic.Substring(9, 4);
                string masked = sub1 + "****" + sub2;
                maskedCNIC.Add(masked);
            }
            return maskedCNIC;
        }

        public static List<string> maskCNIC(List<string> CNICs, bool removeDash)
        {

            List<string> maskedCNIC = new List<string>();

            // If Present Remove Dashs
            if (removeDash)
                CNICs.ForEach(x => x.Replace("-", ""));

            foreach (string cnic in CNICs)
            {
                string sub1 = cnic.Substring(0, 5);
                string sub2 = cnic.Substring(12, 1);
                string masked = sub1 + "XXXXXXX" + sub2;
                maskedCNIC.Add(masked);
            }

            return maskedCNIC;
        }

        /// <summary>
        /// Encrypts the string using AES256
        /// </summary>
        /// <param name="input"></param>
        /// <returns>AES256 encrypted data</returns>
        public static string AESEncrypt256(string input)
        {
            byte[] encrypted;
            byte[] IV;
            byte[] Salt = GetSalt();
            byte[] Key = CreateKey(AesKey256, Salt);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Mode = CipherMode.CBC;

                aesAlg.GenerateIV();
                IV = aesAlg.IV;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(input);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            byte[] combinedIvSaltCt = new byte[Salt.Length + IV.Length + encrypted.Length];
            Array.Copy(Salt, 0, combinedIvSaltCt, 0, Salt.Length);
            Array.Copy(IV, 0, combinedIvSaltCt, Salt.Length, IV.Length);
            Array.Copy(encrypted, 0, combinedIvSaltCt, Salt.Length + IV.Length, encrypted.Length);

            return Convert.ToBase64String(combinedIvSaltCt.ToArray());
        }
        /// <summary>
        /// Decrypts data using AES256
        /// </summary>
        /// <param name="input"></param>
        /// <returns>AES256 decrypted data</returns>
        public static string AESDecrypt256(string input)
        {
            byte[] inputAsByteArray;
            string plaintext = null;
            try
            {
                inputAsByteArray = Convert.FromBase64String(input);

                byte[] Salt = new byte[32];
                byte[] IV = new byte[16];
                byte[] Encoded = new byte[inputAsByteArray.Length - Salt.Length - IV.Length];

                Array.Copy(inputAsByteArray, 0, Salt, 0, Salt.Length);
                Array.Copy(inputAsByteArray, Salt.Length, IV, 0, IV.Length);
                Array.Copy(inputAsByteArray, Salt.Length + IV.Length, Encoded, 0, Encoded.Length);

                byte[] Key = CreateKey(AesKey256, Salt);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (var msDecrypt = new MemoryStream(Encoded))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                return plaintext;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Create key
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns>Key</returns>
        public static byte[] CreateKey(string password, byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt))
                return rfc2898DeriveBytes.GetBytes(32);
        }

        /// <summary>
        /// Return random salt
        /// </summary>
        /// <returns>salt</returns>
        private static byte[] GetSalt()
        {
            var salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        ///     Checks if requested user role found in list of roles in claims
        ///     if found then returns entity having role code and role id otherwise returns null
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="roleCode"></param>
        /// <returns>UserRoleDTO</returns>
        public static UserRoleDTO GetCurrentUserRole(IEnumerable<Claim> claims, string roleCode)
        {
            var userRoles = claims.Where(x => x.Type == "role").ToList();
            var userRoleEntities = new List<UserRoleDTO>();

            foreach (var userRole in userRoles)
            {
                var userRolesDto = System.Text.Json.JsonSerializer.Deserialize<List<UserRoleDTO>>(userRole.Value);
                userRoleEntities.AddRange(userRolesDto);
            }

            return userRoleEntities.FirstOrDefault(x => x.RoleCode == roleCode);
        }

        /// <summary>
        ///     Certificate number generator
        /// </summary>
        /// <param name="documentPrefix"></param>
        /// <returns>string</returns>
        public static string GenerateCertificateNumber(string documentPrefix)
        {
            return $"{documentPrefix}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}/{DateTime.Now.Year}";
        }

        /// <summary>
        ///     Certificate number generator
        /// </summary>
        /// <param name="documentPrefix"></param>
        /// <returns>string</returns>
        public static string GenerateCertificateNumberWithDocumentType(string documentClassificationCode, string documentTypeCode)
        {
            return $"{documentClassificationCode}-{documentTypeCode}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";
        }
        /// <summary>
        ///     Certificate number generator
        /// </summary>
        /// <param name="documentPrefix"></param>
        /// <param name="cityCode"></param>
        /// <returns>string</returns>
        public static string GenerateCertificateNumber(string documentPrefix, string cityCode = "")
        {
            if (string.IsNullOrEmpty(cityCode))
            {
                return $"{documentPrefix}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}/{DateTime.Now.Year}";
            }
            return $"{documentPrefix}-{cityCode}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}/{DateTime.Now.Year}";
        }

        public static string GetDateFormat()
        {
            return "yyyyMMdd";
        }

        public static int GenerateRandomNo()
        {
            int _min = 000001;
            int _max = 999999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public static string GenerateExceptionUniqueCode()
        {
            long uniqueNumber = (DateTime.Now.Ticks / 10) % 1000000000;
            return ("Error Code: " + uniqueNumber.ToString());
        }
        public static long GenerateExceptionUniqueNo()
        {
            return (DateTime.Now.Ticks / 10) % 1000000000;
        }
        public static string Generate7DigitUniqueNo()
        {
            return System.DateTime.Now.TimeOfDay.ToString("hhmmssf");
        }

        public static string DecryptConnectionString(string ConnectionStrings__ConnectionString)
        {
            string _decryptedConnString = String.Empty;
            try
            {
                string salt = Environment.GetEnvironmentVariable("ENCRYPTION_SALT");
                string password = Environment.GetEnvironmentVariable("ENCRYPTION_PASSWORD");
                string connection = ConnectionStrings__ConnectionString;
                if (string.IsNullOrWhiteSpace(salt) || string.IsNullOrWhiteSpace(password))
                {
                    throw new System.Exception("Please provide salt and password for Crypto Algorithm in Environment Variable");
                }

                var crypto = new CryptoFactory().Create<AesManaged>(password, salt);

                if (string.IsNullOrWhiteSpace(salt) || string.IsNullOrWhiteSpace(password))
                {
                    throw new System.Exception("Please provide salt and password for Crypto Algorithm in Environment Variable");
                }
                if (string.IsNullOrWhiteSpace(connection))
                {
                    throw new System.Exception("Please provide connection string Crypto Algorithm in Environment Variable");
                }
                _decryptedConnString = crypto.Decrypt(connection);
            }
            catch (Exception exp)
            {
                _decryptedConnString = ConnectionStrings__ConnectionString;
            }
            return _decryptedConnString;
        }
    }
}