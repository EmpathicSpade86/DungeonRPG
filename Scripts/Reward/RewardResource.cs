using Godot;
using System;

[GlobalClass] //Allows it to add the resource from the Godot Editor
public partial class RewardResource : Resource
{
    //Image
    [Export] public Texture2D SpriteTexture { get; private set; }
    //Description for the Reward
    [Export] public string Description { get; private set; }
    //What Stat to update
    [Export] public Stat TargetStat { get; private set; }
    //Bonus Amount (How much should it increase)
    [Export(PropertyHint.Range, "1,100,1")] public float Amount { get; private set; }
}