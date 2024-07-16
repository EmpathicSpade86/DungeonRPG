using Godot;
using System;

public partial class TreasureChest : StaticBody3D
{
    [Export] private Area3D playerDetectArea;
    [Export] private Sprite3D iconNode;
    [Export] private RewardResource reward;

    public override void _Ready()
    {
        //Subscribe to these signals, show the icon when the player is close
        playerDetectArea.BodyEntered += (body) => iconNode.Visible = true;
        playerDetectArea.BodyExited += (body) => iconNode.Visible = false;


    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (Input.IsActionJustPressed(GameConstants.INPUT_INTERACT) && iconNode.Visible) //If the Area has overlapping and the player has interacted 
        {
            GD.Print("Interacted");
            return;
        }
        
    }
}
