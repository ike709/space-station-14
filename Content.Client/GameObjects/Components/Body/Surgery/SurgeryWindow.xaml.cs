﻿#nullable enable
using System.Collections.Generic;
using Content.Shared.GameObjects.Components.Body.Part;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Localization;

namespace Content.Client.GameObjects.Components.Body.Surgery
{
    [GenerateTypedNameReferences]
    public partial class SurgeryWindow : SS14Window
    {
        public SurgeryWindow()
        {
            RobustXamlLoader.Load(this);
        }

        public IReadOnlyList<Button> PartButtons { get; private set; } = new List<Button>();

        public void UpdateParts(IEnumerable<IBodyPart> parts)
        {
            Parts.RemoveAllChildren();

            var buttons = new List<Button>();

            foreach (var part in parts)
            {
                var button = new PartButton(part.Owner.Uid) {Text = Loc.GetString(part.Owner.Name)};
                Parts.AddChild(button);
                buttons.Add(button);
            }

            PartButtons = buttons;
        }
    }
}
