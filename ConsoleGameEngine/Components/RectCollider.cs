using FastConsoleUI;

/// <summary>
/// Console Game Engine components namespace
/// </summary>
namespace ConsoleGameEngine.Components
{
    /// <summary>
    /// Rectangle collider
    /// </summary>
    public class RectCollider : AComponent
    {
        /// <summary>
        /// Rectangle transform
        /// </summary>
        public RectTransform RectangleTransform { get; private set; }

        /// <summary>
        /// Is colliding
        /// </summary>
        public bool IsColliding
        {
            get
            {
                bool ret = false;
                lock (Manager.Entities)
                {
                    foreach (IEntity entity in Manager.Entities)
                    {
                        if (entity != Entity)
                        {
                            foreach (IComponent component in entity.Components)
                            {
                                if (component is RectCollider)
                                {
                                    RectCollider rectangle_collider = (RectCollider)component;
                                    if (RectInt.CheckCollision(RectangleTransform.Rectangle, rectangle_collider.RectangleTransform.Rectangle))
                                    {
                                        ret = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// Positiion
        /// </summary>
        public Vector2Int Position
        {
            get => ((RectangleTransform == null) ? Vector2Int.zero : RectangleTransform.Position);
            set
            {
                if (RectangleTransform != null)
                {
                    Vector2Int position = RectangleTransform.Position;
                    RectangleTransform.Position = value;
                    if (IsColliding)
                    {
                        RectangleTransform.Position = position;
                    }
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity">Entity</param>
        public RectCollider(IEntity entity) : base(entity)
        {
            // ...
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Init()
        {
            RectangleTransform = RequireComponent<RectTransform>();
        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            // ...
        }
    }
}
