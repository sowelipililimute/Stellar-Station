using Content.Shared.Body;
using Content.Shared.Humanoid;
using Content.Shared.Humanoid.Markings;
using Content.Shared.Humanoid.Prototypes;
using Content.Shared.Preferences.Loadouts;
using Content.Shared.Roles;
using Content.Stellar.Shared.Jobs;
using Robust.Shared.Enums;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Stellar.Shared.Preferences;

[DataDefinition]
[Serializable, NetSerializable]
public sealed partial class StellarProfile
{
    [DataField]
    public string Name;

    [DataField]
    public ProtoId<SpeciesPrototype> Species;

    [DataField]
    public int Age;

    [DataField]
    public Sex Sex;

    [DataField]
    public Gender Gender;

    [DataField]
    public StellarCharacterAppearance Appearance = new();

    [DataField]
    public StellarCharacterMarkings Markings = new();

    [DataField]
    public ProtoId<StellarCareerPrototype> Career;

    [DataField]
    public Dictionary<ProtoId<JobPrototype>, StellarProfileJob> Jobs = new();

    [DataField]
    public Dictionary<ProtoId<AntagPrototype>, StellarAntagonistPriority> Antagonists = new();
}

[DataDefinition]
[Serializable, NetSerializable]
public sealed partial class StellarCharacterAppearance
{
    [DataField]
    public Color EyeColor;

    [DataField]
    public Color SkinColor;
}

[DataDefinition]
[Serializable, NetSerializable]
public sealed partial class StellarCharacterMarkings
{
    [DataField]
    public Dictionary<ProtoId<OrganCategoryPrototype>, Dictionary<HumanoidVisualLayers, List<Marking>>> Markings = new();
}

[DataDefinition]
[Serializable, NetSerializable]
public sealed partial class StellarProfileJob
{
    [DataField]
    public bool Enabled;

    [DataField]
    public Dictionary<ProtoId<LoadoutGroupPrototype>, List<StellarProfileLoadout>> Loadouts;

    [DataField]
    public StellarCharacterMarkings? Markings;
}

[DataDefinition]
[Serializable, NetSerializable]
public sealed partial class StellarProfileLoadout
{
    [DataField]
    public ProtoId<LoadoutPrototype> Loadout;
}

public enum StellarAntagonistPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
}
