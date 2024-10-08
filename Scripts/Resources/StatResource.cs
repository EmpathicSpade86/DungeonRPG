using Godot;
using System;

[GlobalClass] // Exposes the Resource to Godot
public partial class StatResource : Resource
{
    public event Action OnZero; //Creates a Delegate 
    public event Action OnUpdate; //Event for whenever a stat is updated

    [Export] public Stat StatType { get; private set; }

    // The _sameName means that that property is manipulated by other functions (Getters and Setters)
    private float _statValue;
    [Export]
    public float StatValue
    {
        get => _statValue; // Basically creates a public getter
        set
        {
            // value is the intake number that we get from trying to set the variable
            _statValue = Mathf.Clamp(value, 0, Mathf.Inf); // We do this to make sure we don't accept any negative values

            OnUpdate?.Invoke(); //Invoke the OnUpdate Event whenever a stat is changed

            if (_statValue == 0)
            {
                OnZero?.Invoke(); // the ? basically says, if the method is not stored in a variable, do not call it, basically a null check
            }
        }
    }


}