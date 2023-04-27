using Gameplay.Components;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerHealthUI : MonoBehaviour
    {
       [SerializeField] private HealthComponent _playerHealth;
       [SerializeField] private Slider _healthSlider;
        private bool _isplayerHealthNotNull;
        private bool _ishealthSliderNotNull;
        private int _startHealth;

        private void Start()
        {
            _ishealthSliderNotNull = _healthSlider != null;
            _isplayerHealthNotNull = _playerHealth != null;
            _startHealth = _playerHealth.GetHealth();
            _healthSlider.maxValue = _startHealth;
            _healthSlider.value = _startHealth;
        }
        
        private void Update() 
        {
            if (_isplayerHealthNotNull && _ishealthSliderNotNull) 
            {
                _healthSlider.value = _playerHealth.GetHealth();
            }
        }
    }
}
