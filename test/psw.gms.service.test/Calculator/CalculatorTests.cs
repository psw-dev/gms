using Xunit;
using Calc = PSW.GMS.Service.Calculator.Calculator;

namespace PSW.GMS.Service.Test.Calculator
{
    public class CalculatorTests
    {
        private Calc calculator { get; }

        //This Constructor is called before tests
        public CalculatorTests()
        {
            calculator = new Calc();
        }

        [Fact]
        public void If_Int_Add_Is_Working()
        {
            // Arrange
            int a = 50, b = 50;

            // Act
            var result = calculator.add(a, b);

            // Assert
            Assert.Equal(result, 100);
        }

        [Fact]
        public void If_Int_Subtract_Is_Working()
        {
            // Arrange
            int a = 51, b = 49;

            // Act
            var result = calculator.subtract(a, b);

            // Assert
            Assert.Equal(result, 2);
        }

        [Fact]
        public void If_Int_Multiply_Is_Working()
        {
            // Arrange
            int a = 51, b = 49;

            // Act
            var result = calculator.multiply(a, b);

            // Assert
            Assert.Equal(result, 2499);
        }

        [Fact]
        public void If_Int_Divide_Is_Working()
        {
            // Arrange
            int a = 100, b = 50;

            // Act
            var result = calculator.divide(a, b);

            // Assert
            Assert.Equal(result, 2);
        }

        [Fact]
        public void If_Double_Add_Is_Working()
        {
            // Arrange
            double a = 55.4, b = 50.5;

            // Act
            var result = calculator.add(a, b);

            // Assert
            Assert.Equal(result, 105.9);
        }

        [Fact]
        public void If_Double_Subtract_Is_Working()
        {
            // Arrange
            double a = 51.85, b = 49.35;

            // Act
            var result = calculator.subtract(a, b);

            // Assert
            Assert.Equal(result, 2.5);
        }

        [Fact]
        public void If_Double_Multiply_Is_Working()
        {
            // Arrange
            double a = 50.5, b = 55.8;

            // Act
            var result = calculator.multiply(a, b);

            // Assert
            Assert.Equal(result, 2817.9);
        }

        [Fact]
        public void If_Double_Divide_Is_Working()
        {
            // Arrange
            double a = 27.5, b = 5;

            // Act
            var result = calculator.divide(a, b);

            // Assert
            Assert.Equal(result, 5.5);
        }
    }
}