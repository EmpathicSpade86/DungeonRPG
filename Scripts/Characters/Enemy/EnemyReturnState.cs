using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 destination;

    public override void _Ready()
    {
        base._Ready();
        Vector3 localPos = characterNode.PathNode.Curve.GetPointPosition(0); //Get's the first point of the PathNode's Curve and sets it to the destination
        Vector3 globalPos = characterNode.PathNode.GlobalPosition;
        destination = localPos + globalPos; //Sets it so that we are using the global position, not the local position
    }

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);


        characterNode.GlobalPosition = destination; 
        SetPhysicsProcess(true);
    }

    public override void _PhysicsProcess(double delta)
    {
        
    }
}