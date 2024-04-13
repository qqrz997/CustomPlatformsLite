using EnvironmentHelper.Configuration;
using EnvironmentHelper.Installers;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Loader;
using SiraUtil.Zenject;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace EnvironmentHelper
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        private const string HarmonyId = "com.github.qqrz997.EnvironmentHelper";
        private static readonly HarmonyLib.Harmony harmony = new HarmonyLib.Harmony(HarmonyId);

        public static IPALogger Log { get; private set; }

        [Init]
        public void Init(Config config, Zenjector zenjector, IPALogger logger, PluginMetadata metadata)
        {
            Log = logger;
            PluginConfig pluginConfig = config.Generated<PluginConfig>();

            zenjector.UseLogger(logger);
            zenjector.Install<PluginAppInstaller>(Location.App, pluginConfig);
            zenjector.Install<PluginMenuInstaller>(Location.Menu);
            zenjector.Install<PluginGameInstaller>(Location.Player);
        }

        [OnStart]
        public void OnStart()
        {
            ApplyHarmonyPatches();
        }

        [OnExit]
        public void OnExit()
        {
            RemoveHarmonyPatches();
        }

        private void ApplyHarmonyPatches()
        {
            // i don't have any patches right now, but this is temporary until i know i don't need it -- note - i am aware of sirautil affinities
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        private void RemoveHarmonyPatches()
        {
            harmony.UnpatchSelf();
        }
    }
}
