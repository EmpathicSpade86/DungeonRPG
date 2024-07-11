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
        //Subscribe to the Animation Finished Signal
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        characterNode.AnimationPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void PerformHit()
    {
        characterNode.ToggleHitBox(false);

        characterNode.HitBoxNode.GlobalPosition = targetPosition;
    }
    private void HandleAnimationFinished(StringName animName)
    {
        //Disable the Hitbox
        characterNode.ToggleHitBox(true);
        // Get the Player again and attempt to attack them again
        Node3D target = characterNode.AttackArea.GetOverlappingBodies().FirstOrDefault();

        // If the Player is outside the attack area
        if (target == null)
        {
            //If they are in the chase area, chase them
            Node3D chaseTarget = characterNode.ChaseArea.GetOverlappingBodies().FirstOrDefault(); //Same again, see if there are any targets in the chase area
            if (chaseTarget == null)
            {
                characterNode.StateMachineNode.SwitchState<EnemyReturnState>(); //Enter Return state if not
            }
            else //If the player is in the chase area still
            {
                characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
            }

            return;
        }


        // If the Player is there, attack the Player again
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK);
        targetPosition = target.GlobalPosition;

        //Change the Way the Sprite is facing
        Vector3 direction = characterNode.GlobalPosition.DirectionTo(targetPosition);
        characterNode.SpriteNode.FlipH = direction.X < 0;

    }
}