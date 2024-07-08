using Godot;
using System;


//Abstract makes it so that the class cannot be instantiated. I.E. It cannot be attached to a node (It will throw an error)
//Must Define a Child Class to use this class
public abstract partial class PlayerState : CharacterState
{
    protected void CheckForAttackInput()
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_ATTACK))
        {
            characterNode.StateMachineNode.SwitchState<PlayerAttackState>();
        }
    }

}