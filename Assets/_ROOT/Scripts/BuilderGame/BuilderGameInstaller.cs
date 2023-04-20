using Cinemachine;
using UnityEngine;
using Zenject;

namespace BuilderGame
{
    public class BuilderGameInstaller : MonoInstaller, IInitializable
    {
        [SerializeField]
        private CinemachineImpulseSource _impulseSource;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BuilderGameInstaller>().FromInstance(this);
            Container.Bind<CinemachineImpulseSource>().FromInstance(_impulseSource).AsSingle();
        }

        public void Initialize()
        {
            
        }
    }
}