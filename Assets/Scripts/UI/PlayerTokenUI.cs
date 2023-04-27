using Multiplayer;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerTokenUI : MonoBehaviour
    {
        
        public Slider coinSlider;
        private bool _isplayerCoinManagerNotNull;
        private bool _iscoinSliderNotNull;

        private void Start()
        {
            _iscoinSliderNotNull = coinSlider != null;
            //_isplayerCoinManagerNotNull = playerCoinManager != null;
        }

        private void Update() 
        {
            if (_isplayerCoinManagerNotNull && _iscoinSliderNotNull) 
            {
                //coinSlider.value = playerCoinManager.GetCoins();
            }
        }
    }
}
