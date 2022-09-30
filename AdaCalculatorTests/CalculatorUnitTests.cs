using AdaCalculator;
using FluentAssertions;
using Moq;

namespace AdaCalculatorTests
{
    public class CalculatorUnitTests
    {

        private readonly CalculatorMachine _machine;
        private readonly Mock<ICalculator> _mock;

        public CalculatorUnitTests()
        {
            _mock = new Mock<ICalculator>();
            _machine = new CalculatorMachine(_mock.Object);
        }


        [Theory]
        [InlineData("divide", 4, 2)]
        public void Calculate_WhenOperationIsDivide_ShouldReturnTwo(string operation, double a, double b)
        {
            _mock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("divide", 2));
            
            (string operation, double result) actual = _machine.Calculate(operation, a, b);

            _mock.Verify(x => x.Calculate(operation, a, b), Times.Once);

            Assert.Equal("divide", actual.operation);
            Assert.Equal(2, actual.result);

        }


        [Theory]
        [InlineData("divide", -4, 2)]
        public void Calculate_WhenOperationIsDivide_ShouldReturnTwoNegative(string operation, double a, double b)
        {
            _mock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("divide", -2));

            (string operation, double result) actual = _machine.Calculate(operation, a, b);
            
            _mock.Verify(x => x.Calculate(operation, a, b), Times.Once);

            Assert.Equal("divide", actual.operation);
            Assert.Equal(-2, actual.result);
        }

        [Theory]
        [InlineData("multiply", 25, 5)]
        public void Calculate_WhenOperationIsMultiply_ShouldReturnSix(string operation, double a, double b)
        {
            Mock<ICalculator> mock = new Mock<ICalculator>();
            _mock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("multiply", 6));


            (string operation, double result) actual = _machine.Calculate(operation, a, b);

            _mock.Verify(x => x.Calculate(operation, a, b), Times.Once);

            Assert.Equal("multiply", actual.operation);
            Assert.Equal(6, actual.result);
        }

        [Theory]
        [InlineData("subtract", 200, 100)]
        public void Calculate_WhenOperationIsSubtract_ShouldReturnHundred(string operation, double a, double b)
        {
            Mock<ICalculator> mock = new Mock<ICalculator>();
            _mock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("subtract", 100));


            (string operation, double result) actual = _machine.Calculate(operation, a, b);

            _mock.Verify(x => x.Calculate(operation, a, b), Times.Once);


            Assert.Equal("subtract", actual.operation);
            Assert.Equal(100, actual.result);
        }

        [Theory]
        [InlineData("sum", 65, 15)]
        public void Calculate_WhenOperationIsSum_ShouldReturnEighty(string operation, double a, double b)
        {
            Mock<ICalculator> mock = new Mock<ICalculator>();
            _mock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("sum", 80));


            (string operation, double result) actual = _machine.Calculate(operation, a, b);

            _mock.Verify(x => x.Calculate(operation, a, b), Times.Once);

            Assert.Equal("sum", actual.operation);
            Assert.Equal(80, actual.result);
        }


        [Theory]
        [InlineData(" ", 1, 1)]
        public void Calculate_WhenOperationIsNotRecognized_ShouldReturnTwo(string operation, double a, double b)
        {
            Mock<ICalculator> mock = new Mock<ICalculator>();
            _mock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns((" ", 2));

            (string operation, double result) actual = _machine.Calculate(operation, a, b);

            _mock.Verify(x => x.Calculate(operation, a, b), Times.Once);

            Assert.Equal(" ", actual.operation);
            Assert.Equal(2, actual.result);
        }


    }
}