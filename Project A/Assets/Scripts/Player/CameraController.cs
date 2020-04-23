using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	// A reference to the  payer object
	[SerializeField] private Transform player;

	// The offset the camera should be from the player
	[SerializeField] private Vector3 offset;

	// The Room we are currently in
	// NOTE:(Nathen) If this is null the camera should follow the player
	[HideInInspector] public Room targetRoom;

	// Get the player from the scene
	private void Awake()
	{
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		if (p) player = p.transform;	 
	}

	// Update is called once per frame
	void Update()
	{
		if (player == null) return;

		if (targetRoom)
		{
			Vector3 roomOffset = new Vector3(0, 8.5f, -4);
			Vector3 roomCenter = targetRoom.transform.position + new Vector3(targetRoom.Size.x, 0, -targetRoom.Size.y) / 2;
			Vector3 roomPosition = roomCenter + roomOffset;

			Vector3 targetPos = player.transform.position;

			float side = 8f;
			float top = 6f;
			float bot = 5f;

			// Left and Right
			if (targetRoom.Size.x <= side * 2)
			{
				targetPos.x = roomCenter.x;
			}
			else
			{
				// Left
				if (player.transform.position.x < roomCenter.x - (targetRoom.Size.x / 2) + side)
				{
					targetPos.x = roomCenter.x - targetRoom.Size.x / 2 + side;
				}

				// Right
				if (player.transform.position.x > roomCenter.x + (targetRoom.Size.x / 2) - side)
				{
					targetPos.x = roomCenter.x + targetRoom.Size.x / 2 - side;
				}
			}

			// Up and Down
			if (targetRoom.Size.y <= top + bot)
			{
				targetPos.z = roomCenter.z;
			}
			else
			{
				// Up
				if (player.transform.position.z > roomCenter.z + (targetRoom.Size.y / 2) - top)
				{
					targetPos.z = roomCenter.z + targetRoom.Size.y / 2 - top;
				}

				// Down
				if (player.transform.position.z < roomCenter.z - (targetRoom.Size.y / 2) + bot)
				{
					targetPos.z = roomCenter.z - targetRoom.Size.y / 2 + bot;
				}
			}

			// Move the camera
			transform.position = Vector3.Lerp(transform.position, targetPos + roomOffset, 0.1f);
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, player.position + offset, 0.1f);
		}
	}
}
