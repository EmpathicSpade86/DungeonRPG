using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    // Since the Player has 2 Attacks, we will need to switch between them
    private int comboCounter = 1;
    private int maxComboCount = 2;

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK + comboCounter); //This is how we're going to play the different animations, Player's attack animations are labeled 'Attack1' and 'Attack2'
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        // Unsubscribe from the HandleAnimationFinished Signal
        characterNode.AnimationPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        comboCounter++; 
        comboCounter = Mathf.Wrap(comboCounter, 1, maxComboCount + 1);

        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}