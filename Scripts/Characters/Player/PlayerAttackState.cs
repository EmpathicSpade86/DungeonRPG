using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer AttackComboResetTimer; 

    // Since the Player has 2 Attacks, we will need to switch between them
    private int comboCounter = 1;
    private int maxComboCount = 2;

    public override void _Ready()
    {
        base._Ready();
        //We want to subscribe to the timer, and always lisetn to it no matter what state we are in
        AttackComboResetTimer.Timeout += () => comboCounter = 1; //Lambda Function, just skips the implementation of a method and resets the comboCounter to 1 on Timeout
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK + comboCounter); //This is how we're going to play the different animations, Player's attack animations are labeled 'Attack1' and 'Attack2'
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        // Unsubscribe from the HandleAnimationFinished Signal
        characterNode.AnimationPlayerNode.AnimationFinished -= HandleAnimationFinished;
        //Start the Timer after attacking
        AttackComboResetTimer.Start();
    }

    private void HandleAnimationFinished(StringName animName)
    {
        comboCounter++; 
        comboCounter = Mathf.Wrap(comboCounter, 1, maxComboCount + 1);

        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}