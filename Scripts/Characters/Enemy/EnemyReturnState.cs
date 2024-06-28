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
        destination = globalPos + localPos; //Sets it so that we are using the global position, not the local position
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        SetPhysicsProcess(true);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.GlobalPosition == destination)
        {
            //If the Enemy arrives at the destination
            GD.Print("Reached Destination");
            return;
        }

        characterNode.GlobalPosition.DirectionTo(destination); //Calculates the direction to move the object to

        characterNode.MoveAndSlide();
    }
}