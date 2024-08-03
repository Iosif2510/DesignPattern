using UnityEngine;
using UnityEngine.Events;

namespace _05_StatePattern.ExampleCode
{
	public class CharacterStatus : MonoBehaviour
	{
		[SerializeField] private float maxHealth = 100;		// 최대 체력
		[SerializeField] private float health = 100;		// 현재 체력
		[SerializeField] private float movingSpeed = 5;     // 이동 속도
		[SerializeField] private ParticleSystem bloodSFX;
	
		public float MaxHealth => maxHealth;
		public float Health => health;
		public float MovingSpeed => movingSpeed;

		private bool isAlive = true;	// 살아있음 여부
		public bool IsAlive => isAlive;
		public UnityEvent onDeath;

		// Start is called before the first frame update
		void Start()
		{
        
		}

		public void ChangeHealth(float healthChange)
		{
			// healthChange > 0: 회복, healthChange < 0: 피해
			health += healthChange;
			if (health > maxHealth) { health = maxHealth; }
			else if (health <= 0) Die();
		}

		public void Heal(float healAmount)
		{
			if (healAmount > 0) { ChangeHealth(healAmount); }
		}

		public void GetHit(float damage, RaycastHit hit)
		{
			GetDamage(damage);
			bloodSFX.transform.SetPositionAndRotation(hit.point, Quaternion.Euler(hit.normal));
			bloodSFX.Play();
		}

		public void GetDamage(float damage)
		{
			if (damage > 0) { ChangeHealth(-damage); }
		}

		private void Die()
		{
			isAlive = false;
			onDeath?.Invoke();
		}
	}
}
