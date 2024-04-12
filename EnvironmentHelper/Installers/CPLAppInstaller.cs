using EnvironmentHelper.Configuration;
using Zenject;

namespace EnvironmentHelper.Installers
{
    internal class CPLAppInstaller : Installer
    {
        private readonly PluginConfig config;

        public CPLAppInstaller(PluginConfig config)
        {
            this.config = config;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(config);
        }
    }
}
