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

    public void SwitchState<T>() //Given a type: PlayerIdleState, PlayerMoveState...
    {
        Node newState = null;
        foreach (Node state in states)
        {
            if (state is T) // If the Type of the variable has a specific Type
            {
                newState = state;
            }
        }

        if (newState == null) { return;}

        currentState = newState;
        currentState.Notification(5001); //Update the Current State of Animation
    }
}
