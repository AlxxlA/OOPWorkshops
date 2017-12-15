namespace Cosmetics.Contracts
{
    using Cosmetics.Common;

    public interface IShampoo : IProduct
    {
        uint Militres { get; }

        UsageType UsageType { get; }
    }
}