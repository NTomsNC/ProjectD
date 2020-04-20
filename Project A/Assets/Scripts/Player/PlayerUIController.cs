using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
	private PauseMenu _pauseMenu;

	// Awake is called on first initialization
	void Awake()
    {
		_pauseMenu = FindObjectOfType<PauseMenu>();

		if (_pauseMenu) {
			_pauseMenu.gameObject.SetActive(false);
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (_pauseMenu) {
				_pauseMenu.gameObject.SetActive(!_pauseMenu.gameObject.activeSelf);
			}
		}
    }
}
