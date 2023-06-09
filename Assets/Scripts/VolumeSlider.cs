using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeValue;

    void Start()
    {
        AudioListener.volume = 0.3f;

        // Set the Slider value to the current volume
        volumeSlider.value = AudioListener.volume;
        SetVolume();
    }

    public void SetVolume()
    {
        // Set the volume to the Slider value
        AudioListener.volume = volumeSlider.value;
        volumeValue.text = ((int)(volumeSlider.value * 100)).ToString();
    }
}
