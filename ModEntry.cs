using StardewModdingAPI;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework;

namespace FloatingCursorMod
{
    public class ModEntry : Mod
    {
        private CursorManager cursor;

        public override void Entry(IModHelper helper)
        {
            cursor = new CursorManager(helper, Monitor);

            helper.Events.Input.ButtonPressed += OnButtonPressed;
            helper.Events.GameLoop.UpdateTicked += OnUpdate;
            helper.Events.Display.Rendered += OnRendered;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            cursor.HandleInput(e);
        }

        private void OnUpdate(object sender, UpdateTickedEventArgs e)
        {
            cursor.Update();
        }

        private void OnRendered(object sender, RenderedEventArgs e)
        {
            cursor.Draw(e.SpriteBatch);
        }
    }
}