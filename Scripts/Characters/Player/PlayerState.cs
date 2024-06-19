using Godot;
using System;


//Abstract makes it so that the class cannot be instantiated. I.E. It cannot be attached to a node (It will throw an error)
//Must Define a Child Class to use this class
public abstract partial class PlayerState : Node
{
    protected PlayerController characterNode; // Protected so children can access, not outside of these classes
    public override void _Ready()
    {
        characterNode = GetOwner<PlayerController>();
        SetPhysicsProcess(false); //Disables the Physics Process Method While the State is Inactive
        SetProcessInput(false); //Disables the Input Method While the State is Inactive
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        //Recieved from the State Machine, will then update the player's State
        if (what == 5001)
        {
            EnterState(); // Calls the virtual method that the children have modified, used for animations and such
            //Turns on the node when it is active
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == 5002)
        {
            //Deactivates the nodes when its state is deactivated
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }

    protected virtual void EnterState() { } //Allow for child classes to perform logic while the state is enabled
}