using Godot;
using System;
using System.Linq;

public partial class EnemyAttackState : EnemyState
{
    private Vector3 targetPosition;
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK);
        Node3D target = characterNode.AttackArea.GetOverlappingBodies().First(); //Get's the first Node3D object

        targetPosition = target.GlobalPosition;
    }

    protected override void ExitState()
    {

    }

    private void PerformHit()
    {
        characterNode.ToggleHitBox(false);

        

        characterNode.HitBoxNode.GlobalPosition = targetPosition;
    }
}