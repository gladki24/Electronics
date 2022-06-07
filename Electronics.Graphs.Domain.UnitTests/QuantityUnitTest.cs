using Electronics.Graphs.Domain.Quantity;
using NUnit.Framework;

namespace Electronics.Graphs.Domain.UnitTests
{
    public class QuantityUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_QuantityHasValueAndUnit()
        {
            Quantity.Quantity quantity = new(QuantityUnit.Volt, 5);
            Assert.AreEqual(quantity.Unit, QuantityUnit.Volt);
            Assert.AreEqual(quantity.Value, 5);
        }

        [Test]
        [TestCase(12, 54)]
        [TestCase(-5, 5)]
        [TestCase(87, -90)]
        [TestCase(-100, 120)]
        public void Should_ReturnValidValue_OfQuantityAddition(decimal quantityAValue, decimal quantityBValue)
        {
            Quantity.Quantity quantityA = new(QuantityUnit.Volt, quantityAValue);
            Quantity.Quantity quantityB = new (QuantityUnit.Volt, quantityBValue);

            Quantity.Quantity expectedResult = new(QuantityUnit.Volt, quantityAValue + quantityBValue);

            Assert.AreEqual(expectedResult, quantityA + quantityB);
        }

        [Test]
        [TestCase(12, 54)]
        [TestCase(-5, 5)]
        [TestCase(87, -90)]
        [TestCase(-100, 120)]
        public void Should_ReturnValidValue_OfQuantitySubtract(decimal quantityAValue, decimal quantityBValue)
        {
            Quantity.Quantity quantityA = new(QuantityUnit.Volt, quantityAValue);
            Quantity.Quantity quantityB = new(QuantityUnit.Volt, quantityBValue);

            Quantity.Quantity expectedResult = new(QuantityUnit.Volt, quantityAValue - quantityBValue);

            Assert.AreEqual(expectedResult, quantityA - quantityB);
        }

        [Test]
        [TestCase(12, 2)]
        [TestCase(-5, 5)]
        [TestCase(87, -9)]
        [TestCase(-100, 1)]
        public void Should_ReturnValidValue_OfQuantityMultiply(decimal quantityValue, decimal factory)
        {
            Quantity.Quantity quantity = new Quantity.Quantity(QuantityUnit.Ohm, quantityValue);

            Quantity.Quantity expectedResult = new(QuantityUnit.Ohm, quantityValue * factory);

            Assert.AreEqual(expectedResult, quantity * factory);
        }

        [Test]
        [TestCase(12, 2)]
        [TestCase(-5, 5)]
        [TestCase(87, -9)]
        [TestCase(-100, 1)]
        public void Should_ReturnValidValue_OfQuantityDivide(decimal quantityValue, decimal factory)
        {
            Quantity.Quantity quantity = new Quantity.Quantity(QuantityUnit.Ohm, quantityValue);

            Quantity.Quantity expectedResult = new(QuantityUnit.Ohm, quantityValue / factory);

            Assert.AreEqual(expectedResult, quantity / factory);
        }
    }
}