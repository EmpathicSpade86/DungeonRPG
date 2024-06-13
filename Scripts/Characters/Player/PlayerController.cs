using Godot;
using System;

public partial class PlayerController : CharacterBody3D
{
    [ExportGroup("Required Nodes")] // Groups all the Exported Attributes Below it into a Group in the Godot Editor
    [Export] public Sprite3D characterSprite;
    [Export] public AnimationPlayer animationPlayer;
    [Export] public StateMachine stateMachine;
    public Vector2 direction = new Vector2(0, 0);

    public override void _Ready()
    {
    }

    public override void _Input(InputEvent @event) //This Method is called only when the player makes an input 
    {
        direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD); //Take the Input from the Input Map
        
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(direction.X, 0, direction.Y);
        Velocity *= 5.0f;

        MoveAndSlide(); //Uses the Velocity to Begin moving the player along with the physics engine 
        Flip();
    }

    private void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) { return; }

        bool isMovingLeft = Velocity.X < 0;
        characterSprite.FlipH = isMovingLeft;
    }
}
