using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace FloatingCursorMod
{
    public class CursorManager
    {
        private Vector2 position;
        private readonly IModHelper helper;

        public CursorManager(IModHelper helper)
        {
            this.helper = helper;
            this.position = new Vector2(500, 500);
        }

        public void HandleInput(ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (e.Button == SButton.DPadUp)
                position.Y -= 10;
            if (e.Button == SButton.DPadDown)
                position.Y += 10;
            if (e.Button == SButton.DPadLeft)
                position.X -= 10;
            if (e.Button == SButton.DPadRight)
                position.X += 10;
        }

        public void Update()
        {
            if (!Context.IsWorldReady)
                return;

            Game1.setMousePosition((int)position.X, (int)position.Y);
        }

        public void Draw(SpriteBatch b)
        {
            if (!Context.IsWorldReady)
                return;

            b.Draw(
                Game1.mouseCursors,
                position,
                new Rectangle(0, 0, 64, 64),
                Color.White
            );
        }
    }
}