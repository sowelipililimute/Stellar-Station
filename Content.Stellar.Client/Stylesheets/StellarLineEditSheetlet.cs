using Content.Client.Stylesheets;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Content.Client.Stylesheets.StylesheetHelpers;

namespace Content.Stellar.Client.Stylesheets;

[CommonSheetlet]
public sealed class StellarLineEditSheetlet<T> : Sheetlet<T>
    where T : PalettedStylesheet
{
    public override StyleRule[] GetRules(T sheet, object config)
    {
        var box = sheet.StellarTexture(new("Controls/line_edit.png"))
            .IntoPatch(
                (StyleBox.Margin.All, 1))
            .WithContentMargin(
                (StyleBox.Margin.Horizontal, 8));

        return
        [
            E<LineEdit>()
                .Prop(LineEdit.StylePropertyStyleBox, box),
        ];
    }
}
