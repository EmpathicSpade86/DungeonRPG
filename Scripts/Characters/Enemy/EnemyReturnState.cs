using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();
        
        destination = GetPointGlobalPosition(0); //Return to the First point on the Enemy's Path
    }

    protected override void EnterState()
    {
        GD.Print("In Return State");   
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        characterNode.AgentNode.TargetPosition = destination;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.AgentNode.IsNavigationFinished())
        {
            //If the Enemy arrives at the destination
            GD.Print("Reached Destination");
            characterNode.StateMachineNode.SwitchState<EnemyPatrolState>(); //Switch to Patrol State When You Reach Your Destination
            return;
        }

        // GD.Print("Returning");
        // GD.Print(characterNode.GlobalPosition);
        // GD.Print(destination);

        Move();
    }
}