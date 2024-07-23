using Godot;
using System;

public partial class EnemyController : Character
{
    //Detect when hit by hitbox
    public override void _Ready()
    {
        base._Ready();
        HurtBox.AreaEntered += HandleAreaEntered;
    }

    private void HandleAreaEntered(Area3D area)
    {
        if (area is not IHitbox hitbox)
        {
            return;
        }

        if (hitbox.CanStun() && GetStatResource(Stat.Health).StatValue != 0)
        {
            //Stun the Enemy
            StateMachineNode.SwitchState<EnemyStunState>();
        }
    }

}
