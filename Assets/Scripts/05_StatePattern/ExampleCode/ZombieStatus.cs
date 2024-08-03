using UnityEngine;

namespace _05_StatePattern.ExampleCode
{
	public class ZombieStatus : CharacterStatus
	{
		[SerializeField] private float maxTrackDistance = 10f;
		[SerializeField] private float maxAttackDistance = 2.3f;
		[SerializeField] private float attackInterval = 1.5f;

		public float MaxTrackDistance => maxTrackDistance;
		public float MaxAttackDistance => maxAttackDistance;
		public float AttackInterval => attackInterval;

	}
}
