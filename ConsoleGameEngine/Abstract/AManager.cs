using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Console Game Engine namespace
/// </summary>
namespace ConsoleGameEngine
{
    /// <summary>
    /// Manager abstract class
    /// </summary>
    public abstract class AManager : IManager
    {
        /// <summary>
        /// Entities
        /// </summary>
        private List<IEntity> entities = new List<IEntity>();

        /// <summary>
        /// Garbage entities
        /// </summary>
        private ConcurrentBag<IEntity> garbageEntities = new ConcurrentBag<IEntity>();

        /// <summary>
        /// Entities
        /// </summary>
        public IReadOnlyCollection<IEntity> Entities => entities;

        /// <summary>
        /// For each entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="body">Body</param>
        public void ForEachEntity<T>(Action<T> body) where T : IEntity
        {
            if (body != null)
            {
                Parallel.ForEach(entities, (entity) =>
                {
                    if (entity is T)
                    {
                        lock (entity)
                        {
                            body((T)entity);
                        }
                    }
                });
            }
        }

        /// <summary>
        /// For each component
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <param name="body">Body</param>
        public void ForEachComponent<T>(Action<T> body) where T : IComponent
        {
            if (body != null)
            {
                Parallel.ForEach(entities, (entity) =>
                {
                    lock (entity)
                    {
                        foreach (IComponent component in entity.Components)
                        {
                            if (component is T)
                            {
                                lock (component)
                                {
                                    body((T)component);
                                }
                            }
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Entity</returns>
        public T AddEntity<T>() where T : IEntity
        {
            T ret = (T)(Activator.CreateInstance(typeof(T), this));
            lock (entities)
            {
                entities.Add(ret);
            }
            return ret;
        }

        /// <summary>
        /// Get entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Entity if successful, otherwise "null"</returns>
        public T GetEntity<T>() where T : IEntity
        {
            T ret = default;
            Parallel.ForEach(entities, (entity, state) =>
            {
                if (entity is T)
                {
                    ret = (T)entity;
                    state.Break();
                }
            });
            return ret;
        }

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveEntity(IEntity entity)
        {
            if (entity != null)
            {
                garbageEntities.Add(entity);
            }
        }

        /// <summary>
        /// Get entities
        /// </summary>
        /// <typeparam name="T">ENtity type</typeparam>
        /// <returns>Entities</returns>
        public T[] GetEntities<T>() where T : IEntity
        {
            T[] ret;
            ConcurrentBag<T> entities = new ConcurrentBag<T>();
            Parallel.ForEach(this.entities, (entity) =>
            {
                if (entity is T)
                {
                    entities.Add((T)entity);
                }
            });
            ret = entities.ToArray();
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
            Parallel.ForEach(entities, (entity, state) =>
            {
                foreach (IComponent component in entity.Components)
                {
                    if (component is T)
                    {
                        ret = (T)component;
                        state.Break();
                    }
                }
            });
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
            ConcurrentBag<T> components = new ConcurrentBag<T>();
            Parallel.ForEach(entities, (entity) =>
            {
                foreach (IComponent component in entity.Components)
                {
                    if (component is T)
                    {
                        components.Add((T)component);
                    }
                }
            });
            ret = components.ToArray();
            return ret;
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public virtual void Init()
        {
            foreach (IEntity entity in Entities)
            {
                entity.Init();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        public virtual void Update()
        {
            Parallel.ForEach(entities, (entity) =>
            {
                lock (entity)
                {
                    foreach (IComponent component in entity.Components)
                    {
                        lock (component)
                        {
                            component.Update();
                        }
                    }
                    entity.Update();
                }
            });
            foreach (IEntity entity in garbageEntities)
            {
                entities.Remove(entity);
            }
            if (garbageEntities.Count > 0)
            {
                garbageEntities = new ConcurrentBag<IEntity>();
            }
        }
    }
}
