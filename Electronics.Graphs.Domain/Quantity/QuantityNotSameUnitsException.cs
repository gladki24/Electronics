namespace Electronics.Graphs.Domain.Quantity
{
    /// <summary>
    /// Represent exception during mathematical operations where units cannot be transformed to convertible form
    /// </summary>
    public class QuantityNotSameUnitsException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public QuantityNotSameUnitsException() : base("Quantity units are different")
        {}
    }
}
