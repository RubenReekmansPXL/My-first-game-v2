using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Toggle muteMusicToggle;
    public Toggle virbrateToggle;
    public Text qualityLabel;
    public int quality;
    public Dropdown dropdown;

    public AudioManager audioManager;


    public void Start()
    {
        virbrateToggle.isOn = bool.Parse(PlayerPrefs.GetString("Vibrate"));
    }

    public void FixedUpdate()
    {
        if (virbrateToggle.isOn)
        {
            PlayerPrefs.SetString("Vibrate", "true");
        }
        else
        {
            PlayerPrefs.SetString("Vibrate", "false");
        }

        if (PlayerPrefs.GetString("Music").Equals("true"))
        {
            muteMusicToggle.isOn = true;
        }
        else
        {
            muteMusicToggle.isOn = false;
        }


        quality = PlayerPrefs.GetInt("Quality");
        QualitySettings.SetQualityLevel(quality);
        if (quality == 0)
        {
            qualityLabel.text = "LOW";
            dropdown.value = quality;
        }
        else if (quality == 1)
        {
            qualityLabel.text = "MEDIUM";
            dropdown.value = quality;
        }
        else
        {
            qualityLabel.text = "HIGH";
            dropdown.value = quality;
        }
    }

    public void MuteMusic()
    {

        if (muteMusicToggle.isOn)
        {
            audioManager.MuteMusic();
            PlayerPrefs.SetString("Music", "true");
        }
        else
        {
            audioManager.UnMuteMusic();
            PlayerPrefs.SetString("Music", "false");
        }

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }
}
