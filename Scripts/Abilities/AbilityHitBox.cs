using Godot;
using System;

public partial class AbilityHitBox : Area3D, IHitbox
{
    public bool CanStun()
    {
        return true;
    }


    public float GetDamage() => GetOwner<AbilityBasic>().damage; //Get the Ability's damage
}
