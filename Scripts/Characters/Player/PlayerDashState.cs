using Godot;
using System;

public partial class PlayerDashState : Node
{
    private PlayerController characterNode;
    public override void _Ready()
    {
        characterNode = GetOwner<PlayerController>();
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
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
        }
    }
}
