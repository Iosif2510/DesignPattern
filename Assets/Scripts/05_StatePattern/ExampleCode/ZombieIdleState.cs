namespace _05_StatePattern.ExampleCode
{
	public class ZombieIdleState : ZombieState
	{
		public override void Enter()
		{
			zombieTracking.SetTrackMode(false);
		}

		public override void Exit()
		{
		}

		public override void Update()
		{
			base.Update();
			if (zombieTracking.GetDistanceToTarget() <= status.MaxTrackDistance)
			{
				stateMachine.TransitionTo((int)ZombieStateEnum.Track);
			}
		}
	}
}
