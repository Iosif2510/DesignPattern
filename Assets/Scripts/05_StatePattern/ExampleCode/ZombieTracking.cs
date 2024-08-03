using UnityEngine;
using UnityEngine.AI;

namespace _05_StatePattern.ExampleCode
{
	[RequireComponent(typeof(CharacterStatus)), RequireComponent(typeof(NavMeshAgent))]
	public class ZombieTracking : MonoBehaviour
	{
		public PlayerMovement hero;
		private NavMeshAgent agent;
		private CharacterStatus characterStatus;
		private bool isMoving = true;

		public bool IsMoving => isMoving;

		// Start is called before the first frame update
		void Awake()
		{
			agent = GetComponent<NavMeshAgent>();
			characterStatus = GetComponent<CharacterStatus>();
			characterStatus.onDeath.AddListener(() => { isMoving = false; });
			characterStatus.onDeath.AddListener(DieAnimation);
		}

		private void Update()
		{
			agent.isStopped = !isMoving;
			agent.SetDestination(hero.transform.position);
			if (isMoving)
			{
				agent.speed = characterStatus.MovingSpeed;
			}
		}

		public void SetTrackMode(bool trackMode)
		{
			isMoving = trackMode;
		}

		public void DieAnimation()
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 90), 90);
		}

		public float GetDistanceToTarget()
		{
			//Debug.Log(agent.remainingDistance);
			return agent.remainingDistance;
		}
	}
}
