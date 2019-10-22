using ConsoleGameEngine.Components;
using FastConsoleUI;
using System.Collections.Concurrent;
using System.Collections.Generic;

/// <summary>
/// Console Game Engine managers namespace
/// </summary>
namespace ConsoleGameEngine.Managers
{
    /// <summary>
    /// Text sprite renderer class
    /// </summary>
    public class TextSpriteRenderer : AManager
    {
        /// <summary>
        /// Window
        /// </summary>
        private Window window;

        /// <summary>
        /// Sprites
        /// </summary>
        private List<ColoredTextField> sprites = new List<ColoredTextField>();

        /// <summary>
        /// Camera position
        /// </summary>
        public Vector2Int CameraPosition { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="window">Window</param>
        public TextSpriteRenderer(Window window)
        {
            this.window = window;
        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            base.Update();
            ConcurrentBag<TextSprite> text_sprite_bag = new ConcurrentBag<TextSprite>();
            ForEachComponent<TextSprite>((text_sprite) =>
            {
                text_sprite_bag.Add(text_sprite);
            });
            TextSprite[] text_sprites = text_sprite_bag.ToArray();
            while (sprites.Count > text_sprites.Length)
            {
                int index = sprites.Count - 1;
                window.RemoveControl(sprites[index]);
                sprites.RemoveAt(index);
            }
            for (int i = 0; i < text_sprites.Length; i++)
            {
                ColoredTextField sprite;
                TextSprite text_sprite = text_sprites[i];
                RectTransform rectangle_transform = text_sprite.GetComponent<RectTransform>();
                if (i < sprites.Count)
                {
                    sprite = sprites[i];
                }
                else
                {
                    if (rectangle_transform == null)
                    {
                        sprite = window.AddControl<ColoredTextField>(RectInt.zero);
                    }
                    else
                    {
                        sprite = window.AddControl<ColoredTextField>(rectangle_transform.Position - CameraPosition, rectangle_transform.Size);
                    }
                    sprite.AllowTransparency = true;
                    sprites.Add(sprite);
                }
                if (rectangle_transform == null)
                {
                    sprite.IsVisible = false;
                }
                else
                {
                    sprite.Text = text_sprite.Text;
                    sprite.Position = rectangle_transform.Position - CameraPosition;
                    sprite.Size = rectangle_transform.Size;
                    sprite.IsVisible = true;
                }
            }
        }
    }
}
