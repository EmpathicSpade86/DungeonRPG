using Godot;
using System;

public partial class CameraController : Camera3D
{
    [Export] private Node target; //So we can reparent the camera to any target
    [Export] private Vector3 positionFromTarget;
    public override void _Ready()
    {
        //Subscribe to the Game Start and Game End Events when the Game Starts
        GameEvents.OnStartGame += HandleGameStart;
        GameEvents.OnEndGame += HandleGameEnd;
    }

    // Move the Camera to the player on the start of the game
    private void HandleGameStart()
    {
        Reparent(target);
        Position = positionFromTarget;
    }

    private void HandleGameEnd()
    {
        Reparent(GetTree().CurrentScene); //CurrentScene Returns the root node of the scene
        
    }
}