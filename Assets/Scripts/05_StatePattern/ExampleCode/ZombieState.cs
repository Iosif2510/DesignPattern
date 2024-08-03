namespace _05_StatePattern.ExampleCode
{
	public abstract class ZombieState : IState
	{
		public enum ZombieStateEnum
		{
			Idle,
			Track,
			Attack,
			Death
		}

		protected StateMachine stateMachine;

		protected ZombieStatus status;
		protected ZombieTracking zombieTracking;

		public void Initialize(StateMachine machine, ZombieStatus status, ZombieTracking zombieTracking)
		{
			this.status = status;
			this.stateMachine = machine;
			this.zombieTracking = zombieTracking;
		}

		public abstract void Enter();

		public abstract void Exit();

		public virtual void Update()
		{
			if (status.Health <= 0)
			{
				stateMachine.TransitionTo((int)ZombieStateEnum.Death);
			}
		}
	}
}
