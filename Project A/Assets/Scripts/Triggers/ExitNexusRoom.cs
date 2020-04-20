using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitNexusRoom : MonoBehaviour
{
	private UIRegionMap regionMap;

	// Awake is called on first initialization
	void Awake()
	{
		regionMap = FindObjectOfType<UIRegionMap>();

		if (regionMap) {
			regionMap.gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (regionMap) {
			regionMap.gameObject.SetActive(true);
		}
		else
		{
			Debug.Log("Can't find a Region Map UI, I dont know where you want to go :(");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (regionMap)
		{
			if (regionMap.LoadingDungeon == false) {
				regionMap.gameObject.SetActive(false);
			}
		}
	}
}
