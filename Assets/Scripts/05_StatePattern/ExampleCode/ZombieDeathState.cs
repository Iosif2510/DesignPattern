namespace _05_StatePattern.ExampleCode
{
	public class ZombieDeathState : ZombieState
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
		}
	}
}
