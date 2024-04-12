using EnvironmentHelper.Extensions;
using SiraUtil.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Zenject;

namespace EnvironmentHelper.Game
{
    internal class GetEnvironments : IInitializable, IDisposable
    {
        private readonly SiraLog log;
        private readonly EnvironmentInfoSO environmentInfo;

        public GetEnvironments(SiraLog log, EnvironmentSceneSetupData environmentData) 
        {
            this.log = log;
            this.environmentInfo = environmentData.environmentInfo;
            Init();
        }

        private GameObject baseEnvironment;
        private GameObject playersPlace;
        private IEnumerable<Transform> baseEnvironmentChildren;
        private List<GameObject> lightsObjects;
        private List<GameObject> structuresObjects;
        private Stopwatch sw;

        private void Init()
        {
            sw = new Stopwatch();
            sw.Start();
            log.Info("Getting environment children");

            baseEnvironment = GameObject.Find("Environment");
            baseEnvironmentChildren = baseEnvironment.transform.FindChildren();
        }

        public void Initialize()
        {
            sw.Stop();
            log.Info($"{sw.Elapsed.TotalMilliseconds} ms");
            log.Info($"{environmentInfo.serializedName}");
            log.Info($"{baseEnvironmentChildren.Count()} children");
        }

        public void Dispose()
        {
            
        }
    }
}
