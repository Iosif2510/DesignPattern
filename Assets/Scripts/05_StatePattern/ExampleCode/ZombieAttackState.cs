using UnityEngine;

namespace _05_StatePattern.ExampleCode
{
	public class ZombieAttackState : ZombieState
	{
		private float attackTimer = 0;
		public MeleeWeapon weapon;

		public override void Enter()
		{
			Attack();
			attackTimer = 0;
			zombieTracking.SetTrackMode(true);
		}

		public override void Exit()
		{
		}

		public override void Update()
		{
			base.Update();
			attackTimer += Time.deltaTime;
			if (attackTimer >= status.AttackInterval)
			{
				Attack();
				attackTimer = 0;
			}
			if (zombieTracking.GetDistanceToTarget() > status.MaxAttackDistance)
			{
				stateMachine.TransitionTo((int)ZombieStateEnum.Track);
			}
		}

		private void Attack()
		{
			//weapon.Attack();
		}
	}
}
