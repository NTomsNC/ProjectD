using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public float Left { get { return transform.position.x - bounds / 2; } }
	public float Right { get { return transform.position.x + bounds / 2; } }
	public float Top { get { return transform.position.z + bounds / 2; } }
	public float Down { get { return transform.position.z - bounds / 2; } }

	[SerializeField] private Vector3 size;
	[SerializeField] private float bounds;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position + Vector3.up * 3, size);

		float s = 6;

		Gizmos.color = Color.blue;
		Gizmos.DrawCube(transform.position + new Vector3(-bounds / 2, 3, 0), new Vector3(0.05f, 0, s));
		Gizmos.DrawCube(transform.position + new Vector3(bounds / 2, 3, 0), new Vector3(0.05f, 0, s));
		Gizmos.DrawCube(transform.position + new Vector3(0, 3, -bounds / 2), new Vector3(s, 0, 0.05f));
		Gizmos.DrawCube(transform.position + new Vector3(0, 3, bounds / 2), new Vector3(s, 0, 0.05f));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player") return;

		if (other.gameObject.TryGetComponent<Player>(out Player player)) {
			player.Camera.targetRoom = this;
		}
	}
}
