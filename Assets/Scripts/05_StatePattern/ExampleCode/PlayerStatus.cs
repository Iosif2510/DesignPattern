using UnityEngine;

namespace _05_StatePattern.ExampleCode
{
	public class PlayerStatus : CharacterStatus
	{
		[SerializeField] private float jumpForce = 5;
		public float JumpForce => jumpForce;

		// Start is called before the first frame update
		void Start()
		{
        
		}

		// Update is called once per frame
		void Update()
		{
        
		}
	}
}
