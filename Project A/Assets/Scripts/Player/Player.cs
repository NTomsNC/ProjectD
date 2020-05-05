using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class Player : MonoBehaviour, IDamageable
{
	[SerializeField] private float speed = 5;

	[SerializeField] private float maxLife = 10;
	[SerializeField] private float currentLife = 0;

	private PlayerController _controller;
	private UIPlayer _playerUI;

	public CameraController Camera;

	// Awake is called when this class is first initialized
	void Awake()
	{
		_controller = GetComponent<PlayerController>();
		_playerUI = FindObjectOfType<UIPlayer>();
	}

	private void Start()
	{
		currentLife = maxLife;

		if (_playerUI) { _playerUI.SetLife(1); }	
	}

	// Update is called once per frame
	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Vector3 moveVelocity = new Vector3(x, 0, y).normalized * speed;

		_controller.Move(moveVelocity);
	}

	// Interface:IDamagable -- Take damage
	public void TakeDamage(IDamage damageSource)
	{
		float damage = damageSource.GetDamage();

		currentLife = Mathf.Clamp(currentLife - damage, 0, maxLife);

		// TODO:(Nathen) Take Damage
		Debug.Log("Taking Damage: " + damage);

		// Update the player UI
		if (_playerUI) { _playerUI.SetLife(currentLife / maxLife); }
	}
}
