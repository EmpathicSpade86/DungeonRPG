using Godot;
using System;

public partial class PlayerController : CharacterBody3D
{
    [ExportGroup("Required Nodes")] // Groups all the Exported Attributes Below it into a Group in the Godot Editor
    [Export] public Sprite3D CharacterSpriteNode { get; private set; }
    [Export] public AnimationPlayer AnimationPlayerNode { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }
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

    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) { return; }

        bool isMovingLeft = Velocity.X < 0;
        CharacterSpriteNode.FlipH = isMovingLeft;
    }
}
