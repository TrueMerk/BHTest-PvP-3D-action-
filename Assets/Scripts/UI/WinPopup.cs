using System;
using Multiplayer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinPopup : MonoBehaviour
    {

        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _nick;
        [SerializeField] private TMP_Text _score;
        


        
        
        private void ShowWinner(string winnerName , string scoreText)
        {
            _image.gameObject.SetActive(true);
            _nick.text = winnerName;
            _score.text = scoreText;

        }
    }
}
