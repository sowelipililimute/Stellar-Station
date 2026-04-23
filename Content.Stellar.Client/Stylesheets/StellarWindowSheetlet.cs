using Content.Client.Stylesheets;
using Content.Client.Stylesheets.Fonts;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using static Content.Client.Stylesheets.StylesheetHelpers;

namespace Content.Stellar.Client.Stylesheets;

[CommonSheetlet]
public sealed class StellarWindowSheetlet<T> : Sheetlet<T>
    where T : PalettedStylesheet
{
    public override StyleRule[] GetRules(T sheet, object config)
    {
        var headerBox = sheet.StellarTexture(new("Controls/window_titlebar.png"))
            .IntoPatch(
                (StyleBox.Margin.Top, 4),
                (StyleBox.Margin.Horizontal, 3),
                (StyleBox.Margin.Bottom, 1))
            .WithContentMargin(
                (StyleBox.Margin.Bottom, 0));

        var backgroundBox = sheet.StellarTexture(new("Controls/window.png"))
            .IntoPatch(
                (StyleBox.Margin.Top, 4),
                (StyleBox.Margin.Horizontal, 3),
                (StyleBox.Margin.Bottom, 1));

        return
        [
            E()
                .Class(DefaultWindow.StyleClassWindowPanel)
                .Panel(backgroundBox),

            E()
                .Class("STWindowBackground")
                .Panel(backgroundBox),

            E()
                .Class(DefaultWindow.StyleClassWindowHeader)
                .Panel(headerBox),

            E()
                .Class("STWindowHeader")
                .Panel(headerBox),

            E<Label>()
                .Class(DefaultWindow.StyleClassWindowTitle)
                .Font(sheet.BaseFont.GetFont(12, FontKind.Medium))
                .AlignMode(Label.AlignMode.Center),

            E<Label>()
                .Class("FancyWindowTitle")
                .Font(sheet.BaseFont.GetFont(12, FontKind.Medium))
                .AlignMode(Label.AlignMode.Center),
        ];
    }
}
