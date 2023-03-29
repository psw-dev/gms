using System.Text.Json;
using PSW.GMS.Common.Constants;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO.SendInboxMessage;
using PSW.RabbitMq;
using PSW.RabbitMq.ServiceCommand;
using PSW.RabbitMq.Task;
using PSW.GMS.Service.DTO;
using PSW.Lib.Logs;
using System;
using System.IO;
using System.Drawing;
using IronPdf;
using IronBarCode;
using PSW.GMS.Common.Enums;

namespace PSW.GMS.Service.Helpers
{
    public static class PrintHelper
    {
        /// <summary>
        /// GetPDF : returns memory stream after converting html to pdf
        /// </summary>
        /// <param name="contents">contents</param>
        /// <param name="header">header</param>
        /// <param name="footer">footer</param>
        /// <param name="documentClassificationCode">documentClassificationCode</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream GetPDF(string contents, string header, string footer, string documentClassificationCode)
        {
            try
            {
                // IronPdf.Installation.DefaultRenderingEngine = IronPdf.Rendering.PdfRenderingEngine.Chrome;
                // Renderer configurations
                var Renderer = new IronPdf.ChromePdfRenderer();
                var defautTopMargin = 60;
                Renderer.RenderingOptions.InputEncoding = System.Text.Encoding.UTF8;
                Renderer.RenderingOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.A4;
                Renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print;

                switch (documentClassificationCode)
                {
                    case DocumentClassificationCode.CATCH_CERTIFICATE:
                    case DocumentClassificationCode.CATCH_CERTIFICATE_REQUEST:
                        {
                            defautTopMargin = 45;
                            break;
                        }
                    case DocumentClassificationCode.HEALTH_CERTIFICATE:
                        {
                            defautTopMargin = 45;
                            break;
                        }
                }

                // if (documentClassificationCode == DocumentClassificationCode.IMPORT_PERMIT)
                // {
                //     Renderer.RenderingOptions.MarginTop = 60;
                // }
                // else if (documentClassificationCode == DocumentClassificationCode.EXPORT_CERTIFICATE)
                // {
                //     Renderer.RenderingOptions.MarginTop = 0;
                // }
                // else if (documentClassificationCode == DocumentClassificationCode.RELEASE_ORDER)
                // {
                //     Renderer.RenderingOptions.MarginTop = 0;
                // }
                Renderer.RenderingOptions.MarginTop = (header != null && header?.Length != 0) ? defautTopMargin : 0;
                Renderer.RenderingOptions.MarginBottom = 15;
                Renderer.RenderingOptions.MarginLeft = 5;
                Renderer.RenderingOptions.MarginRight = 5;

                // Header Placement
                if (header != null)
                {
                    Renderer.RenderingOptions.HtmlHeader = new HtmlHeaderFooter()
                    {
                        MaxHeight = 200, //millimeters
                        HtmlFragment = header,
                    };
                }

                // Build a footer using html to style the text
                if (footer != null)
                {
                    Renderer.RenderingOptions.HtmlFooter = new HtmlHeaderFooter()
                    {
                        MaxHeight = 20, //millimeters
                        HtmlFragment = footer,
                        DrawDividerLine = false,
                    };
                }

                var pdfDocument = Renderer.RenderHtmlAsPdf(contents);
                pdfDocument.SecuritySettings.AllowUserCopyPasteContent = false;

                return pdfDocument.Stream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// BitmapToBytesCode : Gets QR Code and return Byte array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Byte[] BitmapToBytesCode(string input)
        {
            try
            {
                Bitmap bmp = GenearteQRCode(input);

                using (MemoryStream stream = new MemoryStream())
                {
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetLogo: Read Logo png and converts to Base64 string
        /// </summary>
        /// <param name="agencyID">int agencyID</param>
        /// <returns>base64String</returns>
        public static string GetLogo(int agencyID)
        {
            var pth = string.Empty;
            switch (agencyID)
            {
                // case AgencyEnum.PSQCA:
                //     pth = "Assets/logo-psqca.png";
                //     break;
                // case AgencyEnum.DPP:
                //     pth = "Assets/logo-dpp.png";
                //     break;
                default:
                    pth = "Assets/logo-pk.png";
                    break;
            }
            using (Image image = Image.FromFile(pth))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        /// <summary>
        /// GenearteQRCode: Generates QR Code and return bitmap
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Bitmap GenearteQRCode(string input)
        {
            try
            {
                var barCode = IronBarCode.BarcodeWriter.CreateBarcode(input, BarcodeWriterEncoding.QRCode);

                //MyBarCode.AddAnnotationTextAboveBarcode("Product URL:");
                //MyBarCode.AddBarcodeValueTextBelowBarcode();
                barCode.ResizeTo(300, 300).SetMargins(2);
                barCode.ChangeBarCodeColor(Color.Black);

                Bitmap bitmap = barCode.ToBitmap();
                return bitmap;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetHost : return QRcode base url
        /// </summary>
        /// <returns>string</returns>
        public static string GetHost()
        {
            var host = Environment.GetEnvironmentVariable("PSW_APP_URL");
            return host;
        }
    }
}