using FastConsoleUI;

/// <summary>
/// Console Game Engine components namespace
/// </summary>
namespace ConsoleGameEngine.Components
{
    /// <summary>
    /// REctangle transform namespace
    /// </summary>
    public class RectTransform : AComponent
    {
        /// <summary>
        /// Rectangle
        /// </summary>
        public RectInt Rectangle { get; set; }

        /// <summary>
        /// Positiion
        /// </summary>
        public Vector2Int Position
        {
            get => Rectangle.Position;
            set => Rectangle = new RectInt(value, Rectangle.Size);
        }

        /// <summary>
        /// Size
        /// </summary>
        public Vector2Int Size
        {
            get => Rectangle.Size;
            set => Rectangle = new RectInt(Rectangle.Position, value);
        }

        /// <summary>
        /// X
        /// </summary>
        public int X
        {
            get => Position.X;
            set => Position = new Vector2Int(value, Position.Y);
        }

        /// <summary>
        /// Y
        /// </summary>
        public int Y
        {
            get => Position.Y;
            set => Position = new Vector2Int(Position.X, value);
        }

        /// <summary>
        /// Width
        /// </summary>
        public int Width
        {
            get => Size.X;
            set => Size = new Vector2Int(value, Size.Y);
        }

        /// <summary>
        /// Height
        /// </summary>
        public int Height
        {
            get => Size.Y;
            set => Size = new Vector2Int(Size.X, value);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity">Entity</param>
        public RectTransform(IEntity entity) : base(entity)
        {
            // ...
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Init()
        {
            // ...
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
