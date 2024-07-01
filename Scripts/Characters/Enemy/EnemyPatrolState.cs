using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        
        //Move to the Second Position on the path (Enter's patrol state from the Return state which starts at 0)
        destination = GetPointGlobalPosition(1); 

        characterNode.AgentNode.TargetPosition = destination;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
}