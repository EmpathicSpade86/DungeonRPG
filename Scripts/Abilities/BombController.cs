using Godot;
using System;

public partial class BombController : AbilityBasic
{
    public override void _Ready()
    {
        animationPlayer.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        if (animName == GameConstants.ANIM_EXPAND)
        {
            animationPlayer.Play(GameConstants.ANIM_EXPLODE); //Switch to the Explosion Animation
        }
        else if (animName == GameConstants.ANIM_EXPLODE)
        {
            QueueFree(); //If it has exploded, delete from the scene
        }
    }

}
