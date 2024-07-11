using Godot;
using System;

[GlobalClass] // Exposes the Resource to Godot
public partial class StatResource : Resource
{
    public Action OnZero; //Creates a Delegate 

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

            if (_statValue == 0)
            {
                OnZero?.Invoke(); // the ? basically says, if the method is not stored in a variable, do not call it, basically a null check
            }
        }
    }


}