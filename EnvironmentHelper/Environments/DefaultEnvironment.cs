using EnvironmentHelper.Environments.Structures;
using EnvironmentHelper.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnvironmentHelper.EnvironmentStructures
{
    internal class DefaultEnvironment : EnvironmentBase
    {
        // static
        // 
        // PlayersPlace
        // TrackMirror
        // TrackConstruction
        // NearBuildingLeft (1,2)
        // NearBuildingRight (1,2)
        //
        // dynamic
        //
        // BasicGameHUD
        // BackColumns
        // BigSmokePS
        // SmallTrackLaneRings
        // BigTrackLaneRings
        // Spectrograms
        // DustPS
        //
        // lights
        //
        // CoreLighting
        // FrontLights
        // DoubleColorLaserR
        // DoubleColorLaserR (1-4)
        // DoubleColorLaserL
        // DoubleColorLaserL (1-4)
        // RotatingLasersPair
        // RotatingLasersPair (1-4)
        // NeonTubeL
        // NeonTubeR

        private readonly GameObject environmentObject;

        public DefaultEnvironment(GameObject environmentObject)
        {
            this.environmentObject = environmentObject;
            PopulateCollections();
        }

        public List<GameObject> PlayersPlace;

        public List<GameObject> Track = new List<GameObject>();
        public List<GameObject> Construction = new List<GameObject>();
        public List<MeshRenderer> BackColumns = new List<MeshRenderer>();

        public List<GameObject> SmallRings = new List<GameObject>();
        public List<GameObject> BigRings = new List<GameObject>();

        public List<GameObject> BackLasers;
        public List<GameObject> BigRingsLights;
        public List<GameObject> LeftRotatingLasers;
        public List<GameObject> RightRotatingLasers;
        public List<GameObject> CenterLights;

        internal override void PopulateCollections()
        {
            Transform root = environmentObject.transform;

            // Geometries 
            Track.AddSearchedGameObject(root, "TrackMirror");
            Track.AddSearchedGameObject(root, "TrackConstruction");

            Construction.AddSearchedGameObject(root, "NearBuildingLeft (1)/Mesh");
            Construction.AddSearchedGameObject(root, "NearBuildingLeft (2)/Mesh");
            Construction.AddSearchedGameObject(root, "NearBuildingRight (1)/Mesh");
            Construction.AddSearchedGameObject(root, "NearBuildingRight (2)/Mesh");
            Construction.AddSearchedGameObject(root, "Spectrograms");

            BackColumns.Add(root.Find("BackColumns")?.GetComponent<MeshRenderer>());

            SmallRings.AddRange(root.Find("SmallTrackLaneRings")?.GetComponent<TrackLaneRingsManager>().Rings.Select(x => x.transform.Find("Ring").gameObject));
            BigRings.AddRange(root.Find("BigTrackLaneRings")?.GetComponent<TrackLaneRingsManager>().Rings.Select(x => x.transform.Find("Ring").gameObject));
            SmallRings.AddTrackRingsFromSearchedRingManager(root, "SmallTrackLaneRings");
            BigRings.AddTrackRingsFromSearchedRingManager(root, "BigTrackLaneRings");

            // Lights


            Populated = true;
        }

        public override void HideAllGeometry()
        {
            if (!Populated) return;

            IEnumerable<GameObject> geometries = Track
                .Concat(Construction)
                .Concat(SmallRings)
                .Concat(BigRings);

            foreach (GameObject geometry in geometries)
            {
                geometry.gameObject.SetActive(false);
            }

            foreach (MeshRenderer renderer in BackColumns)
            {
                renderer.enabled = false;
            }
        }

        public override void HideAllLights()
        {
            if (!Populated) return;

            IEnumerable<GameObject> lights = BackLasers
                .Concat(BigRingsLights)
                .Concat(LeftRotatingLasers)
                .Concat(RightRotatingLasers)
                .Concat(CenterLights);

            foreach (var light in lights)
            {
                light.gameObject.SetActive(false);
            }
        }
    }
}
