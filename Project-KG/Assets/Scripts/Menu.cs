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

	/*public Dropdown resolutionDropdown;

	private Resolution[] resolutions;

	private int currResolutionIndex = 0;*/

	public GameObject MainMenu;
	public GameObject ExitMenu;
	public GameObject SettingsMenu;
	public GameObject LoadMenu;

    void Start()
    {
		Debug.Log("Хуй");
    }

	/*public void ShowExitMenu()
    {
		MainMenu.SetActive(false);
		ExitMenu.SetActive(true);
	}

	public void BackToMainMenu()
	{
		MainMenu.SetActive(true);
		ExitMenu.SetActive(false);
	}*/

	public void ExitGame()
    {
		Application.Quit();
    }

	public void NewGame()
    {
		SceneManager.LoadScene("SampleScene");
		Debug.Log("Работает");
		//Application.LoadLevel("SampleScene");
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

	public void SaveSettings()
	{
		QualitySettings.SetQualityLevel(quality);
		Screen.fullScreen = isFullscreen;
		audioMixer.SetFloat("MasterVolume", volume);
		//Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen);
	}
}