using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Linq;

public class Menu : MonoBehaviour
{
	public int quality = 0;

	public bool isFullscreen = false;

	public float volume = 0;

	public AudioMixer audioMixer;

	public static bool GameIsPaused = false;

	public Dropdown QualityDropdown;

	public Dropdown resolutionDropdown;

	public Slider VolumeSlider;

	Resolution[] realResolutions;

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

		QualityDropdown.ClearOptions();
		QualityDropdown.AddOptions(QualitySettings.names.ToList());

		resolutionDropdown.ClearOptions();
		Resolution[] resolutions = Screen.resolutions;
		realResolutions = resolutions.Distinct().ToArray();
		string[] strResolutions = new string[realResolutions.Length];
		for (int i = 0; i < realResolutions.Length; i++)
        {
			strResolutions[i] = realResolutions[i].width.ToString() + "x" + realResolutions[i].height.ToString();
		}
			
		resolutionDropdown.AddOptions(strResolutions.ToList());

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
		SceneManager.LoadScene("SampleScene");
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
		audioMixer.SetFloat("masterVolume", volume);
		Screen.fullScreen = isFullscreen;
		Screen.SetResolution(realResolutions[currResolutionIndex].width, realResolutions[currResolutionIndex].height, isFullscreen);
	}
}
