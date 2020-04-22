using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Arrow : MonoBehaviour, IProjectile
{
	[SerializeField] private float speed = 15f;

	public void Shoot()
	{
		if (TryGetComponent<Rigidbody>(out Rigidbody rigidbody)) {
			rigidbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
			transform.rotation = Quaternion.identity;
		}
	}
}
