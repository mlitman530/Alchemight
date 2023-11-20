using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    [SerializeField] Slider mouseSlider;
    [SerializeField] float sensitivity = 50f;

    private FollowPlayer followPlayer;

    // Start is called before the first frame update
    void Start()
    {
        SetSensitivity(PlayerPrefs.GetFloat("SavedMouseSensitivity", 50));
    }

    // Update is called once per frame
    public void SetSensitivity(float _value)
    {
        // if (_value < 1) 
        // {
        //     _value = 0.01f;
        // }

        RefreshSlider(_value);
        sensitivity = _value;
        PlayerPrefs.SetFloat("SavedMouseSensitivity", _value);
        followPlayer = GetComponent<FollowPlayer>();
        followPlayer.SetSensitivity(_value / 5f);
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
