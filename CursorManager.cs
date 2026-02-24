using StardewModdingAPI;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace FloatingCursorMod
{
    public class CursorManager
    {
        private readonly IModHelper helper;
        private readonly IMonitor monitor;

        private Vector2 cursorPos = new Vector2(300, 300);
        private bool dragging = false;

        private Texture2D texture;

        public CursorManager(IModHelper helper, IMonitor monitor)
        {
            this.helper = helper;
            this.monitor = monitor;

            texture = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
        }

        public void HandleInput(ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (e.Button.IsUseToolButton())
            {
                dragging = true;
                cursorPos = e.Cursor.ScreenPixels;
            }
        }

        public void Update()
        {
            if (!Context.IsWorldReady)
                return;

            if (dragging)
            {
                cursorPos = Game1.getMousePosition();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Context.IsWorldReady)
                return;

            Rectangle rect = new Rectangle(
                (int)cursorPos.X - 20,
                (int)cursorPos.Y - 20,
                40,
                40
            );

            spriteBatch.Draw(texture, rect, Color.Cyan * 0.6f);
        }
    }
}