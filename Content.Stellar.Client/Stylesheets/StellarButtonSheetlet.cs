using Content.Client.Stylesheets;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Content.Client.Stylesheets.StylesheetHelpers;

namespace Content.Stellar.Client.Stylesheets;

[CommonSheetlet]
public sealed class StellarButtonSheetlet<T> : Sheetlet<T>
    where T : PalettedStylesheet
{
    public override StyleRule[] GetRules(T sheet, object config)
    {
        var box = sheet.StellarTexture(new("Controls/button.png"))
            .IntoPatch(
                (StyleBox.Margin.All, 2))
            .WithContentMargin(
                (StyleBox.Margin.Horizontal, 6));

        return
        [
            CButton()
                .Box(box),

            CButton()
                .PseudoDisabled()
                .Box(box.WithTexture(sheet.StellarTexture(new("Controls/button_disabled.png")))),

            CButton()
                .PseudoHovered()
                .Box(box.WithTexture(sheet.StellarTexture(new("Controls/button_hovered.png")))),

            CButton()
                .PseudoPressed()
                .Box(box.WithTexture(sheet.StellarTexture(new("Controls/button_pressed.png")))),

            CButton()
                .PseudoDisabled()
                .ParentOf(E<Label>())
                .FontColor(Color.FromHex("#E5E5E581")),

            CButton()
                .PseudoDisabled()
                .ParentOf(E())
                .ParentOf(E<Label>())
                .FontColor(Color.FromHex("#E5E5E581")),

            E<Label>()
                .Class(ContainerButton.StyleClassButton)
                .AlignMode(Label.AlignMode.Center),
        ];
    }

    private static MutableSelectorElement CButton()
    {
        return E<ContainerButton>().Class(ContainerButton.StyleClassButton);
    }
}
