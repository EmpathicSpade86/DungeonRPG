using Godot;
using System;

public partial class EnemyChaseState : EnemyState
{
    protected override void EnterState()
    {
        GD.Print("Chase State Entered");
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
    }

}