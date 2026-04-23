using Content.Client.Stylesheets;
using Content.Client.Stylesheets.Stylesheets;
using Robust.Client.Graphics;
using Robust.Shared.Utility;

namespace Content.Stellar.Client.Stylesheets;

public static class StellarStylesheetHelpers
{
    public static StyleBoxTexture IntoPatch(this Texture texture, params (StyleBox.Margin, float)[] margins)
    {
        var stylebox = new StyleBoxTexture
        {
            Texture = texture,
            TextureScale = new(2),
        };

        foreach (var (margin, amount) in margins)
        {
            stylebox.SetPatchMargin(margin, amount);
        }

        return stylebox;
    }

    public static StyleBoxTexture WithContentMargin(this StyleBoxTexture texture, params (StyleBox.Margin, float)[] margins)
    {
        var ret = new StyleBoxTexture(texture);

        foreach (var (margin, amount) in margins)
        {
            ret.SetContentMarginOverride(margin, amount);
        }

        return ret;
    }

    public static StyleBoxTexture WithTexture(this StyleBoxTexture box, Texture texture)
    {
        var ret = new StyleBoxTexture(box);
        ret.Texture = texture;
        return ret;
    }

    public static Texture StellarTexture(this BaseStylesheet sheet, ResPath target)
    {
        return sheet.GetTextureOr(target, NanotrasenStylesheet.StellarTextureRoot);
    }
}
