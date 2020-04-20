using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour, IDamage
{
	[SerializeField] private float damage = 5;

	public float GetDamage()
	{
		return damage;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<IDamagable>(out IDamagable target)) {
			target.TakeDamage(this);

			// TODO:(Nathen) Add Knockback to either the player
		}
	}
}
