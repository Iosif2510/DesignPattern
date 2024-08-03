using System.Collections;
using UnityEngine;

namespace _05_StatePattern.ExampleCode
{
	public class MeleeWeapon : Weapon
	{
		private bool isAttacking = false;

		[SerializeField] private float attackTime = 1f;

		public bool IsAttacking => isAttacking;

		private Coroutine attackTimer = null;

		private Quaternion initialRotation;

		// Start is called before the first frame update
		void Start()
		{
			initialRotation = transform.localRotation;
		}

		private void Update()
		{
			if (isAttacking)
			{
				transform.localRotation = Quaternion.RotateTowards(initialRotation, Quaternion.Euler(Time.deltaTime * 0.01f, 0, 0), 30);
			}
			else
			{
				transform.localRotation = initialRotation;
			}
		}

		//private void OnTriggerEnter(Collider other)
		//{

		//}

		private void OnTriggerStay(Collider other)
		{
			if (!isAttacking) return;
			if (other.gameObject == holder.gameObject) return;
			if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
			{
				var otherCharacter = other.GetComponent<CharacterStatus>();
				if (otherCharacter != null)
				{
					otherCharacter.GetDamage(damage);
					isAttacking = false;
					if (attackTimer != null) StopCoroutine(attackTimer);
				}
			}
		}

		public override void Attack()
		{
			isAttacking = true;
			attackTimer = StartCoroutine(AttackColliderTimer());
		}

		private IEnumerator AttackColliderTimer()
		{
			yield return new WaitForSeconds(attackTime);
			isAttacking = false;
		}

	}
}
