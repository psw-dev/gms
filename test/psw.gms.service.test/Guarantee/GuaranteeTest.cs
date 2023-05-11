using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using PSW.GMS.Data;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;
using PSW.GMS.Service.BusinessLogicLayer;
using PSW.GMS.Service.DTO;

namespace PSW.GMS.Service.Tests
{
    public class GuaranteeTest
    {
        private Mock<IGuaranteeRepository> _guaranteeRepository;
        private GuaranteeBLL _guaranteeBLL;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GuaranteeTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedGuaranteeList = new List<Guarantee>();
            _unitOfWork.Setup(a => a.GuaranteeRepository.Where(It.IsAny<Object>()))
            .Returns(expectedGuaranteeList);
            var expectedGuaranteeHistory = new List<GuaranteeTransactionHistory>();
            _unitOfWork.Setup(a => a.GuaranteeTransactionHistoryRepository.Where(It.IsAny<Object>()))
            .Returns(expectedGuaranteeHistory);
            _guaranteeBLL = new GuaranteeBLL(_unitOfWork.Object);
        }

        [Fact]
        public void Create_Guarantee_With_Valid_Data_For_TR_Should_Return_Success()
        {
            // Arrange
            var guarantee = new Guarantee
            {
                ID = 1,
                GuaranteeTypeID = 1,
                TraderNTN = "ABC261587",
                TraderRoleID = 3,
                TraderSubscriptionID = 4,
                GuaranteeNumber = "1234",
                TotalAmount = 1000.00M,
                CurrencyCode = "PKR",
                IssueDate = new DateTime(2021, 01, 01),
                ExpiryDate = new DateTime(2024, 01, 01),
                BankCode = "123",
                BalanceAmount = 500.00M,
                ReferenceNumber = "123",
                GuaranteeStatusID = 1,
                SoftDelete = false,
                CreatedOn = new DateTime(2021, 01, 01),
                CreatedBy = 1,
                UpdatedOn = new DateTime(2021, 01, 01),
                UpdatedBy = 1
            };

            // Act  
            var result = _guaranteeBLL.Create(ref guarantee, out var responseMessage);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Create_Guarantee_With_Valid_Data_For_CA_Should_Return_Success()
        {
            // Arrange
            var guarantee = new Guarantee
            {
                ID = 1,
                GuaranteeTypeID = 1,
                TraderNTN = "ABC261587",
                TraderSubscriptionID = 4,
                AgentSubscriptionID = 5,
                AgentNTN = "1234567-8",
                AgentRoleID = 6,
                AgentParentCollectorateCode = "KCUS",
                GuaranteeNumber = "1234",
                TotalAmount = 1000.00M,
                CurrencyCode = "PKR",
                IssueDate = new DateTime(2021, 01, 01),
                ExpiryDate = new DateTime(2024, 01, 01),
                BankCode = "123",
                BalanceAmount = 500.00M,
                ReferenceNumber = "123",
                GuaranteeStatusID = 1,
                SoftDelete = false,
                CreatedOn = new DateTime(2021, 01, 01),
                CreatedBy = 1,
                UpdatedOn = new DateTime(2021, 01, 01),
                UpdatedBy = 1
            };

            // Act  
            var result = _guaranteeBLL.Create(ref guarantee, out var responseMessage);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Get_Guarantee_List_With_Valid_Data_For_TR_Should_Return_Success()
        {
            // Arrange
            var getGuaranteeRequestDTO = new GetGuaranteeRequestDTO
            {
                RoleCode = "TR",
                TraderNTN = "ABC261587"
            };
            int subscriptionID = 70, userRoleId = 110, parentRoleID = 0, loggedInUserRoleId = 0;
            string parentCollectorateCode = "";

            // Act
            var result = _guaranteeBLL.Get(getGuaranteeRequestDTO, subscriptionID, userRoleId, parentRoleID
            , loggedInUserRoleId, parentCollectorateCode, out var guaranteeList, out var responseMessage);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Get_Guarantee_List_Without_TraderNTN_For_TR_Should_Return_Failure()
        {
            // Arrange
            var getGuaranteeRequestDTO = new GetGuaranteeRequestDTO
            {
                RoleCode = "TR"
            };
            int subscriptionID = 70, userRoleId = 110, parentRoleID = 0, loggedInUserRoleId = 0;
            string parentCollectorateCode = "";

            // Act
            var result = _guaranteeBLL.Get(getGuaranteeRequestDTO, subscriptionID, userRoleId, parentRoleID
            , loggedInUserRoleId, parentCollectorateCode, out var guaranteeList, out var responseMessage);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Get_Guarantee_List_With_Valid_Data_For_CA_Should_Return_Success()
        {
            // Arrange
            var getGuaranteeRequestDTO = new GetGuaranteeRequestDTO
            {
                RoleCode = "CA",
                AgentParentCollectorateCode = "KCUS"
            };
            int subscriptionID = 70, userRoleId = 110, parentRoleID = 0, loggedInUserRoleId = 0;
            string parentCollectorateCode = "KCUS";

            // Act
            var result = _guaranteeBLL.Get(getGuaranteeRequestDTO, subscriptionID, userRoleId, parentRoleID
            , loggedInUserRoleId, parentCollectorateCode, out var guaranteeList, out var responseMessage);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Get_Guarantee_List_Without_AgentParentCollectorateCode_For_CA_Should_Return_Failure()
        {
            // Arrange
            var getGuaranteeRequestDTO = new GetGuaranteeRequestDTO
            {
                RoleCode = "CA"
            };
            int subscriptionID = 70, userRoleId = 110, parentRoleID = 0, loggedInUserRoleId = 0;
            string parentCollectorateCode = "KCUS";

            // Act
            var result = _guaranteeBLL.Get(getGuaranteeRequestDTO, subscriptionID, userRoleId, parentRoleID
            , loggedInUserRoleId, parentCollectorateCode, out var guaranteeList, out var responseMessage);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Get_Guarantee_Details_With_Valid_Data_For_TR_Should_Return_Success()
        {
            // Arrange
            var getGuaranteeRequestDTO = new GetGuaranteeRequestDTO
            {
                ID = 10,
                RoleCode = "TR",
                TraderNTN = "ABC261587"
            };
            int subscriptionID = 70, userRoleId = 110, parentRoleID = 0, loggedInUserRoleId = 0;
            string parentCollectorateCode = "KCUS";

            // Act
            var result = _guaranteeBLL.Get(getGuaranteeRequestDTO, subscriptionID, userRoleId, parentRoleID
            , loggedInUserRoleId, parentCollectorateCode, out var guaranteeList, out var responseMessage);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Get_Guarantee_Details_Without_TraderNTN_For_TR_Should_Return_Failure()
        {
            // Arrange
            var getGuaranteeRequestDTO = new GetGuaranteeRequestDTO
            {
                ID = 10,
                RoleCode = "TR"
            };
            int subscriptionID = 70, userRoleId = 110, parentRoleID = 0, loggedInUserRoleId = 0;
            string parentCollectorateCode = "KCUS";

            // Act
            var result = _guaranteeBLL.Get(getGuaranteeRequestDTO, subscriptionID, userRoleId, parentRoleID
            , loggedInUserRoleId, parentCollectorateCode, out var guaranteeList, out var responseMessage);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Get_Guarantee_Details_With_Valid_Data_For_CA_Should_Return_Success()
        {
            // Arrange
            var getGuaranteeRequestDTO = new GetGuaranteeRequestDTO
            {
                ID = 10,
                RoleCode = "CA",
                AgentParentCollectorateCode = "KCUS"
            };
            int subscriptionID = 70, userRoleId = 110, parentRoleID = 0, loggedInUserRoleId = 0;
            string parentCollectorateCode = "KCUS";

            // Act
            var result = _guaranteeBLL.Get(getGuaranteeRequestDTO, subscriptionID, userRoleId, parentRoleID
            , loggedInUserRoleId, parentCollectorateCode, out var guaranteeList, out var responseMessage);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Get_Guarantee_Details_Without_AgentParentCollectorateCode_For_CA_Should_Return_Failure()
        {
            // Arrange
            var getGuaranteeRequestDTO = new GetGuaranteeRequestDTO
            {
                ID = 10,
                RoleCode = "CA"
            };
            int subscriptionID = 70, userRoleId = 110, parentRoleID = 0, loggedInUserRoleId = 0;
            string parentCollectorateCode = "KCUS";

            // Act
            var result = _guaranteeBLL.Get(getGuaranteeRequestDTO, subscriptionID, userRoleId, parentRoleID
            , loggedInUserRoleId, parentCollectorateCode, out var guaranteeList, out var responseMessage);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Update_Guarantee_Transaction_With_Valid_Data_Should_Return_Success()
        {
            // Arrange
            var guaranteeTransactionHistory = new GuaranteeTransactionHistory
            {
                GuaranteeID = 1,
                AttachedToDocumentID = 516032,
                AttachedToDocumentNumber = "XYZ7889",
                AttachedToDocumentTypeCode = "CW",
                ConsumedAmount = 500.00M,
                GuaranteeTransactionStatusID = 1,
                ApprovedOn = new DateTime(2021, 01, 01),
                SoftDelete = false,
                CreatedOn = new DateTime(2021, 01, 01),
                CreatedBy = 1,
                UpdatedOn = new DateTime(2021, 01, 01),
                UpdatedBy = 1
            };

            // Act  
            var result = _guaranteeBLL.UpdateGuaranteeTransaction(10, ref guaranteeTransactionHistory
            , out var responseMessage);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Get_Guarantee_History_With_Valid_Data_Should_Return_Success()
        {
            // Arrange
            var guaranteeID = 10;

            // Act
            var result = _guaranteeBLL.GetGuaranteeHistory(guaranteeID
            , out var guaranteeList, out var responseMessage);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
