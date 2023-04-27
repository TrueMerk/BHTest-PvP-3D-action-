using Gameplay.Entities.Enemy;
using Gameplay.ObjectsPool;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace Gameplay.Context.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Image _image;
        public override void InstallBindings()
        {
            Container.Bind<Pool>().AsTransient().Lazy(); 
            Container.Bind<Image>().FromInstance(_image).AsSingle();
            Container.Bind<EnemyContainer>().AsSingle().NonLazy();
        }
        
    }
}
