using System;
using Gameplay.Entities.Player;
using Multiplayer;
using UnityEngine;
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
   }
}
