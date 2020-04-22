using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWall : MonoBehaviour
{
	[SerializeField] private float range = 5;
	[SerializeField] private float interval = 2;

	[SerializeField] private GameObject projectile;

	private float _timer = 0;

	// Update is called once per frame
	void Update()
	{
		if ((_timer += Time.deltaTime) < interval) return;

		if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range)) {
			if (Instantiate(projectile, transform.position, transform.rotation).TryGetComponent<IProjectile>(out IProjectile shot))
			{
				shot.Shoot();
			}
			_timer = 0;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * range);
	}
}
