using Godot;
using System;

public partial class PlayerIdleState : Node
{
    public override void _Ready()
    {
        PlayerController characterNode = GetOwner<PlayerController>();
        characterNode.animationPlayer.Play(GameConstants.ANIM_IDLE); 
    }
}
