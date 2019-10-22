using System;
using System.Collections.Generic;

/// <summary>
/// Console Game Engine namespace
/// </summary>
namespace ConsoleGameEngine
{
    /// <summary>
    /// Entity abstract class
    /// </summary>
    public abstract class AEntity : IEntity
    {
        /// <summary>
        /// Components
        /// </summary>
        private List<IComponent> components = new List<IComponent>();

        /// <summary>
        /// Manager
        /// </summary>
        public IManager Manager { get; private set; }

        /// <summary>
        /// Entity
        /// </summary>
        public IEntity Entity => this;

        /// <summary>
        /// Components
        /// </summary>
        public IReadOnlyCollection<IComponent> Components => components;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manager">Manager</param>
        public AEntity(IManager manager)
        {
            Manager = manager;
        }

        /// <summary>
        /// Add component
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component</returns>
        public T AddComponent<T>() where T : IComponent
        {
            T ret = (T)(Activator.CreateInstance(typeof(T), this));
            components.Add(ret);
            return ret;
        }

        /// <summary>
        /// Get component
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component if successful, otherwise "null"</returns>
        public T GetComponent<T>() where T : IComponent
        {
            T ret = default;
            foreach (IComponent component in components)
            {
                if (component is T)
                {
                    ret = (T)component;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Get components
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Components</returns>
        public T[] GetComponents<T>() where T : IComponent
        {
            T[] ret;
            List<T> components = new List<T>();
            foreach (IComponent component in this.components)
            {
                if (component is T)
                {
                    components.Add((T)component);
                }
            }
            ret = components.ToArray();
            components.Clear();
            return ret;
        }

        /// <summary>
        /// Require component
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component</returns>
        /// <remarks>Adds a new component, if there is no component of the specified type</remarks>
        public T RequireComponent<T>() where T : IComponent
        {
            T ret = GetComponent<T>();
            if (ret == null)
            {
                ret = AddComponent<T>();
            }
            return ret;
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public virtual void Init()
        {
            foreach (IComponent component in Components)
            {
                component.Init();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        public abstract void Update();
    }
}
