using Godot;
using System;


//Abstract makes it so that the class cannot be instantiated. I.E. It cannot be attached to a node (It will throw an error)
//Must Define a Child Class to use this class
public abstract partial class PlayerState : CharacterState
{
    public override void _Ready()
    {
        base._Ready();
        characterNode.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;

    }

    protected void CheckForAttackInput()
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_ATTACK))
        {
            characterNode.StateMachineNode.SwitchState<PlayerAttackState>();
        }
    }

    private void HandleZeroHealth()
    {
        characterNode.StateMachineNode.SwitchState<PlayerDeathState>();
    }

}