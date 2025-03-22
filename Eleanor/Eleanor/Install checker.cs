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
                this.Monitor.Log("The SMAPI part of the [NPC] Eleanor mod is disabled in the config file. This message (you shouldn't even see normally, if not using Debug SMAPI version or if you're not looking at SMAPI log with Trace messages enabled) is the only thing that the SMAPI part does right now.", LogLevel.Trace);
                return;
            }

            // ELSE IF Eleanor's CP part is not installed correctly
            if (!this.Helper.ModRegistry.IsLoaded("StrojvedouciDenis.Eleanor"))
            {
                this.Monitor.Log(" ", LogLevel.Error);
                this.Monitor.Log("! WARNING !", LogLevel.Error);
                this.Monitor.Log(" ", LogLevel.Error);
                this.Monitor.Log("The [CP] Eleanor part of the [NPC] Eleanor is installed incorrectly.", LogLevel.Error);
                this.Monitor.Log("Please check the errors section above to see what is wrong.", LogLevel.Error);
                this.Monitor.Log("We recommend deleting the mod and installing it again.", LogLevel.Error);
                this.Monitor.Log("Don't hesitate to reach out for support!", LogLevel.Error);
                this.Monitor.Log(" ", LogLevel.Error);
                this.Monitor.Log("! WARNING !", LogLevel.Error);
                this.Monitor.Log(" ", LogLevel.Error);
            }
            // ELSE installed correctly
            else
            {
                this.Monitor.Log($"The mod [NPC] Eleanor and all of its components have been successfully launched.", LogLevel.Debug);
            }
        }
    }
}