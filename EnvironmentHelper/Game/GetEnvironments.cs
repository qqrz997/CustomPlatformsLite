using EnvironmentHelper.Environments.Structures;
using EnvironmentHelper.EnvironmentStructures;
using EnvironmentHelper.Extensions;
using IPA.Utilities;
using SiraUtil.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace EnvironmentHelper.Game
{
    internal class GetEnvironments : IInitializable, IDisposable
    {
        private readonly SiraLog log;
        private readonly EnvironmentInfoSO environmentInfo;
        private readonly GameScenesManager scenesManager;

        public GetEnvironments(SiraLog log, EnvironmentSceneSetupData environmentData, GameScenesManager scenesManager)
        {
            this.log = log;
            this.environmentInfo = environmentData.environmentInfo;
            this.scenesManager = scenesManager;
            Init();
        }

        public IEnvironment environment;

        private GameObject environmentObject;

        private void Init()
        {
            environmentObject = GameObject.Find("Environment");
        }

        public void Initialize()
        {
            scenesManager.transitionDidFinishEvent += OnGameSceneTransitionDidFinish;
        }

        public void Dispose()
        {
            scenesManager.transitionDidFinishEvent -= OnGameSceneTransitionDidFinish;
        }

        private void OnGameSceneTransitionDidFinish(ScenesTransitionSetupDataSO scenesTransitionSetupData, DiContainer container)
        {
            if (!CheckEnvironmentName(environmentInfo.serializedName, out EnvironmentSerializedName environmentType))
            {
                log.Critical(
                    $"{environmentInfo.serializedName} is not supported!\n" +
                    $"If {environmentInfo.serializedName} isn't a new addition to the game, this is a bug");
                return;
            }

            SetEnvironmentStore(environmentType);
        }

        private bool CheckEnvironmentName(in string name, out EnvironmentSerializedName serializedName)
        {
            return Enum.TryParse(name, out serializedName);
        }

        private void SetEnvironmentStore(EnvironmentSerializedName environmentType)
        {
            log.Info("Setting environment store");
            switch (environmentType)
            {
                case EnvironmentSerializedName.DefaultEnvironment:
                    environment = new DefaultEnvironment(environmentObject); break;
                // case EnvironmentSerializedName.OriginsEnvironment:
                    // environment = new OriginsEnvironment(environmentObject); etc . . .
                case EnvironmentSerializedName.TriangleEnvironment:
                case EnvironmentSerializedName.NiceEnvironment:
                case EnvironmentSerializedName.BigMirrorEnvironment:
                case EnvironmentSerializedName.DragonsEnvironment:
                case EnvironmentSerializedName.KDAEnvironment:
                case EnvironmentSerializedName.MonstercatEnvironment:
                case EnvironmentSerializedName.CrabRaveEnvironment:
                case EnvironmentSerializedName.PanicEnvironment:
                case EnvironmentSerializedName.RocketEnvironment:
                case EnvironmentSerializedName.GreenDayGrenadeEnvironment:
                case EnvironmentSerializedName.GreenDayEnvironment:
                case EnvironmentSerializedName.TimbalandEnvironment:
                case EnvironmentSerializedName.FitBeatEnvironment:
                case EnvironmentSerializedName.LinkinParkEnvironment:
                case EnvironmentSerializedName.BTSEnvironment:
                case EnvironmentSerializedName.KaleidoscopeEnvironment:
                case EnvironmentSerializedName.InterscopeEnvironment:
                case EnvironmentSerializedName.SkrillexEnvironment:
                case EnvironmentSerializedName.BillieEnvironment:
                case EnvironmentSerializedName.HalloweenEnvironment:
                case EnvironmentSerializedName.GagaEnvironment:
                case EnvironmentSerializedName.WeaveEnvironment:
                case EnvironmentSerializedName.PyroEnvironment:
                case EnvironmentSerializedName.EDMEnvironment:
                case EnvironmentSerializedName.TheSecondEnvironment:
                case EnvironmentSerializedName.LizzoEnvironment:
                case EnvironmentSerializedName.TheWeekndEnvironment:
                case EnvironmentSerializedName.RockMixtapeEnvironment:
                case EnvironmentSerializedName.Dragons2Environment:
                case EnvironmentSerializedName.Panic2Environment:
                case EnvironmentSerializedName.QueenEnvironment:
                case EnvironmentSerializedName.LinkinPark2Environment:
                case EnvironmentSerializedName.TheRollingStonesEnvironment:
                case EnvironmentSerializedName.LatticeEnvironment:
                case EnvironmentSerializedName.DaftPunkEnvironment:
                case EnvironmentSerializedName.HipHopEnvironment:
                    log.Info($"{environmentType} is not yet implemented");
                    break;
                case EnvironmentSerializedName.GlassDesertEnvironment:
                    log.Info($"{environmentType} or 360 environments are not yet implemented");
                    break;
                case EnvironmentSerializedName.MultiplayerEnvironment:
                    log.Info($"{environmentType} or multiplayer environments are not yet implemented");
                    break;
            }

            // for testing
            environment.HideAllGeometry();
        }
    }
}
