using Core.ObservableProperty;

namespace Gameplay.Entities.Token
{
    public class TokenProgressModel 
    {
        public ObservableProperty<int> Soft { get; } = new ObservableProperty<int>(0);

        public ObservableProperty<int> BloxCount { get; } = new ObservableProperty<int>(0);
    }
}
