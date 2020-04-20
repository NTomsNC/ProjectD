using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour, IDamagable
{
	[SerializeField] private float speed = 5;

	private Rigidbody _rigidbody;
	private Vector3 _moveVelocity;

	// Awake is called when this class is first initialized
	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
		
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		_moveVelocity = new Vector3(x, 0, y).normalized * speed;

		_rigidbody.MovePosition(_rigidbody.position + (_moveVelocity * Time.deltaTime));
	}

	// FixedUpdate is called 30 a second
	private void FixedUpdate()
	{
	}

	// Interface:IDamagable -- Take damage
	public void TakeDamage(IDamage damageSource)
	{
		float damage = damageSource.GetDamage();

		// TODO:(Nathen) Take Damage
		Debug.Log("Taking Damage: " + damage);
	}
}
