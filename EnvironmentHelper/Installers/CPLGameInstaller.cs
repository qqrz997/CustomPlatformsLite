using EnvironmentHelper.Game;
using Zenject;

namespace EnvironmentHelper.Installers
{
    internal class CPLGameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GetEnvironments>().AsSingle().NonLazy();
        }
    }
}
