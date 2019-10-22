/// <summary>
/// Console Game Engine components namespace
/// </summary>
namespace ConsoleGameEngine.Components
{
    /// <summary>
    /// Text sprite namespace
    /// </summary>
    public class TextSprite : AComponent
    {
        /// <summary>
        /// Text
        /// </summary>
        private string text = string.Empty;

        /// <summary>
        /// Text
        /// </summary>
        public string Text
        {
            get => text;
            set
            {
                if (value != null)
                {
                    text = value;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity">Entity</param>
        public TextSprite(IEntity entity) : base(entity)
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
