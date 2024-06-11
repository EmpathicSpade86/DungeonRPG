using Godot;
using System;

public partial class PlayerController : CharacterBody3D
{
    private Vector2 direction = new Vector2(0, 0);
    public override void _Input(InputEvent @event) //This Method is called only when the player makes an input 
    {
        direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward"); //Take the Input from the Input Map
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(direction.X, 0, direction.Y);
        Velocity *= 5.0f;

        MoveAndSlide(); //Uses the Velocity to Begin moving the player along with the physics engine 
    }
}
