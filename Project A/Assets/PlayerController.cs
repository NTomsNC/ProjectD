using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private Vector3 _velocity;

	// Start is called before the first frame update
	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void Move(Vector3 velocity)
	{
		_velocity = velocity;
	}

	private void FixedUpdate() {
		_rigidbody.MovePosition(_rigidbody.position + _velocity * Time.fixedDeltaTime);
	}
}
