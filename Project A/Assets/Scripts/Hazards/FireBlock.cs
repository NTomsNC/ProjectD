using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlock : MonoBehaviour, IDamage
{
	[SerializeField] private float damage = 10;

	public float GetDamage()
	{
		return damage;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<IDamagable>(out IDamagable target))
		{
			target.TakeDamage(this);
		}
	}
}
