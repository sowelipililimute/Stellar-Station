namespace Content.Client.Stylesheets.Fonts;

/// <summary>
///     The available kinds of font.
/// </summary>
public enum FontKind
{
    Regular,
    Bold,
    Italic,
    BoldItalic,
    // Begin Stellar - MORE FONTS
    Medium,
    MediumItalic,
    // End Stellar
}

public static class FontKindExtensions
{
    internal static string AsFileName(this FontKind kind)
    {
        return kind switch
        {
            FontKind.Regular => "Regular",
            FontKind.Bold => "Bold",
            FontKind.Italic => "Italic",
            FontKind.BoldItalic => "BoldItalic",
            // Begin Stellar - MORE FONTS
            FontKind.Medium => "Medium",
            FontKind.MediumItalic => "MediumItalic",
            // End Stellar
            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null),
        };
    }

    // Begin Stellar - this sucks
    // internal static bool IsBold(this FontKind kind)
    // {
    //     return kind is FontKind.Bold or FontKind.BoldItalic;
    // }

    // internal static bool IsItalic(this FontKind kind)
    // {
    //     return kind is FontKind.Italic or FontKind.BoldItalic;
    // }
    // End Stellar - this sucks

    internal static FontKind SimplifyCompound(this FontKind kind)
    {
        return kind switch
        {
            // Begin Stellar - more weights
            FontKind.Italic => FontKind.Regular,
            FontKind.BoldItalic => FontKind.Bold,
            FontKind.MediumItalic => FontKind.Medium,
            // End Stellar - more weights
            _ => kind,
        };
    }

    // Begin Stellar - this sucks
    // internal static FontKind RegularOr(this FontKind kind, FontKind other)
    // {
    //     return kind switch
    //     {
    //         FontKind.Regular => FontKind.Regular,
    //         _ => other,
    //     };
    // }
    // End Stellar - this sucks
}

