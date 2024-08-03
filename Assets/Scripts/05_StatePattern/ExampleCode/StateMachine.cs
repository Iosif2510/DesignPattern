using System.Collections.Generic;
using UnityEngine;

namespace _05_StatePattern.ExampleCode
{
	public class StateMachine : MonoBehaviour
	{
		public IState CurrentState { get; private set; }

		public List<IState> stateList = new List<IState>();

		public void InitStates(params IState[] states)
		{
			foreach (var state in states)
			{
				stateList.Add(state);
			}
		}

		public void StartMachine(IState startState)
		{
			CurrentState = startState;
			startState.Enter();
		}

		private void Update()
		{
			if (CurrentState != null) CurrentState.Update();
		}

		public void TransitionTo(IState nextState)
		{
			CurrentState.Exit();
			CurrentState = nextState;
			CurrentState.Enter();
		}

		public void TransitionTo(int stateNumber)
		{
			TransitionTo(stateList[stateNumber]);
		}

	}
}
