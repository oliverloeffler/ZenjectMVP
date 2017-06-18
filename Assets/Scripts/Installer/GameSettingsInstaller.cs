using Corridor;
using UnityEngine;
using Zenject;

namespace Installer
{
    [CreateAssetMenu(menuName = "Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public CorridorViewData CorridorView;
        public GameInstaller.Prefabs Prefabs;
        
        public override void InstallBindings()
        {
            Container.BindInstance<ICorridorViewData>(CorridorView);
            Container.BindInstance(Prefabs);
        }
    }
}