using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Arrow : MonoBehaviour, IProjectile, IDamage
{
	[SerializeField] private float speed = 15f;

	[SerializeField] private float damage = 5;
	
	void Awake()
	{
		if (TryGetComponent<Collider>(out Collider collider)) {
			collider.isTrigger = false;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target)) {
			target.TakeDamage(this);
			Destroy(gameObject);
		}
	}

	// (Interface) IProjectile
	public void OnShoot()
	{
		if (TryGetComponent<Rigidbody>(out Rigidbody rigidbody)) {
			rigidbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
			transform.rotation = Quaternion.identity;
		}
	}

	// (Interface) IDamage
	public float GetDamage()
	{
		return damage;
	}
}
