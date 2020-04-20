using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIRegionMap : MonoBehaviour
{
	[SerializeField] private Transform loadingScreen;

	public bool LoadingDungeon = false;

	public void LoadDungeon(int index)
	{
		StartCoroutine(coLoadDungeon(index));
	}

	IEnumerator coLoadDungeon(int index)
	{
		LoadingDungeon = true;

		if (loadingScreen) {
			loadingScreen.gameObject.SetActive(true);
		}

		yield return new WaitForSecondsRealtime(0.5f);

		LoadingDungeon = false;

		SceneManager.LoadScene(4 + index);
	}
}
