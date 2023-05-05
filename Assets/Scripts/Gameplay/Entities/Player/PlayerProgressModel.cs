using Core.ObservableProperty;

namespace Gameplay.Entities.Player
{
    public class PlayerProgressModel
    {
        public ObservableProperty<int> Attack { get; } = new ObservableProperty<int>( 2);
        public ObservableProperty<int> Health { get; } = new ObservableProperty<int> (10);
        public ObservableProperty<int> AttackSpeed { get; } = new ObservableProperty<int> (40);
    }
}
