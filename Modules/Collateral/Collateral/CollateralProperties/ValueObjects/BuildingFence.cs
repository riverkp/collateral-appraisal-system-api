namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingFence : ValueObject
{
    public string? Fence { get; private set; }
    public string? FenceOther { get; private set; }

    private BuildingFence(string? fence, string? fenceOther)
    {
        Fence = fence;
        FenceOther = fenceOther;
    }

    public static BuildingFence Create(string? fence, string? fenceOther)
    {
        return new BuildingFence(fence, fenceOther);
    }
}
