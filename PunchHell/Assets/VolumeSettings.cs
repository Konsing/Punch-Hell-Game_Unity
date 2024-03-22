using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 30;
    [SerializeField] private Toggle _toggle;
    private bool _disableToggleEvent;

    void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);
        _toggle.onValueChanged.AddListener(HandleToggleValueChanged);
    }

    private void HandleToggleValueChanged(bool enableSound)
    {
        if(_disableToggleEvent)
        {
            return;
        }

        if(enableSound)
        {
            _slider.value = _slider.maxValue;
        }
        else
        {
            _slider.value = _slider.minValue;
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }

    private void HandleSliderValueChanged(float value)
    {
        float volume = Mathf.Log10(Mathf.Max(value, 0.0001f)) * _multiplier;
        _mixer.SetFloat(_volumeParameter, volume);
        _disableToggleEvent = true;
        _toggle.isOn = _slider.value > _slider.minValue;
        _disableToggleEvent = false;
    }

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }
}