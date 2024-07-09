using Godot;
using System;
using System.IO;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats;

    [ExportGroup("Required Nodes")] // Groups all the Exported Attributes Below it into a Group in the Godot Editor
    [Export] public Sprite3D SpriteNode { get; private set; }
    [Export] public AnimationPlayer AnimationPlayerNode { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }
    [Export] public Area3D HurtBox { get; private set; }

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
        GD.Print($"{area.Name} hit"); //area.Name + " hit"
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) { return; }

        bool isMovingLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMovingLeft;
    }

}