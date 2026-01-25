using Robust.Shared.Prototypes;

namespace Content.Stellar.Shared.WallSmooth;

/// <summary>
/// Marker prototype that defines keys for wallsmoothing
/// </summary>
[Prototype]
public sealed partial class StellarWallSmoothKeyPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = default!;
}
