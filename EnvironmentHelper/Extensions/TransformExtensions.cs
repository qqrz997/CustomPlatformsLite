using System.Linq;
using UnityEngine;

namespace EnvironmentHelper.Extensions
{
    internal static class TransformExtensions
    {
        public static Transform[] FindChildrenByName(this Transform parent, string name)
        {
            return parent.GetComponentsInChildren<Transform>().Where(x => x.name == name).ToArray();
        }

        public static Transform[] FindChildren(this Transform parent)
        {
            return parent.GetComponentsInChildren<Transform>();
        }
    }
}
