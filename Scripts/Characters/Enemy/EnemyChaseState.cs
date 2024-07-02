using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    private CharacterBody3D target; //The Player

    [Export] private Timer updateTimer;
    protected override void EnterState()
    {
        GD.Print("Chase State Entered");
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        target = characterNode.ChaseArea.GetOverlappingBodies().First() as CharacterBody3D; //Basically Casts it to CharacterBody3D, can also put (CharacterBody3D) after the '=' 
        //Subscribe to the timer's signal
        updateTimer.Timeout += HandleTimeout;
    }

    protected override void ExitState()
    {
        //Unsubscribe from the timer's signal
        updateTimer.Timeout -= HandleTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        // Move the Enemy
        Move();
    }

    private void HandleTimeout()
    {
        // Updates the Player's position when the timer times out
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;
    }

}