using CustomPlatformsLite.Configuration;
using CustomPlatformsLite.Installers;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Loader;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace CustomPlatformsLite
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        // public const string HarmonyId = "com.github.qqrz997.CustomPlatformsLite";
        // internal static readonly HarmonyLib.Harmony harmony = new HarmonyLib.Harmony(HarmonyId);

        private IPALogger logger;

        [Init]
        public void Init(Config config, Zenjector zenjector, IPALogger logger, PluginMetadata metadata)
        {
            this.logger = logger;
            PluginConfig pluginConfig = config.Generated<PluginConfig>();
            zenjector.UseLogger(logger);
            zenjector.Install<CPLAppInstaller>(Location.App, pluginConfig);
            zenjector.Install<CPLMenuInstaller>(Location.Menu);
            zenjector.Install<CPLGameInstaller>(Location.Player);
        }
    }
}
