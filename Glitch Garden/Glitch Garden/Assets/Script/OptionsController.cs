using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider diffSlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] float defaultDiff = 0f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        diffSlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveSetting()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(diffSlider.value);
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        diffSlider.value = defaultDiff;
    }
}
