using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace Eleanor
{
    /// <summary>Handles installation checks for the mod.</summary>
    internal sealed class InstallChecker
    {
        private readonly IModHelper Helper;
        private readonly IMonitor Monitor;

        public InstallChecker(IModHelper helper, IMonitor monitor)
        {
            this.Helper = helper;
            this.Monitor = monitor;
        }

        public void Initialize()
        {
            this.Helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
        }

        private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            // IF config "Eleanor_SMAPI_on" is set to false
            if (!this.Helper.ReadConfig<Config_file.ModConfig>().Eleanor_SMAPI_on)
            {
                this.Monitor.Log(
                    this.Helper.Translation.Get("installer.smapi-disabled").Default(this.Helper.Translation.Get("key_not_found")),
                    LogLevel.Trace);
                return;
            }

            // ELSE IF Eleanor's CP part is not installed correctly
            if (!this.Helper.ModRegistry.IsLoaded("StrojvedouciDenis.Eleanor"))
            {
                this.Monitor.Log(" ", LogLevel.Error);
                this.Monitor.Log(this.Helper.Translation.Get("installer.warning").Default(this.Helper.Translation.Get("key_not_found")), LogLevel.Error);
                this.Monitor.Log(" ", LogLevel.Error);
                this.Monitor.Log(this.Helper.Translation.Get("installer.cp-not-installed").Default(this.Helper.Translation.Get("key_not_found")), LogLevel.Error);
                this.Monitor.Log(this.Helper.Translation.Get("installer.check-errors").Default(this.Helper.Translation.Get("key_not_found")), LogLevel.Error);
                this.Monitor.Log(this.Helper.Translation.Get("installer.recommend-reinstall").Default(this.Helper.Translation.Get("key_not_found")), LogLevel.Error);
                this.Monitor.Log(this.Helper.Translation.Get("installer.support-link").Default(this.Helper.Translation.Get("key_not_found")), LogLevel.Error);
                this.Monitor.Log(" ", LogLevel.Error);
                this.Monitor.Log(this.Helper.Translation.Get("installer.warning").Default(this.Helper.Translation.Get("key_not_found")), LogLevel.Error);
                this.Monitor.Log(" ", LogLevel.Error);
                return;
            }
            // ELSE installed correctly
            else
            {
                this.Monitor.Log(this.Helper.Translation.Get("installer.success").Default(this.Helper.Translation.Get("key_not_found")), LogLevel.Debug);
                 return;
            }
        }
    }
}