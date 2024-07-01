using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    private int pointIndex = 0;
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);

        //Move to the Second Position on the path (Enter's patrol state from the Return state which starts at 0)
        pointIndex = 1;
        destination = GetPointGlobalPosition(pointIndex);

        characterNode.AgentNode.TargetPosition = destination;

        characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
    }
    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    private void HandleNavigationFinished()
    {
        //Calculate the next position
        pointIndex = Mathf.Wrap(pointIndex + 1, 0, characterNode.PathNode.Curve.PointCount);

        //Move the Character to the new destination
        destination = GetPointGlobalPosition(pointIndex); 
        characterNode.AgentNode.TargetPosition = destination; 
    }
}