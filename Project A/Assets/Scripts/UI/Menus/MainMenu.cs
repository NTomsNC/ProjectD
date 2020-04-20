using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Transform loadingScreen;

	[SerializeField] private Transform mainMenu;
	[SerializeField] private Transform settingsMenu;

	public void PlayGame()
	{
		StartCoroutine(coPlayGame());
	}

	IEnumerator coPlayGame()
	{
		if (loadingScreen)
		{
			loadingScreen.gameObject.SetActive(true);
			yield return null;
		}

		yield return new WaitForSecondsRealtime(0.5f);

		SceneManager.LoadScene(2);
	}

	public void OpenSettingsMenu()
	{
		if (mainMenu && settingsMenu)
		{
			settingsMenu.gameObject.SetActive(true);
			mainMenu.gameObject.SetActive(false);
		}
	}

	public void CloseSettingsMenu()
	{
		if (mainMenu && settingsMenu)
		{
			settingsMenu.gameObject.SetActive(false);
			mainMenu.gameObject.SetActive(true);
		}
	}

	public void Quit()
	{
		Application.Quit();
	}
}
