using Godot;
using System;

public partial class PlayerController : Character
{
    public override void _Ready()
    {
        base._Ready();
    }

    public override void _Input(InputEvent @event) //This Method is called only when the player makes an input 
    {
        direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD); //Take the Input from the Input Map 
    }

    public override void _PhysicsProcess(double delta)
    {

    }

}
