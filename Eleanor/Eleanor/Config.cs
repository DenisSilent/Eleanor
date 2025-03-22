using StardewModdingAPI;

namespace Eleanor
{
    /// <summary>The mod entry point.</summary>
    internal sealed class Config_file : Mod
    {
        private ModConfig? Config;

        public override void Entry(IModHelper helper)
        {
            // Load the config
            this.Config = this.Helper.ReadConfig<ModConfig>();

            // Initialize the install checker
            var installChecker = new InstallChecker(helper, this.Monitor);
            installChecker.Initialize();
        }

        public sealed class ModConfig
        {
            public bool Eleanor_SMAPI_on { get; set; } = true;
        }
    }
}