using Godot;
using System;

public partial class UIContainer : Container
{
    [Export] public ContainerType container { get; private set; }
    [Export] public Button buttonNode { get; private set; }


}
