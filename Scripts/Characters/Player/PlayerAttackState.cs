using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer AttackComboResetTimer; 
    [Export] float attackAnimationSpeed = 1.5f;

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
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK + comboCounter, -1, attackAnimationSpeed); //This is how we're going to play the different animations, Player's attack animations are labeled 'Attack1' and 'Attack2'
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

        characterNode.ToggleHitBox(true);

        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();

    }

    private void PerformHit()
    {
        Vector3 newPosition = characterNode.SpriteNode.FlipH ? Vector3.Left : Vector3.Right; // Turnary Operator, basically an if statment, if FlipH is true, it will set newPosition to Vector3.Left, if false Vector3.Right

        float distanceMultiplier = .75f;
        newPosition *= distanceMultiplier;

        characterNode.HitBoxNode.Position = newPosition;

        characterNode.ToggleHitBox(false); //This actually will enable the hitbox, it is because the property itself is called 'Disabled', so we are disabling the disabler

    }
}