using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class DamageOverTime : MonoBehaviour, IDamage
{
	[SerializeField] private float damage = 5;

	public List<IDamageable> targets = new List<IDamageable>();

	// Start is called before the first frame update
	void Awake()
	{
		if (TryGetComponent<Collider>(out Collider collider)) {
			collider.isTrigger = true;
		}
	}

	// Update is called once per frame
	private void Update()
	{
		foreach (IDamageable target in targets)
		{
			target.TakeDamage(this);
		}
	}

	// Get the damage of this object
	public float GetDamage()
	{
		return damage * Time.deltaTime;
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<IDamageable>(out IDamageable target)) {
			targets.Add(target);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent<IDamageable>(out IDamageable target)) {
			if (targets.Contains(target))
			{
				targets.Remove(target);
			}
		}
	}
}
