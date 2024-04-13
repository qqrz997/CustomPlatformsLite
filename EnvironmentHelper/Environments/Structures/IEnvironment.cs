namespace EnvironmentHelper.Environments.Structures
{
    /// <summary>
    /// An interface for accessing various methods related to the base environment
    /// </summary>
    public interface IEnvironment
    {
        /// <summary>
        /// Hides all physical objects in the environment
        /// </summary>
        void HideAllGeometry();


        /// <summary>
        /// Hides all lights in the environment
        /// </summary>
        void HideAllLights();
    }
}
