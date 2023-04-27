using Gameplay.Entities.Token;
using SarrrGames.GoldenRush.Gameplay.Entities.Player;
using Zenject;

namespace Core.Context
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerProgressModel>().AsSingle().NonLazy();
            Container.Bind<TokenProgressModel>().AsSingle().NonLazy();
        }
    }
}
