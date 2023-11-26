using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MouseSensitivity : MonoBehaviour
{
    [SerializeField] Slider mouseSlider;
    [SerializeField] float sensitivity;
    private void Start()
    {
        SetSensitivity(PlayerPrefs.GetFloat("Saved Mouse Sensitivity", 50));
    }

    public void SetSensitivity(float _value)
    {
        // if (_value < 1)
        // {
        //     _value = .001f;
        // }

        RefreshSlider(_value);
        sensitivity = _value;
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        
    }
    public void SetSensitivityFromSlider()
    {
        SetSensitivity(mouseSlider.value);
    }

    public void RefreshSlider(float _value)
    {
        mouseSlider.value = _value;
    }

    public float GetSensitivity()
    {
        return sensitivity;
    }
}