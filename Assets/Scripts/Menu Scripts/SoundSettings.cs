using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    private void Awake()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 50));
    }

    public void SetVolume(float _value)
    {
        if (_value < 1)
        {
            _value = .001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
        AudioListener.volume = _value / 100;
    }
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value)
    {
        soundSlider.value = _value;
    }
}