using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
	public int quality = 0;

	public bool isFullscreen = false;

	public float volume = 0;

	public AudioMixer audioMixer;

	public static bool GameIsPaused = false;

	public Dropdown resolutionDropdown;

	private Resolution[] resolutions;

	private int currResolutionIndex = 0;

	Scene scene;

	/*public GameObject MainMenu;
	public GameObject ExitMenu;
	public GameObject SettingsMenu;
	public GameObject LoadMenu;*/

	public GameObject PauseMenu;

    private void Start()
    {
		scene = SceneManager.GetActiveScene();
		//Debug.Log("Active Scene is '" + scene.name);
	}

    void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				PauseGame();
			}
		}
	}

	public void Resume()
	{
		if (scene.name != "Main Menu") 
		{
			PauseMenu.SetActive(false);
			Time.timeScale = 1f;
			GameIsPaused = false; 
		}
		
	}

	public void PauseGame()
	{
		if (scene.name != "Main Menu")
		{
			PauseMenu.SetActive(true);
			Time.timeScale = 0f;
			GameIsPaused = true;
		}
	}
	public void ExitToMainMenu()
	{
		GameIsPaused = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene("Main menu");
	}


	//-------------------------------------------------------------------------------------------------------------------------------

	public void ExitGame()
    {
		Application.Quit();
    }

	public void NewGame()
    {
		SceneManager.LoadScene("Game");
    }

	/*public void LoadGame()
	{
		Application.LoadLevel(level);
	}*/

	public void ChangeQuality(int index)
	{
		quality = index;
	}
	public void ChangeFullscreenMode(bool val)
	{
		isFullscreen = val;
	}
	public void ChangeVolume(float val)
	{
		volume = val;
	}

	public void ChangeResolution(int index) 
	{
		currResolutionIndex = index;
	}


	public void SaveSettings()
	{
		QualitySettings.SetQualityLevel(quality);
		Screen.fullScreen = isFullscreen;
		audioMixer.SetFloat("MasterVolume", volume);
		//Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen);
	}
}
