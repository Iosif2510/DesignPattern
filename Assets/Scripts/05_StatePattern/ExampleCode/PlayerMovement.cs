using UnityEngine;

namespace _05_StatePattern.ExampleCode
{
	[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(PlayerStatus))]
	public class PlayerMovement : MonoBehaviour
	{
		private PlayerStatus playerState;

		private Rigidbody rb;

		private bool isMoving = true;

		// Start is called before the first frame update
		void Awake()
		{
			rb = GetComponent<Rigidbody>();
			playerState = GetComponent<PlayerStatus>();
			playerState.onDeath.AddListener(() => { isMoving = false; });
			playerState.onDeath.AddListener(DieAnimation);
		}

		public void MoveAround(Vector3 movingVector)
		{
			if (!isMoving) return;
			rb.MovePosition(rb.position + Time.deltaTime * playerState.MovingSpeed * movingVector);
			// Debug.Log($"Rigidbody Velocity: {Time.deltaTime * movingSpeed * movingVector}");
		}

		public void Jump()
		{
			if (!isMoving) return;
			rb.AddForce(Vector3.up * playerState.JumpForce, ForceMode.Impulse);
		}

		public void DieAnimation()
		{
			rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, Quaternion.Euler(0, 0, 90), 90));
		}
	}
}
