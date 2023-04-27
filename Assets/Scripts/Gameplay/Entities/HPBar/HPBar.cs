using System.Collections;
using SarrrGames.GoldenRush.Gameplay.Entities.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SarrrGames.GoldenRush.Gameplay.Entities.HPBar
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        private PlayerProgressModel _player;
        [SerializeField] private TMP_Text _text;
        private int lastHealth;
        private int lastDamage;

        [Inject]
        public void Construct(PlayerProgressModel playerProgressModel)
        {
            _player = playerProgressModel;
            SetMaxHP();
            _player.Health.OnChange += SetHealth;
        }

        private void SetMaxHP()
        {
            _slider.maxValue = _player.Health.GetValue();
            _slider.value = _slider.maxValue;
            lastHealth = _player.Health.GetValue();
        }

        private void SetHealth(int o)
        {
            _slider.value = _player.Health.GetValue();
            lastDamage = lastHealth - _player.Health.GetValue();
            lastHealth = _player.Health.GetValue();
            ShowText();
        }
        
        private void ShowText()
        {
            _text.text = lastDamage.ToString();
            _text.gameObject.SetActive(true);
            StartCoroutine(CloseText());
        }

        private IEnumerator CloseText()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                _text.gameObject.SetActive(false);
                break;
            }
        }
    }
}
