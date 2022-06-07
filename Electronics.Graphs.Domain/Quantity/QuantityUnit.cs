namespace Electronics.Graphs.Domain.Quantity;

/// <summary>
/// Struct to represent abstract quantity unit
/// </summary>
public struct QuantityUnit : IEquatable<QuantityUnit>
{
    /// <summary>
    /// Name of quantity unit
    /// </summary>
    public string QuantityUnitName;

    /// <summary>
    /// Default constructor
    /// </summary>
    public QuantityUnit()
    {
        QuantityUnitName = "Unknown";
    }

    /// <summary>
    /// Private default constructor of quantity unit
    /// </summary>
    /// <param name="quantityUnitName">Name of quantity unit</param>
    private QuantityUnit(string quantityUnitName)
    {
        QuantityUnitName = quantityUnitName;
    }

    /// <summary>
    /// Unit for representing voltage
    /// </summary>
    public static QuantityUnit Volt = new QuantityUnit("V");

    /// <summary>
    /// Unit for representing current
    /// </summary>
    public static QuantityUnit Ampere = new QuantityUnit("A");

    /// <summary>
    /// Unit for representing resistance
    /// </summary>
    public static QuantityUnit Ohm = new QuantityUnit("Ω");

    /// <summary>
    /// Unit for representing unknown unit
    /// </summary>
    public static QuantityUnit Unknown = new QuantityUnit("Unknown");

    /// <summary>
    /// Check two quantity units equality
    /// </summary>
    /// <param name="other">Quantity unit to compare</param>
    /// <returns>Are two quantities equal</returns>
    public bool Equals(QuantityUnit other) =>
        QuantityUnitName == other.QuantityUnitName;

    /// <summary>
    /// Check two quantity units equality
    /// </summary>
    /// <param name="obj">Quantity unit to compare</param>
    /// <returns>Are two quantities equal</returns>
    public override bool Equals(object? obj) =>
        obj is QuantityUnit other && Equals(other);

    /// <summary>
    /// Return hash code of quantity unit name
    /// </summary>
    /// <returns>Hash code</returns>
    public override int GetHashCode() =>
        QuantityUnitName.GetHashCode();

    /// <summary>
    /// Override operator to check equality of units
    /// </summary>
    /// <param name="quantityA">First quantity to compare</param>
    /// <param name="quantityB">Second quantity to compare</param>
    /// <returns>Check units equality</returns>
    public static bool operator ==(QuantityUnit quantityA, QuantityUnit quantityB) =>
        quantityA.Equals(quantityB);

    /// <summary>
    /// Override operator to check quality of units
    /// </summary>
    /// <param name="quantityA">First quantity to compare</param>
    /// <param name="quantityB">Second quantity to compare</param>
    /// <returns>Check units not equality</returns>
    public static bool operator !=(QuantityUnit quantityA, QuantityUnit quantityB) =>
        !quantityA.Equals(quantityB);

    /// <summary>
    /// Check two quantity units compability
    /// </summary>
    /// <param name="other">Quantity unit to check</param>
    /// <returns>Two units are compatible</returns>
    public bool CheckCompatibility(QuantityUnit other) => QuantityUnitName == other.QuantityUnitName;

    /// <summary>
    /// Override sum operator to perform summary of units
    /// </summary>
    /// <param name="quantityUnitA">First quantity unit to sum</param>
    /// <param name="quantityUnitB">Second quantity unit to sum</param>
    /// <returns>Result of quantity units addition</returns>
    public static QuantityUnit operator+ (QuantityUnit quantityUnitA, QuantityUnit quantityUnitB)
    {
        quantityUnitA.ThrowIfUnitsAreNotCompatible(quantityUnitB);
        return quantityUnitA;
    }

    /// <summary>
    /// Override subtract operator to perform subtract of units
    /// </summary>
    /// <param name="quantityUnitA">First quantity unit to subtract</param>
    /// <param name="quantityUnitB">Second quantity unit to subtract</param>
    /// <returns>Result of quantity units subtract</returns>
    public static QuantityUnit operator- (QuantityUnit quantityUnitA, QuantityUnit quantityUnitB)
    {
        quantityUnitA.ThrowIfUnitsAreNotCompatible(quantityUnitB);
        return quantityUnitA;
    }

    // TODO perform combination of units
    // public static QuantityUnit operator* (QuantityUnit quantityUnitA, QuantityUnit quantityUnitB)
    // {
    //     quantityUnitA.ThrowIfUnitsAreNotCompatible(quantityUnitB);
    //     return quantityUnitA;
    // }
    //
    // public static QuantityUnit operator/ (QuantityUnit quantityUnitA, QuantityUnit quantityUnitB)
    // {
    //     quantityUnitB.ThrowIfUnitsAreNotCompatible(quantityUnitB);
    //     return quantityUnitA;
    // }

    /// <summary>
    /// Check compatible of quantity units
    /// </summary>
    /// <param name="other">Quantity unit to compare</param>
    /// <exception cref="QuantityNotSameUnitsException">Quantities don't have the same units </exception>
    private void ThrowIfUnitsAreNotCompatible(QuantityUnit other)
    {
        if (!CheckCompatibility(other))
            throw new QuantityNotSameUnitsException();
    }
}