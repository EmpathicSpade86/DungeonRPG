using Godot;
using System;

public abstract partial class EnemyState : CharacterState
{
    protected Vector3 destination;

    protected Vector3 GetPointGlobalPosition(int index) //Function to get the points on the path and move the enemy object along it
    {
        //Get's the first point of the PathNode's Curve and sets it to the destination
        Vector3 localPos = characterNode.PathNode.Curve.GetPointPosition(index); 
        //Retrieves the Global Position of the Path so we can work in Global not Local Position
        Vector3 globalPos = characterNode.PathNode.GlobalPosition;
        //Sets it so that we are using the global position, not the local position
        return globalPos + localPos; 
    }

    protected void Move()
    {
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination); //Calculates the direction to move the object to
        
        characterNode.MoveAndSlide();
    }
}