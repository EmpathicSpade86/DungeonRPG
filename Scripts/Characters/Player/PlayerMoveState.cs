using Godot;
using System;

public partial class PlayerMoveState : Node
{
    public override void _Ready()
    {
        PlayerController characterNode = GetOwner<PlayerController>();
        characterNode.animationPlayer.Play(GameConstants.ANIM_MOVE); 
    }
}
