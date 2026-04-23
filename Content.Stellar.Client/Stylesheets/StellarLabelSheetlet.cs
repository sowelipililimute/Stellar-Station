using Content.Client.Stylesheets;
using Content.Client.Stylesheets.Fonts;
using static Content.Client.Stylesheets.StylesheetHelpers;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Stellar.Client.Stylesheets;

[CommonSheetlet]
public sealed class StellarLabelSheetlet : Sheetlet<PalettedStylesheet>
{
    public override StyleRule[] GetRules(PalettedStylesheet sheet, object config)
    {
        return
        [
            E<Label>()
                .Class(StellarStyleClasses.FieldLabel)
                .Font(sheet.BaseFont.GetFont(10, FontKind.Medium)),
        ];
    }
}
