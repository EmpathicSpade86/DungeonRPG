using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimer;
    [Export] private float dashSpeed = 10.0f;
    public override void _Ready()
    {
        base._Ready(); //Call the base method from the PlayerState class
        dashTimer.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        //Call the Move and Slide Method to move the Player
        characterNode.MoveAndSlide();
        //Call the Flip Method
        characterNode.Flip();
    }

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.animationPlayer.Play(GameConstants.ANIM_DASH); //Play the Dash Animation
        characterNode.Velocity = new Vector3(characterNode.direction.X, 0, characterNode.direction.Y); //Grabs the player's current move direction

        if (characterNode.Velocity == Vector3.Zero)
        {
            characterNode.Velocity = characterNode.characterSprite.FlipH ? //Checking the Sprite's FlipH Property
                Vector3.Left : // if it is enabled, the player is facing left, then it will set the velocity to Vector3.Left
                Vector3.Right; // if it is disabled, the player is facing right, then it will set the velocity to Vector3.right 

            //Alternative Method that does the same thing
            /*
            if(characterNode.characterSprite.FlipH){
                characterNode.Velocity = Vector3.Left;
            }else{
                characterNode.Velocity = Vector3.Right;
            }
            */

        }

        characterNode.Velocity *= dashSpeed; //Apply the dash speed to the Player
        dashTimer.Start(); //Start the Timer when you switch to the State

    }

    private void HandleDashTimeout()
    {
        //What to do when the Timer Reaches 0
        characterNode.Velocity = Vector3.Zero; //Reset the Velocity after the Timer Runs out
        characterNode.stateMachine.SwitchState<PlayerIdleState>();
    }
}
