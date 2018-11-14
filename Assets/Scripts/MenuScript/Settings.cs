using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{

    public Toggle FullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;
    public Slider musicVolumeSlider;
    public Button applySaveButton;
    public Button exitButton;

    public AudioSource musicSource;
    private Resolution[] resolutions;
    private GameSettings gameSettings;

    private void OnEnable()
    {

        gameSettings = new GameSettings();

        FullscreenToggle.onValueChanged.AddListener(delegate {
            OnFullscreenToggle();
        });

        resolutionDropdown.onValueChanged.AddListener(delegate {
            OnResolutionChange();
        });

        textureQualityDropdown.onValueChanged.AddListener(delegate {
            OnTextureQualityChange();
        });

        antialiasingDropdown.onValueChanged.AddListener(delegate {
            OnAnatialiasingChange();
        });

        vSyncDropdown.onValueChanged.AddListener(delegate {
            OnvSyncChange();
        });

        musicVolumeSlider.onValueChanged.AddListener(delegate {
            OnmusicVolumeChange();
        });

        applySaveButton.onClick.AddListener(delegate {
            OnapplySaveClick();
        });

        exitButton.onClick.AddListener(delegate {
            OnexitClick();
        });



        resolutions = Screen.resolutions;

        foreach (Resolution resolution in resolutions)
        {

            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }
    private void LoadSettings()
    {

        gameSettings = JsonUtility.FromJson<GameSettings>(
            File.ReadAllText(Application.persistentDataPath + "/gamesettings.json")
        );
        musicVolumeSlider.value = gameSettings.musicVolume;
        antialiasingDropdown.value = gameSettings.antialiasing;
        vSyncDropdown.value = gameSettings.vSync;
        textureQualityDropdown.value = gameSettings.textureQuality;
        FullscreenToggle.isOn = gameSettings.fullscreen;
        Screen.fullScreen = gameSettings.fullscreen;
        resolutionDropdown.value = gameSettings.resolutionIndex;


        resolutionDropdown.RefreshShownValue();
    }


    private void OnFullscreenToggle()
    {

        gameSettings.fullscreen = Screen.fullScreen = FullscreenToggle.isOn;

    }

    private void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width,
            resolutions[resolutionDropdown.value].height,
            Screen.fullScreen
        );
        gameSettings.resolutionIndex = resolutionDropdown.value;

    }
    private void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;

    }

    private void OnAnatialiasingChange()
    {

        QualitySettings.antiAliasing = gameSettings.antialiasing = antialiasingDropdown.value;
    }
    private void OnvSyncChange()
    {

        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }




    private void OnmusicVolumeChange()
    {

        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }
    private void OnapplySaveClick()
    {
        SaveSettings();

    }
    private void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings);
        File.WriteAllText(Application.persistentDataPath + "/gameSettings.json", jsonData);
    }
    private void OnexitClick()
    {
        SceneManager.LoadScene("MenuInicial");

    }



}
