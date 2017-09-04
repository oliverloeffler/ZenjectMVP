using System;
using Corridor;
using Mine;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class GameInstaller : MonoInstaller
    {
        [Inject]
        private Prefabs _prefabs;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MineController>().AsSingle().NonLazy();
            Container.BindFactory<CorridorPresenter, CorridorPresenter.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab(_prefabs.CorridorPrefab)
                .UnderTransformGroup("Canvas");
        }

        [Serializable]
        public class Prefabs
        {
            public GameObject CorridorPrefab;
        }
    }
}