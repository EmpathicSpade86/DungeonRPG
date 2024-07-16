using Godot;
using System;

public partial class StatLabel : Label
{
    [Export] private StatResource resource;
    public override void _Ready()
    {
        //Subscribe to the OnUpdate Event
        resource.OnUpdate += HandleOnUpdate;

        //Default Health
        Text = resource.StatValue.ToString();
    }

    private void HandleOnUpdate()
    {
        Text = resource.StatValue.ToString(); //Change the Text of the Label
    }
}