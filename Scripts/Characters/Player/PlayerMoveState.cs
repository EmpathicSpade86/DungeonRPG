using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
    [Export(PropertyHint.Range, "0,20,0.1")] private float playerSpeed = 5.0f; 

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.stateMachine.SwitchState<PlayerIdleState>();  // If the Character is not moving, switch the state to the Idle State
            return;
        }

        characterNode.Velocity = new Vector3(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= playerSpeed; //Makes the Player move faster

        characterNode.MoveAndSlide(); //Uses the Velocity to Begin moving the player along with the physics engine 
        characterNode.Flip();
    }

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
        characterNode.animationPlayer.Play(GameConstants.ANIM_MOVE);
    }

}
