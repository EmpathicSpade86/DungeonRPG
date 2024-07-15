using Godot;
using System;

public partial class EnemyContainer : Node3D
{
    public override void _Ready()
    {
        int totalEnemies = GetChildCount(); // Count all the Nodes to get the number of enemies we have

        GameEvents.RaiseNewEnemyCount(totalEnemies);
        
        ChildExitingTree += HandleChildExitingTree;
    }

    private void HandleChildExitingTree(Node node)
    {
        int totalEnemies = GetChildCount() - 1; // Count all the Nodes to get the number of enemies we have

        GameEvents.RaiseNewEnemyCount(totalEnemies);
    }

}
