using Core.ObservableProperty;
using Gameplay.Entities.Token;
using SarrrGames.GoldenRush.Gameplay.Entities.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Models
{
    public class UIGameStats : MonoBehaviour
    {

        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _attackText;
        [SerializeField] private TMP_Text _attackSpeedText;
        [SerializeField] private TMP_Text _softText;
        [SerializeField] private TMP_Text _bloxText;
        
        private PlayerProgressModel _player;
        private TokenProgressModel _token;

        [Inject]
         public void Construct(PlayerProgressModel player,TokenProgressModel token)
         {
             //_player = player;
             //player.Attack.AttachToText(_attackText);
            // player.Health.AttachToText(_healthText);
            // player.AttackSpeed.AttachToText(_attackSpeedText);

             //_token = token;
             //_token.Soft.AttachToText(_softText);
             //_token.BloxCount.AttachToText(_bloxText);
         }
         
    }
}
