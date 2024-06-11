using Godot;
using System;

public partial class PlayerController : CharacterBody3D
{

    public override void _Input(InputEvent @event)
    {
        GD.Print("Input");
    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print("Hello World");
    }
}
