using UnityEngine;
using System.Collections;

public class PauseEsc : MonoBehaviour {
	private bool GameIsPaused = false;
	public GameObject PauseMenu;
	void Start () {
	
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!GameIsPaused) 
			{
				PauseGame();
			} else 
			{
				Resume();
			}
		}
	}
	public void Resume()
	{
		PauseMenu.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void PauseGame()
	{
		PauseMenu.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
}
