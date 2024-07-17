using Godot;
using System;

public partial class AttackHitBox : Area3D, IHitbox
{
    public float GetDamage()
    {
        return GetOwner<Character>().GetStatResource(Stat.Strength).StatValue; // Grabs the Player's Strength and substarcts the enemy's health by the player's strength
    }
}
