using Godot;
using System;

public partial class EnemyStunState : EnemyState
{
    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_STUN);
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        if (characterNode.AttackArea.HasOverlappingBodies())
        {
            characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
        }
        else if (characterNode.ChaseArea.HasOverlappingBodies())
        {
            characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
        }
        else
        {
            characterNode.StateMachineNode.SwitchState<EnemyIdleState>();
        }
    }

    protected override void ExitState()
    {
        base.ExitState();
        characterNode.AnimationPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }
}
