using Godot;
using System;

public partial class CameraController : Camera3D
{
    [Export] private Node target; //So we can reparent the camera to any target
    [Export] private Vector3 positionFromTarget; 
    public override void _Ready()
    {
        GameEvents.OnStartGame += HandleGameStart;
    }

    // Move the Camera to the player on the start of the game
    private void HandleGameStart()
    {
        Reparent(target);
        Position = positionFromTarget;
    }
}