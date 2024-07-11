using Godot;
using System;

public partial class EnemyDeathState : EnemyState
{
    protected override void EnterState()
    {
        // Play the death Animation
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_DEATH);
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        // Delete the Enemy from the Scene
        characterNode.QueueFree(); // Deletes the Node and Child Nodes
    }
}