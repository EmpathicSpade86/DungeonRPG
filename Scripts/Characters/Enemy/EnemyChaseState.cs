using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    private CharacterBody3D target; // The Player

    [Export] private Timer updateTimer;
    protected override void EnterState()
    {
        GD.Print("Chase State Entered");
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        target = characterNode.ChaseArea.GetOverlappingBodies().First() as CharacterBody3D; // Basically Casts it to CharacterBody3D, can also put (CharacterBody3D) after the '=' 
        //S ubscribe to the timer's signal
        updateTimer.Timeout += HandleTimeout;
        // Subscribe to the BodyEntered Event to Detect the Player
        // Transition from the Chase State to the Attack State
        characterNode.AttackArea.BodyEntered += HandleAttackAreaBodyEntered;
        // Make it so the Enemy will stop chasing the player after they leave the chase area
        characterNode.ChaseArea.BodyExited += HandleChaseAreaBodyExited;
    }
    protected override void ExitState()
    {
        // Unsubscribe from the timer's signal
        updateTimer.Timeout -= HandleTimeout;
        // Unsubscribe from the Area's Signal so we don't bring it with us to another state
        characterNode.AttackArea.BodyEntered -= HandleAttackAreaBodyEntered;
        // Unsubscribe from the BodyExited Signal
        characterNode.ChaseArea.BodyExited -= HandleChaseAreaBodyExited;
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

    private void HandleAttackAreaBodyEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
    }

    private void HandleChaseAreaBodyExited(Node3D body)
    {
        //Have the enemy return to their patrol path
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }

}