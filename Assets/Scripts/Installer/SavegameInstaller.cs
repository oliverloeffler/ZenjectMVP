using System;
using Savegame;
using Zenject;

namespace Installer
{
    public class SavegameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(SavegameConfig.SavePath).AsSingle();
            Container.BindInstance(SavegameConfig.SaveInterval).AsSingle();

            Container.BindInterfacesAndSelfTo<SavegameSaver>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavegameLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<NewSavegameCreator>().AsSingle();
            Container.Bind<SavegameModel>().FromFactory<SavegameFactory>().AsSingle();
            Container.Bind<CorridorSavegame>().FromResolveGetter<SavegameModel>(model => model.CorridorSavegame);
        }
    }
}