using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	[SerializeField] private Vector2 size;
	[SerializeField] private float bounds;

	public Vector2 Size { get { return size; } }

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position + new Vector3(size.x / 2, 3.5f, -size.y / 2), new Vector3(size.x, 0, size.y));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player") return;

		if (other.gameObject.TryGetComponent<Player>(out Player player)) {
			player.Camera.targetRoom = this;
		}
	}
}
