using System;

public class GameEvents
{
    public static event Action OnStartGame;  
    //Event Keyword adds an extra layer of protection so we don't overwrite any of the events, technically it is optional
    //Static means that you can access this variable without having to create an instance of the class, but can change
    public static void RaiseStartGame() => OnStartGame?.Invoke(); //Raise is a naming Convention where we tell the WHOLE game something in this case, the game has started

    public static event Action OnEndGame;
    public static void RaiseEndGame() => OnEndGame?.Invoke();

    public static event Action<int> OnNewEnemyCount; //the <int> (Interger Generic) forces any methodsregistered to the event to have an int parameter
    public static void RaiseNewEnemyCount(int count) => OnNewEnemyCount?.Invoke(count);

    public static event Action OnVictory;
    public static void RaiseVictory() => OnVictory?.Invoke();

}
