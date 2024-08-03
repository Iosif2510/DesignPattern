using System.Collections.Generic;
using UnityEngine;

namespace _05_StatePattern.ExampleCode
{
	[RequireComponent(typeof(StateMachine))]
	public class ZombieStateController : MonoBehaviour
	{
		private StateMachine stateMachine;
		private ZombieStatus zombieStatus;
		private ZombieTracking zombieTracking;
		private MeleeWeapon zombieWeapon;

		private Dictionary<ZombieState.ZombieStateEnum, ZombieState> zombieStates;

		private ZombieIdleState idleState = new();
		private ZombieTrackState trackState = new();
		private ZombieAttackState attackState = new();
		private ZombieDeathState deathState = new();

		// Start is called before the first frame update
		void Awake()
		{
			stateMachine = GetComponent<StateMachine>();
			zombieStatus = GetComponent<ZombieStatus>();
			zombieTracking = GetComponent<ZombieTracking>();
			zombieWeapon = GetComponentInChildren<MeleeWeapon>();
			zombieStates = new()
			{
				{ ZombieState.ZombieStateEnum.Idle, idleState },
				{ ZombieState.ZombieStateEnum.Track, trackState },
				{ ZombieState.ZombieStateEnum.Attack, attackState },
				{ ZombieState.ZombieStateEnum.Death, deathState }
			};

			foreach (var state in zombieStates)
			{
				state.Value.Initialize(stateMachine, zombieStatus, zombieTracking);
				if (state.Value is ZombieAttackState attackState) attackState.weapon = zombieWeapon;
				stateMachine.stateList.Add(state.Value);
			}

        
		}

		private void Start()
		{
			stateMachine.StartMachine(idleState);
		}

		// Update is called once per frame
		void Update()
		{
        
		}
	}
}
