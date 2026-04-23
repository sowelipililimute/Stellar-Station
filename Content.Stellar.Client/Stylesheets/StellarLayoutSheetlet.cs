using Content.Client.Stylesheets;
using static Content.Client.Stylesheets.StylesheetHelpers;
using Robust.Client.UserInterface;

namespace Content.Stellar.Client.Stylesheets;

[CommonSheetlet]
public sealed class StellarLayoutSheetlet : Sheetlet<PalettedStylesheet>
{
    public override StyleRule[] GetRules(PalettedStylesheet sheet, object config)
    {
        return
        [
            E()
                .Class(StellarStyleClasses.InsetBox)
                .Margin(8),
        ];
    }
}
