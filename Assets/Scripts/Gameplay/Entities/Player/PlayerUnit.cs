using Gameplay.Components;

namespace Gameplay.Entities.Player
{
    public class PlayerUnit : Unit
    {
        private UnitController _unitController;
        
        private void Start()
        {
            HealthComponent.Dead += Dead;
        }

        private void Dead()
        {
            
        }
    }
}
