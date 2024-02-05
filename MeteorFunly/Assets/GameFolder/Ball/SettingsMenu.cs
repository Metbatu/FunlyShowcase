using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameFolder.Ball
{
    public class SettingsMenu : MonoBehaviour
    {
        public float Speed { get; private set; }
        
        public Slider speedSlider;
        private const string SpeedPlayerPrefsKey = "BallSpeed";

        private void Start()
        {
            Speed = PlayerPrefs.GetFloat(SpeedPlayerPrefsKey, 200f);
            speedSlider.value = Speed;
        }

        public void OnSpeedSliderValueChanged()
        {
            Speed = speedSlider.value;
            
            PlayerPrefs.SetFloat(SpeedPlayerPrefsKey, Speed);
            PlayerPrefs.Save();
        }
    }
}
