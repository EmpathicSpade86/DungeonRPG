using Godot;
using System;

public partial class PlayerIdleState : Node
{
    private PlayerController characterNode;
    public override void _Ready()
    {
        characterNode = GetOwner<PlayerController>();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.stateMachine.SwitchState<PlayerMoveState>();  // If the Character is moving, switch the state to the Player Move State
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        //Recieved from the State Machine, will then update the player's State
        if (what == 5001)
        {
            characterNode.animationPlayer.Play(GameConstants.ANIM_IDLE);
        }
    }
}
