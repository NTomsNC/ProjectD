using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFloor : MonoBehaviour
{
	[SerializeField] private Transform spikes;
	[SerializeField] private float secondsToRise = 1;

	// If we need to know to lower the spikes after the spikes are finished rising
	private bool rising = false;

	private void OnTriggerEnter(Collider other) {
		StartCoroutine(coRaiseSpikes());
	}

	private void OnTriggerExit(Collider other) {
		StartCoroutine(coLowerSpikes());
	}

	IEnumerator coRaiseSpikes()
	{
		rising = true;

		float duration = secondsToRise * 60f;
		for (int frame = 0; frame < duration; frame++) {
			spikes.localPosition = new Vector3(0, Mathf.Lerp(0, 1, frame / duration), 0);
			yield return null;
		}

		rising = false;
	}

	IEnumerator coLowerSpikes()
	{
		// Wait till the spikes are no longer rising
		while (rising == true) { yield return null; }

		float duration = secondsToRise * 60f * 3;
		for (int frame = 0; frame < duration; frame++) {
			spikes.localPosition = new Vector3(0, Mathf.Lerp(spikes.localPosition.y, 0, frame / duration), 0);
			yield return null;
		}
	}
}
