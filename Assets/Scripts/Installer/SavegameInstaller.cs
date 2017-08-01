using System;
using Savegame;
using Savegame.Model;
using Zenject;

namespace Installer
{
    public class SavegameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().WithId("SavePath").FromInstance(SavegameConfig.SavePath);
            Container.Bind<TimeSpan>().WithId("SaveInterval").FromInstance(SavegameConfig.SaveInterval);

            Container.BindInterfacesAndSelfTo<SavegameSaver>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavegameLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<NewSavegameCreator>().AsSingle();
            Container.Bind<SavegameModel>().FromFactory<SavegameFactory>().AsSingle();
            Container.Bind<CorridorSavegame>().FromResolveGetter<SavegameModel>(model => model.CorridorSavegame);
        }
    }
}