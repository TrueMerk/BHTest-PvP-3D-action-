using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinPopup : MonoBehaviour
    {

        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _nick;
        
        private void ShowWinner(string winnerName)
        {
            _image.gameObject.SetActive(true);
            _nick.text = winnerName;
        }
    }
}
