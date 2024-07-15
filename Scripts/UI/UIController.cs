using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class UIController : Control
{
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

        
        
    }

    private void HandleStartPressed()
    {
        //Unpause the Game
        GetTree().Paused = false;
        //Hide the Start Menu
        containers[ContainerType.Start].Visible = false;
        //Display the Stats
        containers[ContainerType.Stats].Visible = true;
        //Tell the Game that we have started
        GameEvents.RaiseStartGame();
    }

}
