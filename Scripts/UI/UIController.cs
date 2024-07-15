using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class UIController : Control
{
    private bool canPause = false;
    private Dictionary<ContainerType, UIContainer> containers;

    public override void _Ready()
    {
        containers = GetChildren().Where((element) => element is UIContainer).Cast<UIContainer>().ToDictionary((element) => element.container);

        /**
            GetChildren(): This method gets all children of the UIController node.
            Where((element) => element is UIContainer): This LINQ method filters the children to only those that are of type UIContainer.
            Cast<UIContainer>(): This casts the filtered elements to type UIContainer.
            ToDictionary((element) => element.container): This converts the cast elements into a dictionary, using the container property of each UIContainer as the key.
        **/

        containers[ContainerType.Start].Visible = true;
        containers[ContainerType.Start].buttonNode.Pressed += HandleStartPressed;
        //Listen for when the game finishes
        GameEvents.OnEndGame += HandleGameEnd;
        GameEvents.OnVictory += HandleVictory;
        containers[ContainerType.Pause].buttonNode.Pressed += HandlePausePressed;
    }

    public override void _Input(InputEvent @event)
    {
        if (!canPause) { return; } //If the Player Cannot Pause, don't

        if (!Input.IsActionJustPressed(GameConstants.INPUT_PAUSE))
        {
            return;
        }
        else
        {
            //Switch between the Pause Menu and not when pausing and unpausing
            containers[ContainerType.Stats].Visible = GetTree().Paused;
            GetTree().Paused = !GetTree().Paused;
            containers[ContainerType.Pause].Visible = GetTree().Paused;

        }
    }

    private void HandleStartPressed()
    {
        //Allow the Player to pause the game
        canPause = true;
        //Unpause the Game
        GetTree().Paused = false;
        //Hide the Start Menu
        containers[ContainerType.Start].Visible = false;
        //Display the Stats
        containers[ContainerType.Stats].Visible = true;
        //Tell the Game that we have started
        GameEvents.RaiseStartGame();
    }
    private void HandleGameEnd()
    {
        //Disallow the Player to pause the game
        canPause = true;
        //Disable the Stats, display the defeatScreen
        containers[ContainerType.Stats].Visible = false;
        containers[ContainerType.Defeat].Visible = true;

    }
    private void HandleVictory()
    {
        //Disallow the Player to pause the game
        canPause = true;
        //Disable the Stats, display the Victory Screen
        containers[ContainerType.Stats].Visible = false;
        containers[ContainerType.Victory].Visible = true;

        //Pause the Game After Winning
        GetTree().Paused = true;
    }

    private void HandlePausePressed()
    {
        GetTree().Paused = false;
        containers[ContainerType.Pause].Visible = false;
        containers[ContainerType.Stats].Visible = true;
    }

}
