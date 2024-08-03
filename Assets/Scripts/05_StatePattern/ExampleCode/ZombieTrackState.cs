namespace _05_StatePattern.ExampleCode
{
	public class ZombieTrackState : ZombieState
	{
		public override void Enter()
		{
			zombieTracking.SetTrackMode(true);
		}

		public override void Exit()
		{
		}

		public override void Update()
		{
			base.Update();
			if (zombieTracking.GetDistanceToTarget() > status.MaxTrackDistance)
			{
				stateMachine.TransitionTo((int)ZombieStateEnum.Idle);
			}
			else if (zombieTracking.GetDistanceToTarget() <= status.MaxAttackDistance)
			{
				stateMachine.TransitionTo((int)ZombieStateEnum.Attack);
			}
		}
	}
}
