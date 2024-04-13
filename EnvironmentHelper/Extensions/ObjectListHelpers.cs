using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnvironmentHelper.Extensions
{
    // Shortcuts to help with getting the various environment objects into collections

    internal static class ObjectListHelpers
    {
        /// <summary>
        /// Finds a <see cref="GameObject"/> under a parent <see cref="Transform"/> and adds it to the List
        /// </summary>
        /// <param name="root">Transform of the base environment</param>
        /// <param name="n">Name of the <see cref="GameObject"/></param>
        public static List<GameObject> AddSearchedGameObject(this List<GameObject> list, Transform root, string n)
        {
            list.TryAdd(root.Find(n)?.gameObject);
            return list; 
        }

        /// <summary>
        /// Finds <see cref="GameObject"/>s under a parent <see cref="Transform"/> and adds them to the List. <paramref name="numberOfObjects"/> is the number of <see cref="GameObject"/>s in a group of duplicated <see cref="GameObject"/>s
        /// </summary>
        /// <param name="root">Transform of the base environment</param>
        /// <param name="n">Name of the <see cref="GameObject"/></param>
        public static List<GameObject> AddSearchedNumberedGameObject(this List<GameObject> list, Transform root, string n, int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects + 1; i++)
            {
                list.TryAdd(root.Find(i == 0 ? n : n + $" ({i})")?.gameObject);
            }
            return list;
        }

        /// <summary>
        /// Gets a <see cref="TrackLaneRingsManager"/> and adds its <see cref="TrackLaneRing[]"/> to the list
        /// </summary>
        /// <param name="root">Transform of the base environment</param>
        /// <param name="n">Name of the <see cref="TrackLaneRingsManager"/> object</param>
        /// <returns></returns>
        public static IEnumerable<GameObject> AddTrackRingsFromSearchedRingManager(this List<GameObject> list, Transform root, string n)
        {
            return root.Find(n)?.GetComponent<TrackLaneRingsManager>()?.Rings.Select(x => x.transform.Find("Ring").gameObject);
        }
    }
}
