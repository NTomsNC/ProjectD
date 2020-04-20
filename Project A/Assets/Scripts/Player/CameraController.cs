using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offset;

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, target.position + offset, 0.25f);
	}
}
