using System;
using PSW.GMS.Data;
using PSW.GMS.Data.Sql;
using PSW.GMS.Service.BusinessLogicLayer;
using PSW.GMS.Data.Repositories;
using PSW.GMS.Data.Entities;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace PSW.GMS.Service.Tests
{
    public class GuaranteeTest
    {
        private Mock<IGuaranteeRepository> _guaranteeRepository;
        // private Mock<SecureStrategyFactory> _guaranteeFactoryMock;
        // private Mock<SaveGuaranteeDocumentStrategy> _guaranteeStrategyMock;
        // private GuaranteeController _guaranteeController;
        private GuaranteeBLL _guaranteeBLL;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GuaranteeTest()
        {
            // _guaranteeRepository = new Mock<IGuaranteeRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            // _guaranteeController = new GuaranteeController(
            //     _guaranteeRepositoryMock.Object,
            //     _guaranteeFactoryMock.Object,
            //     _guaranteeStrategyMock.Object);
            var expectedGuaranteeList = new List<Guarantee>();
            _unitOfWork.Setup(a => a.GuaranteeRepository.Where(It.IsAny<Object>()))
            .Returns(expectedGuaranteeList);
            _guaranteeBLL = new GuaranteeBLL(_unitOfWork.Object);
        }

        [Fact]
        public void Insert_Guarantee_With_Valid_Data_Should_Return_Success()
        {
            // Arrange
            var guarantee = new Guarantee
            {
                ID = 1,
                GuaranteeTypeID = 1,
                TraderNTN = "1234567-8",
                TraderRoleID = 3,
                TraderSubscriptionID = 4,
                AgentSubscriptionID = 5,
                AgentNTN = "1234567-8",
                AgentRoleID = 6,
                AgentParentCollectorateCode = "123",
                GuaranteeNumber = "1234",
                TotalAmount = 1000.00M,
                CurrencyCode = "PKR",
                IssueDate = new DateTime(2021, 01, 01),
                ExpiryDate = new DateTime(2024, 01, 01),
                BankCode = "123",
                // BalanceAmount = 500.00M,
                // ReferenceNumber = "123",
                // GuaranteeStatusID = 1,
                // SoftDelete = false,
                CreatedOn = new DateTime(2021, 01, 01),
                CreatedBy = 1,
                UpdatedOn = new DateTime(2021, 01, 01),
                UpdatedBy = 1
            };
            
            // Act  
            var result = _guaranteeBLL.Create("TR", ref guarantee, out var responseMessage);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Insert_Guarantee_With_Invalid_Data_Should_Return_Failure()
        {
            // Arrange
            var guarantee = new Guarantee
            {
                ID = 1,
                GuaranteeTypeID = 2,
                TraderNTN = "", // invalid value for this property
                TraderRoleID = 3,
                // TraderSubscriptionID = 4,
                AgentSubscriptionID = 5,
                AgentNTN = "1234567-8",
                AgentRoleID = 6,
                AgentParentCollectorateCode = "123",
                GuaranteeNumber = "5678",
                TotalAmount = 1000.00M,
                CurrencyCode = "PKR",
                IssueDate = new DateTime(2021, 01, 01),
                ExpiryDate = new DateTime(2024, 01, 01),
                BankCode = "123",
                // BalanceAmount = 500.00M,
                // ReferenceNumber = "123",
                // GuaranteeStatusID = 1,
                // SoftDelete = false,
                CreatedOn = new DateTime(2021, 01, 01),
                CreatedBy = 1,
                UpdatedOn = new DateTime(2021, 01, 01),
                UpdatedBy = 1
            };

            // Act
            var result = _guaranteeBLL.Create("CA", ref guarantee, out var responseMessage);

            // Assert
            Assert.Equal(-1, result);
        }
    }
}
