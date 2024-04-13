using EnvironmentHelper.Game;
using Zenject;

namespace EnvironmentHelper.Installers
{
    internal class PluginGameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GetEnvironments>().AsSingle();
        }
    }
}
