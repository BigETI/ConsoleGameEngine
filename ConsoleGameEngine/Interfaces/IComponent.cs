/// <summary>
/// Console Game Engine namespace
/// </summary>
namespace ConsoleGameEngine
{
    /// <summary>
    /// Component interface
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Manager
        /// </summary>
        IManager Manager { get; }

        /// <summary>
        /// Entity
        /// </summary>
        IEntity Entity { get; }

        /// <summary>
        /// Add component
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component</returns>
        T AddComponent<T>() where T : IComponent;

        /// <summary>
        /// Get component
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component if successful, otherwise "null"</returns>
        T GetComponent<T>() where T : IComponent;

        /// <summary>
        /// Get components
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Components</returns>
        T[] GetComponents<T>() where T : IComponent;

        /// <summary>
        /// Require components
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component</returns>
        /// <remarks>Adds a new component, if there is no component of the specified type</remarks>
        T RequireComponent<T>() where T : IComponent;

        /// <summary>
        /// Initialize
        /// </summary>
        void Init();

        /// <summary>
        /// Update
        /// </summary>
        void Update();
    }
}
