using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.stateMachine.SwitchState<PlayerMoveState>(); // If the Character is moving, switch the state to the Player Move State
        }
    }

    //Listen for Input for Dash
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            characterNode.stateMachine.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.animationPlayer.Play(GameConstants.ANIM_IDLE);
    }
}
