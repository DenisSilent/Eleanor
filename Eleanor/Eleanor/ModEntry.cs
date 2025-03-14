using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace Eleanor
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        /* Properties */
        /// <summary>The mod configuration from the player.</summary>
        private ModConfig? Config;  // Should there be a ? here? VS Code says so + the game reads it OK...

        /* Public methods */
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {   // Message to console
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            // Config check
            this.Config = this.Helper.ReadConfig<ModConfig>();
            bool exampleBool = this.Config.Eleanor_SMAPI_on;
        }
        // Config itself
        public sealed class ModConfig
        {
            public bool Eleanor_SMAPI_on { get; set; } = true;
        }

        /* Private methods */
        /// <summary>Raised after the game starts loading.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            // Check if the mod with unique ID "StrojvedouciDenis.Eleanor" is loaded
            if (!this.Helper.ModRegistry.IsLoaded("StrojvedouciDenis.Eleanor")) // IF installed incorrectly
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
            else    // ELSE installed correctly
            {   
                this.Monitor.Log($"The mod [NPC] Eleanor and all of its components have been successfully launched.", LogLevel.Debug);
            }
        }
    }
}