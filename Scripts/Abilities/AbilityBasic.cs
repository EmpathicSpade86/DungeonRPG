using Godot;
using System;

public abstract partial class AbilityBasic : Node3D
{
    [Export] protected AnimationPlayer animationPlayer;
    [Export(PropertyHint.Range, "0,100,1")] public float damage { get; private set; } = 10.0f;

    
}