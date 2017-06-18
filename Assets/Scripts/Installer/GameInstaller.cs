using System;
using Corridor;
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
            Container.BindInterfacesAndSelfTo<CorridorModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<CorridorController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CorridorPresenter>()
                .FromComponentInNewPrefab(_prefabs.CorridorPrefab)
                .UnderTransformGroup("Canvas")
                .AsSingle();
        }

        [Serializable]
        public class Prefabs
        {
            public GameObject CorridorPrefab;
        }
    }
}