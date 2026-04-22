// SPDX-FileCopyrightText: 2026 kaylie <moony@hellomouse.net>
//
// SPDX-License-Identifier: MIT

using JetBrains.Annotations;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._ES.UI.Controls;

[PublicAPI]
public sealed class EButtonGroupExtension
{
    public bool IsNoneSetAllowed { get; }

    public EButtonGroupExtension(bool isNoneSetAllowed)
    {
        IsNoneSetAllowed = isNoneSetAllowed;
    }

    public object ProvideValue()
    {
        return new ButtonGroup(IsNoneSetAllowed);
    }
}
