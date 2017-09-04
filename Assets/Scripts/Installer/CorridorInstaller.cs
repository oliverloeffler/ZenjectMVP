using Corridor;
using Zenject;

namespace Installer
{
    public class CorridorInstaller : MonoInstaller
    {
        [Inject]
        private GameInstaller.Prefabs _prefabs;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CorridorData>().AsSingle();
            Container.BindInterfacesAndSelfTo<CorridorModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<CorridorController>().AsSingle();
        }

    }
}