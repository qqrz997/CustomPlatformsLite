namespace EnvironmentHelper.Environments.Structures
{
    /// <summary>
    /// todo - need to figure out a way to structure the user-side implementation of an environment object
    /// </summary>
    internal abstract class EnvironmentBase : IEnvironment
    {
        internal bool Populated { get; set; }

        public abstract void HideAllGeometry();

        public abstract void HideAllLights();

        internal abstract void PopulateCollections();
    }
}
