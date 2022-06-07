namespace Electronics.Graphs.Domain.Quantity
{
    /// <summary>
    /// Struct represents abstract quantity
    /// </summary>
    public struct Quantity : IEquatable<Quantity>
    {
        /// <summary>
        /// Value part of quantity
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Unit part of quantity
        /// </summary>
        public QuantityUnit Unit { get; set; }

        public Quantity()
        {
            Value = 0;
            Unit = QuantityUnit.Unknown;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="unit">Unit part of quantity</param>
        /// <param name="value">Value part of quantity</param>
        public Quantity(QuantityUnit unit, decimal value = 0)
        {
            Unit = unit;
            Value = value;
        }

        /// <summary>
        /// Override operator to sum two quantities
        /// </summary>
        /// <param name="quantityA">First quantity to sum</param>
        /// <param name="quantityB">Second quantity to sum</param>
        /// <returns>Result of quantities sum</returns>
        public static Quantity operator+ (Quantity quantityA, Quantity quantityB)
        {
            ThrowIfUnitsNotCompatible(quantityA, quantityB);
            return new Quantity(quantityA.Unit + quantityB.Unit, quantityA.Value + quantityB.Value);
        }

        /// <summary>
        /// Override operator to subtract two quantities
        /// </summary>
        /// <param name="quantityA">First quantity to subtract</param>
        /// <param name="quantityB">Second quantity to subtract</param>
        /// <returns>Result of quantities subtract</returns>
        public static Quantity operator- (Quantity quantityA, Quantity quantityB)
        {
            ThrowIfUnitsNotCompatible(quantityA, quantityB);
            return new Quantity(quantityA.Unit - quantityB.Unit, quantityA.Value - quantityB.Value);
        }

        // TODO multiply of two quantities
        // /// <summary>
        // /// Override operator to multiply two quantities
        // /// </summary>
        // /// <param name="quantityA">First quantity to multiply</param>
        // /// <param name="quantityB">Second quantity to multiply</param>
        // /// <returns>Result of quantities multiply</returns>
        // public static Quantity operator* (Quantity quantityA, Quantity quantityB)
        // {
        //     ThrowIfUnitsNotCompatible(quantityA, quantityA);
        //     return new Quantity(quantityA.Unit, quantityA.Value * quantityB.Value);
        // }

        // TODO divide of two quantities
        // /// <summary>
        // /// Override operator to divide two quantities
        // /// </summary>
        // /// <param name="quantityA">First quantity to divide</param>
        // /// <param name="quantityB">Second quantity to divide</param>
        // /// <returns>Result of quantities divide</returns>
        // public static Quantity operator/ (Quantity quantityA, Quantity quantityB)
        // {
        //     ThrowIfUnitsNotCompatible(quantityA, quantityB);
        //     return new Quantity(quantityA.Unit, quantityA.Value / quantityB.Value);
        // }

        /// <summary>
        /// Override operator to multiply quantity by factor
        /// </summary>
        /// <param name="quantity">Quantity to multiply</param>
        /// <param name="factor">Factor to multiply quantity</param>
        /// <returns>Quantity multiples by factory</returns>
        public static Quantity operator* (Quantity quantity, decimal factor) =>
            new Quantity(quantity.Unit, quantity.Value * factor);

        /// <summary>
        /// Override operator to divide quantity by factor
        /// </summary>
        /// <param name="quantity">Quantity to divide</param>
        /// <param name="factor">Factor to divide quantity</param>
        /// <returns>Quantity divides by factory</returns>
        public static Quantity operator /(Quantity quantity, decimal factor) =>
            new Quantity(quantity.Unit, quantity.Value / factor);

        /// <summary>
        /// Override operator to equality two quantities
        /// </summary>
        /// <param name="quantityA">First quantity to compare</param>
        /// <param name="quantityB">Second quantity to compare</param>
        /// <returns>Are two quantities equal</returns>
        public static bool operator ==(Quantity quantityA, Quantity quantityB) => 
            quantityA.Equals(quantityB);

        /// <summary>
        /// Override operator to check not equality two quantities
        /// </summary>
        /// <param name="quantityA">First quantity to compare</param>
        /// <param name="quantityB">Second quantity to compare</param>
        /// <returns>Are two quantities not equal</returns>
        public static bool operator !=(Quantity quantityA, Quantity quantityB) =>
            !quantityA.Equals(quantityB);

         /// <summary>
        /// Check two quantities are equal
        /// </summary>
        /// <param name="other">Other quantity to compare</param>
        /// <returns>Are two quantities equal</returns>
        public bool Equals(Quantity other) =>
             Value == other.Value && Unit.Equals(other.Unit);

         /// <summary>
        /// Check two quantities are equal
        /// </summary>
        /// <param name="obj">Other quantity to compare</param>
        /// <returns>Are two quantities equal</returns>
        public override bool Equals(object? obj) =>
             obj is Quantity other && Equals(other);

         /// <summary>
        /// Combine HashCode
        /// </summary>
        /// <returns>HashCode which represent two values</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Unit);
        }

        /// <summary>
        /// Throw if two quantities cannot be compared in case of different units
        /// </summary>
        /// <param name="quantityA">First quantity to compare</param>
        /// <param name="quantityB">Second quantity to compare</param>
        /// <exception cref="QuantityNotSameUnitsException">Quantities has not compatible units</exception>
        internal static void ThrowIfUnitsNotCompatible(Quantity quantityA, Quantity quantityB)
        {
            if (quantityA.IsUnitCompatible(quantityB))
                throw new QuantityNotSameUnitsException();
        }

        /// <summary>
        /// Check two quantities has compatible units
        /// </summary>
        /// <param name="quantity">Quantity to compare</param>
        /// <returns>Two quantities has compatible units</returns>
        public bool IsUnitCompatible(Quantity quantity) =>
            Unit == quantity.Unit;
    }
}