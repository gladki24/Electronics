using Electronics.Graphs.Domain.Quantity;
using NUnit.Framework;

namespace Electronics.Graphs.Domain.UnitTests;

public class QuantityUnitTest
{
    [Test]
    public void Should_Has_QuantityUnitName()
    {
        QuantityUnit unit = QuantityUnit.Ampere;
        Assert.AreEqual("A", unit.QuantityUnitName);
    }

    [Test]
    public void Should_Be_TwoQuantitiesWithSameName()
    {
        QuantityUnit unitA = QuantityUnit.Ampere;
        QuantityUnit unitB = QuantityUnit.Ampere;
        
        Assert.AreEqual(unitA, unitB);
    }

    [Test]
    public void Should_Be_DifferentTwoQuantitiesWithDifferentName()
    {
        QuantityUnit unitA = QuantityUnit.Ampere;
        QuantityUnit unitB = QuantityUnit.Ohm;
        
        Assert.AreNotEqual(unitA, unitB);
    }

    [Test]
    public void Should_ReturnTrue_IfCompatible()
    {
        QuantityUnit unitA = QuantityUnit.Ampere;
        QuantityUnit unitB = QuantityUnit.Ampere;

        Assert.True(unitA.CheckCompatibility(unitB));
    }
    
    [Test]
    public void Should_ReturnSameUnitAsPassed_IfUnitsWereAdded()
    {
        QuantityUnit unitA = QuantityUnit.Volt;
        QuantityUnit unitB = QuantityUnit.Volt;

        QuantityUnit expectedUnit = QuantityUnit.Volt;

        Assert.AreEqual(expectedUnit, unitA + unitB);
    }

    [Test]
    public void Should_ReturnSameUnitAsPassed_IfUnitsWereSubtracted()
    {
        QuantityUnit unitA = QuantityUnit.Ampere;
        QuantityUnit unitB = QuantityUnit.Ampere;
        
        QuantityUnit expectedUnit = QuantityUnit.Ampere;

        Assert.AreEqual(expectedUnit, unitB - unitA);
    }

    [Test]
    public void Should_Throw_IfUnitsAreNotCompatible()
    {
        QuantityUnit unitA = QuantityUnit.Ampere;
        QuantityUnit unitB = QuantityUnit.Volt;

        Assert.Throws<QuantityNotSameUnitsException>(() =>
        {
            var result = unitA + unitB;
        });
    }
}