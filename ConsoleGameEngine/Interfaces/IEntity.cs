using System.Collections.Generic;

/// <summary>
/// Console Game Engine namespace
/// </summary>
namespace ConsoleGameEngine
{
    /// <summary>
    /// Entity interface
    /// </summary>
    public interface IEntity : IComponent
    {
        IReadOnlyCollection<IComponent> Components { get; }
    }
}
