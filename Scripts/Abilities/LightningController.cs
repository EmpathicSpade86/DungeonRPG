using Godot;
using System;

public partial class LightningController : AbilityBasic
{
    public override void _Ready()
    {
        animationPlayer.AnimationFinished += (animName) => QueueFree(); // Lambda Function to delete the Lightning once the animation is finished playing
        
    }

}
