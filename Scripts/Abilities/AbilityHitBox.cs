using Godot;
using System;

public partial class AbilityHitBox : Area3D, IHitbox
{
    public float GetDamage() => GetOwner<BombController>().damage; //Get the bomb's damage
}
