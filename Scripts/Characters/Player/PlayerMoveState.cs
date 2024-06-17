using Godot;
using System;

public partial class PlayerMoveState : Node
{
    private PlayerController characterNode;
    public override void _Ready()
    {
        characterNode = GetOwner<PlayerController>();
        SetPhysicsProcess(false); //Disables the Physics Process Method While the State is Inactive
        SetProcessInput(false); //Disables the Input Method While the State is Inactive
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.stateMachine.SwitchState<PlayerIdleState>();  // If the Character is not moving, switch the state to the Idle State
            return;
        }

        characterNode.Velocity = new Vector3(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= 5.0f;

        characterNode.MoveAndSlide(); //Uses the Velocity to Begin moving the player along with the physics engine 
        characterNode.Flip();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        //Recieved from the State Machine, will then update the player's State
        if (what == 5001)
        {
            characterNode.animationPlayer.Play(GameConstants.ANIM_MOVE);
            //Re-Enable the other functions when the State is Active
            SetPhysicsProcess(true);
            SetProcessInput(true); 
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false); //Disables the Input Method While the State is Inactive
        }
    }

    public override void _Input(InputEvent @event)
    {
        if(Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            characterNode.stateMachine.SwitchState<PlayerDashState>();
        }
    }
}
