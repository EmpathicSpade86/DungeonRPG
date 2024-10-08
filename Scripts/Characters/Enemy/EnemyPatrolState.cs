using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    [Export] private Timer IdleTimerNode; //Timer for pausing
    [Export(PropertyHint.Range, "0,20,0.1")] private float maxIdleTime = 4.0f;
    private int pointIndex = 0;
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);

        //Move to the Second Position on the path (Enter's patrol state from the Return state which starts at 0)
        pointIndex = 1;
        destination = GetPointGlobalPosition(pointIndex);

        characterNode.AgentNode.TargetPosition = destination;

        //Subscribe to the Handle Navigation Function Finished with the Navigation Finished Signal
        characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
        IdleTimerNode.Timeout += HandleTimeout;

        //Subscribe to Entering the Chase State when the Player gets within range
        characterNode.ChaseArea.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        base.ExitState();
        //Unsubscribe from the signal when Exiting the state
        characterNode.AgentNode.NavigationFinished -= HandleNavigationFinished;
        IdleTimerNode.Timeout -= HandleTimeout;

        //Unsubscribe from the Body Entered Signal
        characterNode.ChaseArea.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        //If the Timer is running
        if (!IdleTimerNode.IsStopped())
        {
            //Then Do nothing
            return;
        }
        Move();
    }

    private void HandleNavigationFinished()
    {
        //Pause at the Location for a few seconds
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
        RandomNumberGenerator rng = new RandomNumberGenerator();
        IdleTimerNode.WaitTime = rng.RandfRange(0, maxIdleTime);
        IdleTimerNode.Start();
    }

    private void HandleTimeout()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        //Calculate the next position
        pointIndex = Mathf.Wrap(pointIndex + 1, 0, characterNode.PathNode.Curve.PointCount);

        //Move the Character to the new destination
        destination = GetPointGlobalPosition(pointIndex);
        characterNode.AgentNode.TargetPosition = destination;
    }
}