using System;

public class GameEvents
{
    public static Action OnStartGame; 
    //Static means that you can access this variable without having to create an instance of the class, but can change
    public static void RaiseStartGame() => OnStartGame?.Invoke(); //Raise is a naming Convention where we tell the WHOLE game something in this case, the game has started
}
