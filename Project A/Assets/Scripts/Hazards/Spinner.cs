using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
	[SerializeField] private float speed = 5;

	[SerializeField] private bool x;
	[SerializeField] private bool y;
	[SerializeField] private bool z;

	private float BoolToInt(bool b) { return (b == true ? 1f : 0f); }

	// Update is called once per frame
	void Update()
	{
		transform.eulerAngles += new Vector3(BoolToInt(x), BoolToInt(y), BoolToInt(z)) * speed * Time.deltaTime;
	}
}
