using Godot;
using System;

public partial class BombController : Node3D
{
    [Export] private AnimationPlayer animationPlayer;
    [Export(PropertyHint.Range, "0,100,1")] public float damage { get; private set; } = 10.0f;

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
