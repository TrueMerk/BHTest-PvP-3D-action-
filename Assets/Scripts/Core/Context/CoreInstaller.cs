using Core.StateMachine;
using SarrrGames.GoldenRush.Core.StateMachine;
using SarrrGames.GoldenRush.Core.StateMachine.States;
using Zenject;

namespace Core.Context
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<ISaveService>().To<JsonSaveService>().AsSingle().NonLazy();
            Container.Bind<IStateMachine>().To<StateMachine.StateMachine>().AsSingle().NonLazy();
            Container.Bind<LoadState>().AsTransient();
            Container.Bind<MenuState>().AsTransient();
        }
    }
}
