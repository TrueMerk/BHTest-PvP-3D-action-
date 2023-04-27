using System.Collections.Generic;
using Gameplay.Components;
using Gameplay.Entities.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _button;
        private List<PlayerUnit> _playerUnit;
        public GameObject pauseMenuUI;

        [Inject]
        public void Construct(UnitController unitController)
        {
            foreach (var unit in _playerUnit)
            {
                unit.GameOverAction += GameOver;
            }
        }
    
        private void Start()
        {
            pauseMenuUI.SetActive(false);
        }
    
        private void GameOver()
        {
            pauseMenuUI.SetActive(true);
            _button.gameObject.SetActive(true);
        }
    
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
