using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour, IDamage
{
	[SerializeField] private float damage = 5;

	// Start is called before the first frame update
	void Awake()
	{
		if (TryGetComponent<Collider>(out Collider collider)) {
			collider.isTrigger = false;
		}
	}

	public float GetDamage()
	{
		return damage;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target)) {
			target.TakeDamage(this);
		}
	}
}
