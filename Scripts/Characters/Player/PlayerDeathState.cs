using Godot;
using System;
using System.Reflection.Metadata;

public partial class PlayerDeathState : PlayerState
{
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_DEATH);
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        GameEvents.RaiseEndGame(); //Raise the End Game Event when the Player Dies
        characterNode.QueueFree(); //Delete the Player
    }
}