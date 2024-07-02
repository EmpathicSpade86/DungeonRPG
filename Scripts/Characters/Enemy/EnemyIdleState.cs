using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);

        //Subscribe to Entering the Chase State when the Player gets within range
        characterNode.ChaseArea.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        characterNode.ChaseArea.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }

}
