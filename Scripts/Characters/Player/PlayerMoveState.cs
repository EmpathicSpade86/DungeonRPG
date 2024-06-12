using Godot;
using System;

public partial class PlayerMoveState : Node
{
    private PlayerController characterNode;
    public override void _Ready()
    {
        characterNode = GetOwner<PlayerController>();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.stateMachine.SwitchState<PlayerIdleState>();  // If the Character is moving, switch the state to the Player Move State
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            PlayerController characterNode = GetOwner<PlayerController>();
            characterNode.animationPlayer.Play(GameConstants.ANIM_MOVE);
        }
    }
}
