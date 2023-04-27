using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Multiplayer
{
    public class WinPopup : NetworkBehaviour
    {

        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _nick;
        
        
        public void ShowWinner(string winnerName)
        {
            _image.gameObject.SetActive(true);
            _nick.text = winnerName;
        }
    }
}
