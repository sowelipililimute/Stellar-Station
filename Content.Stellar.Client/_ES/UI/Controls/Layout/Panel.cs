// SPDX-FileCopyrightText: 2026 kaylie <moony@hellomouse.net>
//
// SPDX-License-Identifier: MIT

using Robust.Client.UserInterface.Controls;

namespace Content.Client._ES.UI.Controls.Layout;

[Virtual]
public class Panel : PanelContainer
{

}

[Virtual]
public class FillPanel : PanelContainer
{
    public FillPanel()
    {
        HorizontalExpand = true;
        VerticalExpand = true;
    }
}
