/// <summary>
/// Console Game Engine namespace
/// </summary>
namespace ConsoleGameEngine
{
    /// <summary>
    /// Component abstract class
    /// </summary>
    public abstract class AComponent : IComponent
    {
        /// <summary>
        /// Manager
        /// </summary>
        public IManager Manager => Entity.Manager;

        /// <summary>
        /// Entity
        /// </summary>
        public IEntity Entity { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity">Entity</param>
        public AComponent(IEntity entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Add component
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component</returns>
        public T AddComponent<T>() where T : IComponent => Entity.AddComponent<T>();

        /// <summary>
        /// Get component
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component if successful, otherwise "null"</returns>
        public T GetComponent<T>() where T : IComponent => Entity.GetComponent<T>();

        /// <summary>
        /// Get components
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Components</returns>
        public T[] GetComponents<T>() where T : IComponent => Entity.GetComponents<T>();

        /// <summary>
        /// Require component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Component</returns>
        /// <remarks>Adds a new component, if there is no component of the specified type</remarks>
        public T RequireComponent<T>() where T : IComponent => Entity.RequireComponent<T>();

        /// <summary>
        /// Initialize
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Update
        /// </summary>
        public abstract void Update();
    }
}
