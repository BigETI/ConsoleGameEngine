using System;
using System.Collections.Generic;

/// <summary>
/// Console Game Engine namespace
/// </summary>
namespace ConsoleGameEngine
{
    /// <summary>
    /// Manager interface
    /// </summary>
    public interface IManager
    {
        /// <summary>
        /// Entities
        /// </summary>
        IReadOnlyCollection<IEntity> Entities { get; }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Entity</returns>
        T AddEntity<T>() where T : IEntity;

        /// <summary>
        /// Get entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Entity if successful, otherwise "null"</returns>
        T GetEntity<T>() where T : IEntity;

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void RemoveEntity(IEntity entity);

        /// <summary>
        /// Get entities
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Entities</returns>
        T[] GetEntities<T>() where T : IEntity;

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
        /// For each entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="body">Body</param>
        void ForEachEntity<T>(Action<T> body) where T : IEntity;

        /// <summary>
        /// For each component
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <param name="body">Body</param>
        void ForEachComponent<T>(Action<T> body) where T : IComponent;

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
