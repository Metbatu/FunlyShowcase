using UnityEngine;
using UnityEngine.UI;

namespace GameFolder.Scripts
{
    public class AISliderController : MonoBehaviour
    {
        public Slider slider;
        public float minChangeInterval = 1f;
        public float maxChangeInterval = 3f;

        private float _targetValue; // Target value for the slider
        private float _changeInterval; // Interval between value changes
        private float _timer; // Timer to track time between changes
        private float _startValue; // Starting value for the smooth transition

        void Start()
        {
            SetNewTargetValue();
            _changeInterval = Random.Range(minChangeInterval, maxChangeInterval);
            _startValue = slider.value;
        }

        void Update()
        {
            _timer += Time.deltaTime;

            // Move slider handle towards the target value smoothly
            slider.value = Mathf.Lerp(_startValue, _targetValue, _timer / _changeInterval);

            // Check if it's time to change the target value
            if (_timer >= _changeInterval)
            {
                SetNewTargetValue();
                _timer = 0f;
                _startValue = slider.value;
            }
        }

        void SetNewTargetValue()
        {
            _targetValue = Random.value;
            _changeInterval = Random.Range(minChangeInterval, maxChangeInterval);
        }
    }
}