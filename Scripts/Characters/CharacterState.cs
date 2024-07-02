using Godot;
using System;


//Abstract makes it so that the class cannot be instantiated. I.E. It cannot be attached to a node (It will throw an error)
//Must Define a Child Class to use this class
public abstract partial class CharacterState : Node
{
    protected Character characterNode; // Protected so children can access, not outside of these classes
    public override void _Ready()
    {
        characterNode = GetOwner<Character>();
        SetPhysicsProcess(false); //Disables the Physics Process Method While the State is Inactive
        SetProcessInput(false); //Disables the Input Method While the State is Inactive
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        //Recieved from the State Machine, will then update the player's State
        if (what == GameConstants.NOTIFCATION_ENTER_STATE)
        {
            EnterState(); // Calls the virtual method that the children have modified, used for animations and such
            //Turns on the node when it is active
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == GameConstants.NOTIFCATION_EXIT_STATE)
        {
            //Deactivates the nodes when its state is deactivated
            SetPhysicsProcess(false);
            SetProcessInput(false);
            //Call the Exit State Method
            ExitState();
        }
    }

    protected virtual void EnterState() { } //Allow for child classes to perform logic while the state is enabled

    protected virtual void ExitState() { } //Perform some set of actions before exiting the state
}