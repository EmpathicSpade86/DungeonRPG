using Godot;
using System;

public partial class PlayerController : CharacterBody3D
{
    [ExportGroup("Required Nodes")] // Groups all the Exported Attributes Below it into a Group in the Godot Editor
    [Export] private Sprite3D characterSprite;
    [Export] private AnimationPlayer animationPlayer;
    private Vector2 direction = new Vector2(0, 0);

    public override void _Ready()
    {

        if (animationPlayer != null)
        {
            animationPlayer.Play("Idle");
        }

    }

    public override void _Input(InputEvent @event) //This Method is called only when the player makes an input 
    {
        direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward"); //Take the Input from the Input Map

        //Change the Animation of the Player based on the Player Input
        if (direction == Vector2.Zero)
        {
            animationPlayer.Play("Idle");
        }
        else
        {
            animationPlayer.Play("Running");
        }

    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(direction.X, 0, direction.Y);
        Velocity *= 5.0f;

        MoveAndSlide(); //Uses the Velocity to Begin moving the player along with the physics engine 
    }
}
