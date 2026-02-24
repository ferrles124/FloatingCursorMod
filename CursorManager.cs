using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace FloatingCursorMod
{
    public class CursorManager
    {
        private readonly IModHelper Helper;
        private readonly IMonitor Monitor;

        public CursorManager(IModHelper helper, IMonitor monitor)
        {
            this.Helper = helper;
            this.Monitor = monitor;

            helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            // ✅ HATALI SATIRIN DÜZELTİLMİŞ HALİ
            var p = Game1.getMousePosition();
            Vector2 pos = new Vector2(p.X, p.Y);

            // burada ne yapıyorsan devam
            // örnek:
            // Game1.mouseCursorTransparency = 1f;
        }
    }
}