using Content.IntegrationTests.Fixtures;
using Content.IntegrationTests.Fixtures.Attributes;
using Content.Shared.Humanoid.Prototypes;
using Content.Shared.Roles;
using Content.Stellar.Client.Preferences;
using Content.Stellar.Shared.Jobs;
using Content.Stellar.Shared.Preferences;
using Robust.Shared.Prototypes;

namespace Content.IntegrationTests.Tests._ST.Preferences;

[TestFixture]
public sealed class StellarProfileViewModelTests : GameTest
{
    private static readonly ProtoId<StellarCareerPrototype> Career1Id = "StellarCareer1";
    private static readonly ProtoId<StellarCareerPrototype> Career2Id = "StellarCareer2";

    private static readonly ProtoId<JobPrototype> Job1Id = "StellarJob1";
    private static readonly ProtoId<JobPrototype> Job2Id = "StellarJob2";
    private static readonly ProtoId<JobPrototype> Job3Id = "StellarJob3";

    private static readonly ProtoId<SpeciesPrototype> Species1Id = "Reptilian";
    private static readonly ProtoId<SpeciesPrototype> Species2Id = "Human";

    [TestPrototypes]
    private static string Prototypes = $@"
- type: playTimeTracker
  id: StellarProfileViewModelTestsTracker1

- type: playTimeTracker
  id: StellarProfileViewModelTestsTracker2

- type: playTimeTracker
  id: StellarProfileViewModelTestsTracker3

- type: job
  id: {Job1Id}
  playTimeTracker: StellarProfileViewModelTestsTracker1

- type: job
  id: {Job2Id}
  playTimeTracker: StellarProfileViewModelTestsTracker2

- type: job
  id: {Job3Id}
  playTimeTracker: StellarProfileViewModelTestsTracker3

- type: stellarCareer
  id: {Career1Id}
  jobs:
  - {Job1Id}
  - {Job2Id}

- type: stellarCareer
  id: {Career2Id}
  jobs:
  - {Job2Id}
  - {Job3Id}
";

    private static readonly StellarProfile JohnProfile = new()
    {
        Career = Career1Id,
        Species = Species1Id,
    };

    [Test]
    [RunOnSide(Side.Client)]
    public void CareerSwitchingWorks()
    {
        var model = new StellarProfileViewModel(JohnProfile);

        Assert.That(model.Jobs, Has.Count.EqualTo(2));
        Assert.That(model.Jobs, Contains.Key(Job1Id));
        Assert.That(model.Jobs, Contains.Key(Job2Id));

        model.Career = Career2Id;
        Assert.That(model.Jobs, Does.Not.ContainKey(Job1Id));
        Assert.That(model.Jobs, Does.ContainKey(Job3Id));
    }

    [Test]
    [RunOnSide(Side.Client)]
    public void SpeciesSwitchingWorks()
    {
        var model = new StellarProfileViewModel(JohnProfile);
        var oldSkinColor = model.SkinColor;
        model.Species = Species2Id;

        Assert.That(oldSkinColor, Is.Not.EqualTo(model.SkinColor));
    }
}
