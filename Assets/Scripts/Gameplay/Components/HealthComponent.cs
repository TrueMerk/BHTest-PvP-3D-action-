using System;
using Gameplay.Entities.Player;
using Multiplayer;
using UI;
using UnityEngine;
using Zenject;
using WinPopup = Multiplayer.WinPopup;

namespace Gameplay.Components
{
   public class HealthComponent : MonoBehaviour
   {
          [SerializeField] private int _health;
          
          private int _startHealth ;
          public WinPopup _winPopup;

          private UnitController _unitController;
          
          public event Action Dead;

          [Inject]
          public void Construct(UnitController unitController, WinPopup winPopup)
          {
              _unitController = unitController;
              _winPopup = winPopup;
          }
          
          private void Awake()
          {
              _startHealth = _health;
          }
          
          private void OnEnable()
          {
              _health = _startHealth;
          }

          public int GetHealth()
          {
              return _health;
          }
          
          
          public void SetPopup(WinPopup popup)
          {
              _winPopup=popup;
          }
      
          
          public void TakeDamage()
          {
              if (_health >1)
                  _health--;
              
              else
              {
                  _health--;
                  var playerIndex = gameObject.GetComponent<PlayerName>().nickName;
                  //var score = gameObject.GetComponent<PlayerCoinManager>().GetCoins();

                  gameObject.SetActive(false);
              }
          }
   }
}
