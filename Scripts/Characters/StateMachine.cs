using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState;
    [Export] private Node[] states;

    public override void _Ready()
    {
        //Basically Sends a message to any script that has the _Notification Function with that number
        currentState.Notification(GameConstants.NOTIFCATION_ENTER_STATE); //A completely random number not used by Godot 
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

        currentState.Notification(GameConstants.NOTIFCATION_EXIT_STATE); //Notification for disabling states
        currentState = newState;
        currentState.Notification(GameConstants.NOTIFCATION_ENTER_STATE); //Update the Current State of Animation
    }
}
