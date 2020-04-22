using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private Vector3 offset;

	public Room targetRoom;

	// Update is called once per frame
	void Update()
	{
		if (targetRoom == null) return;

		bool inBounds = CheckBounds();

		if (inBounds)
		{
			print("in");
			transform.position = Vector3.Lerp(transform.position, player.position + offset, 0.1f);
		}
		else
		{
			print("out");
			transform.position = Vector3.Lerp(transform.position, targetRoom.transform.position + offset, 0.1f);
		}
	}

	bool CheckBounds()
	{
		Vector3 pos = player.position;
		if (pos.x > targetRoom.Left && pos.x < targetRoom.Right && pos.z < targetRoom.Top && pos.z > targetRoom.Down) return true;
		return false;
	}
}
