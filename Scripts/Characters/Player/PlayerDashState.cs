using Godot;
using System;

public partial class PlayerDashState : Node
{
    private PlayerController characterNode;
    [Export] private Timer dashTimer;
    public override void _Ready()
    {
        characterNode = GetOwner<PlayerController>();
        dashTimer.Timeout += HandleDashTimeout;
        SetPhysicsProcess(false); //Disables the Physics Process Method While the State is Inactive
    }

    public override void _PhysicsProcess(double delta)
    {
        // For the Future
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        //Recieved from the State Machine, will then update the player's State
        if (what == 5001)
        {
            characterNode.animationPlayer.Play(GameConstants.ANIM_DASH);
            SetPhysicsProcess(true);
            dashTimer.Start(); //Start the Timer when you switch to the State
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
        }
    }

    private void HandleDashTimeout()
    {
        //What to do when the Timer Reaches 0
        characterNode.stateMachine.SwitchState<PlayerIdleState>();
    }
}
