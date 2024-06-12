using Godot;
using System;

public partial class PlayerIdleState : Node
{
    public override void _Ready()
    {

    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        //Recieved from the State Machine, will then play the designated Animation
        if (what == 5001)
        {
            PlayerController characterNode = GetOwner<PlayerController>();
            characterNode.animationPlayer.Play(GameConstants.ANIM_IDLE);
        }
    }
}
