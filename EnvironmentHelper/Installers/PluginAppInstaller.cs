using EnvironmentHelper.Configuration;
using Zenject;

namespace EnvironmentHelper.Installers
{
    internal class PluginAppInstaller : Installer
    {
        private readonly PluginConfig config;

        public PluginAppInstaller(PluginConfig config)
        {
            this.config = config;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(config);
        }
    }
}
