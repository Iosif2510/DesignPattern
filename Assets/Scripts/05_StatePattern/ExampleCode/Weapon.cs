using UnityEngine;

namespace _05_StatePattern.ExampleCode
{
	public abstract class Weapon : MonoBehaviour
	{
		protected CharacterStatus holder;
		[SerializeField] protected float damage = 5f;
		public abstract void Attack();

		protected virtual void Awake()
		{
			holder = transform.parent.GetComponent<CharacterStatus>();
		}
	}
}
