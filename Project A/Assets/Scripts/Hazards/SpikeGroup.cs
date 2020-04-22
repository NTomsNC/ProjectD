using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGroup : MonoBehaviour
{
	[SerializeField] private List<SpikeFloor> oddSpikes = new List<SpikeFloor>();
	[SerializeField] private List<SpikeFloor> evenSpikes = new List<SpikeFloor>();

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(coToggleSpikes());
	}

	private IEnumerator coToggleSpikes() {
		while (true)
		{
			foreach (SpikeFloor spike in evenSpikes) { StartCoroutine(spike.coLowerSpikes()); }
			yield return new WaitForSecondsRealtime(0.75f);
			foreach (SpikeFloor spike in oddSpikes) { StartCoroutine(spike.coRaiseSpikes()); }
			yield return new WaitForSecondsRealtime(3);

			foreach (SpikeFloor spike in oddSpikes) { StartCoroutine(spike.coLowerSpikes()); }
			yield return new WaitForSecondsRealtime(0.75f);
			foreach (SpikeFloor spike in evenSpikes) { StartCoroutine(spike.coRaiseSpikes()); }
			yield return new WaitForSecondsRealtime(3);
		}
	}
}
