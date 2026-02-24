using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace FloatingCursorMod
{
    public class CursorManager
    {
        private readonly IModHelper helper;

        private Vector2 position = new Vector2(500, 500);
        private bool visible = true;
        private float speed = 8f;

        public CursorManager(IModHelper helper)
        {
            this.helper = helper;
        }

        public void HandleInput(ButtonPressedEventArgs e)
        {
            if (!Context.IsPlayerFree)
                return;

            if (e.Button == SButton.DPadUp) position.Y -= speed;
            if (e.Button == SButton.DPadDown) position.Y += speed;
            if (e.Button == SButton.DPadLeft) position.X -= speed;
            if (e.Button == SButton.DPadRight) position.X += speed;

            if (e.Button == SButton.A)
            {
                Game1.setMousePosition((int)position.X, (int)position.Y);
                Game1.pressActionButton(Game1.input.GetMouseState().X, Game1.input.GetMouseState().Y);
            }
        }

        public void Update()
        {
            if (!visible)
                return;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!visible)
                return;

            spriteBatch.Draw(
                Game1.mouseCursors,
                position,
                Game1.getSourceRectForStandardTileSheet(Game1.mouseCursors, 0, 16, 16),
                Color.White,
                0f,
                Vector2.Zero,
                4f,
                SpriteEffects.None,
                1f
            );
        }
    }
}