using System.Linq;
using Content.Client.Humanoid;
using Content.Shared.Humanoid;
using Content.Shared.Humanoid.Markings;
using Content.Shared.Humanoid.Prototypes;
using Content.Shared.Roles;
using Content.Stellar.Shared.Jobs;
using Content.Stellar.Shared.Preferences;
using Robust.Shared.Enums;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Stellar.Client.Preferences;

public sealed class StellarProfileViewModel
{
    [Dependency] private readonly IPrototypeManager _prototype = default!;
    [Dependency] private readonly MarkingManager _marking = default!;

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (_name == value)
                return;

            _name = value;
            NameChanged?.Invoke();
        }
    }

    public event Action? NameChanged;

    private ProtoId<SpeciesPrototype> _species;
    public ProtoId<SpeciesPrototype> Species
    {
        get => _species;
        set
        {
            if (_species == value)
                return;

            _species = value;
            if (_prototype.TryIndex(value, out var newSpecies))
            {
                SkinColor = _prototype.Index(newSpecies.SkinColoration).Strategy.EnsureVerified(SkinColor);
                if (!newSpecies.Sexes.Contains(Sex))
                {
                    _sex = newSpecies.Sexes[0];
                }
            }

            _markingsViewModel.OrganData = _marking.GetMarkingData(_species);
            _markingsViewModel.OrganProfileData = _marking.GetProfileData(_species,
                Sex,
                SkinColor,
                EyeColor);

            SpeciesChanged?.Invoke();
            SexChanged?.Invoke();
        }
    }

    public List<Sex> SpeciesSexes => _prototype.Index(_species).Sexes;

    public event Action? SpeciesChanged;

    private int _age;

    public int Age
    {
        get => _age;
        set
        {
            if (_age == value)
                return;

            _age = value;
            AgeChanged?.Invoke();
        }
    }

    public event Action? AgeChanged;

    private Sex _sex;
    public Sex Sex
    {
        get => _sex;
        set
        {
            if (_sex == value)
                return;

            _sex = value;
            _markingsViewModel.SetOrganSexes(_sex);
            SexChanged?.Invoke();
        }
    }

    public event Action? SexChanged;

    private Gender _gender;
    public Gender Gender
    {
        get => _gender;
        set
        {
            if (_gender == value)
                return;

            _gender = value;
            GenderChanged?.Invoke();
        }
    }

    public event Action? GenderChanged;

    private ProtoId<StellarCareerPrototype> _career;
    public ProtoId<StellarCareerPrototype> Career
    {
        get => _career;
        set
        {
            if (_career == value)
                return;

            _career = value;
            ValidateJobs();
            CareerChanged?.Invoke();
        }
    }

    public event Action? CareerChanged;

    private readonly Dictionary<ProtoId<JobPrototype>, StellarProfileJobsViewModel> _jobs;
    public IReadOnlyDictionary<ProtoId<JobPrototype>, StellarProfileJobsViewModel> Jobs => _jobs;

    public event Action? JobsReset;

    private readonly MarkingsViewModel _markingsViewModel;
    public MarkingsViewModel MarkingsViewModel => _markingsViewModel;

    private Color _eyeColor;

    public Color EyeColor
    {
        get => _eyeColor;
        set
        {
            if (_eyeColor == value)
                return;

            _eyeColor = value;
            _markingsViewModel.SetOrganEyeColor(value);
            EyeColorChanged?.Invoke();
        }
    }

    public event Action? EyeColorChanged;

    private Color _skinColor;

    public Color SkinColor
    {
        get => _skinColor;
        set
        {
            if (_skinColor == value)
                return;

            _skinColor = value;
            _markingsViewModel.SetOrganSkinColor(value);
            SkinColorChanged?.Invoke();
        }
    }

    public event Action? SkinColorChanged;

    private readonly Dictionary<ProtoId<AntagPrototype>, StellarAntagonistPriority> _antagonistPriorities;

    public IReadOnlyDictionary<ProtoId<AntagPrototype>, StellarAntagonistPriority> AntagonistPriorities =>
        _antagonistPriorities;

    public StellarProfileViewModel(StellarProfile profile)
    {
        IoCManager.InjectDependencies(this);

        _name = profile.Name;
        _species = profile.Species;
        _age = profile.Age;
        _sex = profile.Sex;
        _gender = profile.Gender;
        _career = profile.Career;
        _jobs = profile.Jobs.ToDictionary(kvp => kvp.Key, kvp => new StellarProfileJobsViewModel(kvp.Key, kvp.Value));
        _markingsViewModel = new();
        _markingsViewModel.OrganData = _marking.GetMarkingData(profile.Species);
        _markingsViewModel.OrganProfileData = _marking.GetProfileData(profile.Species,
            profile.Sex,
            profile.Appearance.SkinColor,
            profile.Appearance.EyeColor);
        _markingsViewModel.Markings = profile.Markings.Markings;
        _antagonistPriorities = profile.Antagonists.ShallowClone();

        ValidateJobs();
    }

    private void ValidateJobs()
    {
        if (!_prototype.TryIndex(_career, out var career))
            return;

        foreach (var job in _jobs.Keys)
        {
            if (!career.Jobs.Contains(job))
                _jobs.Remove(job);
        }

        foreach (var job in career.Jobs)
        {
            _jobs.TryAdd(job,
                new StellarProfileJobsViewModel(job,
                    new StellarProfileJob()
            {
                Enabled = true,
            }));
        }

        JobsReset?.Invoke();
    }
}
