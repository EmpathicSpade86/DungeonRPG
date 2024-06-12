using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState;
    [Export] private Node[] states;

    public override void _Ready()
    {
        //Basically Sends a message to any script that has the _Notification Function with that number
        currentState.Notification(5001); //A completely random number not used by Godot 
    }
}
