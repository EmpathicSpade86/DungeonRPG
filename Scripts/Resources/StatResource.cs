using Godot;

[GlobalClass] //Exposes the Resource to Godot
public partial class StatResource : Resource
{
    [Export] public Stat StatType { get; private set; }
    [Export] public float StatValue { get; private set; }
}