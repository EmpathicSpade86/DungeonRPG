using Godot;
using System;

public partial class Main : Node3D
{
    //Attached to the Root Node of the Main Scene

    //Pause the Game when it starts
    public override void _Ready()
    {
        //GetTree() will return all the children in the scene
        //.Paused will pause all Nodes with a Physics Process Method
        GetTree().Paused = true;

    }
}
