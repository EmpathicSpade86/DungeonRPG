using Godot;
using System;
using System.IO;
// LINQ is used for iterating and looking through Data
using System.Linq;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats;

    [ExportGroup("Required Nodes")] // Groups all the Exported Attributes Below it into a Group in the Godot Editor
    [Export] public Sprite3D SpriteNode { get; private set; }
    [Export] public AnimationPlayer AnimationPlayerNode { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }
    [Export] public Area3D HurtBox { get; private set; }
    [Export] public Area3D HitBoxNode { get; private set; }
    [Export] public CollisionShape3D HitBoxShapeNode { get; private set; }

    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode { get; private set; }
    [Export] public NavigationAgent3D AgentNode { get; private set; }
    [Export] public Area3D ChaseArea { get; private set; }
    [Export] public Area3D AttackArea { get; private set; }

    public Vector2 direction = new Vector2(0, 0);
    public override void _Ready()
    {
        HurtBox.AreaEntered += HandleHurtBoxEntered;
    }

    private void HandleHurtBoxEntered(Area3D area)
    {
        // GD.Print($"{area.Name} hit"); //area.Name + " hit"
        StatResource health = GetStatResource(Stat.Health); // Look for the Stat.Health method 

        Character player = area.GetOwner<Character>(); //Get the Root node of the area, the Player is Inherited from the Character Class

        health.StatValue -= player.GetStatResource(Stat.Strength).StatValue; // Grabs the Player's Strength and substarcts the enemy's health by the player's strength

        GD.Print(health.StatValue);
    }

    public StatResource GetStatResource(Stat getStat)
    {
        StatResource result = stats.Where((element) => element.StatType == getStat).FirstOrDefault();

        // Below does the same as above, above uses LINQ

        // StatResource result = null;
        // // Loop through all the stats until you get the one you're looking for
        // foreach (StatResource element in stats)
        // {
        //     if(element.StatType == getStat)
        //     {
        //         result = element;
        //     }
        // }

        return result;
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) { return; }

        bool isMovingLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMovingLeft;

    }

    public void ToggleHitBox (bool flag)
    {
        HitBoxShapeNode.Disabled = flag;
    }

}