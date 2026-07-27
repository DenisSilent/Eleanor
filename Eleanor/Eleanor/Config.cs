using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Eleanor
{
    /// <summary>The mod entry point; handles internal ON/OFF config.</summary>
    internal sealed class Config_file : Mod // maybe Configfile
    {
        private ModConfig? Config;

        public override void Entry(IModHelper helper)
        {
             // Load the config
            this.Config = this.Helper.ReadConfig<ModConfig>();

            // Initialize the install checker
            var installChecker = new InstallChecker(helper, this.Monitor);
            installChecker.Initialize();

            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
        }

    // GMCM part
        // see https://github.com/spacechase0/StardewValleyMods/tree/develop/framework/GenericModConfigMenu
        private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            // get Generic Mod Config Menu's API (if it's installed)
            var configMenu = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu is null)
                return;

            // register mod
            configMenu.Register(
                mod: this.ModManifest,
                reset: () => this.Config = new ModConfig(),
                save: () => { if (this.Config != null) this.Helper.WriteConfig(this.Config); }
            );

            // add some config options
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => this.Helper.Translation.Get("config.smapi_component.name"),
                tooltip: () => this.Helper.Translation.Get("config.smapi_component.tooltip"),
                getValue: () => this.Config?.Eleanor_SMAPI_on ?? true,
                setValue: value => { if (this.Config != null) this.Config.Eleanor_SMAPI_on = value; }
            );

            /*
            // Section Title
            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => this.Helper.Translation.Get("config.example.section_title"),
                tooltip: () => this.Helper.Translation.Get("config.example.tooltip")
            );

            // Paragraph
            configMenu.AddParagraph(
                mod: this.ModManifest,
                text: () => this.Helper.Translation.Get("config.example.paragraph")
            );

            // Image
            configMenu.AddImage(
                mod: this.ModManifest,
                texture: () => this.Helper.ModContent.Load<Texture2D>("assets/image.png"),
                texturePixelArea: new Rectangle(0, 0, 16, 16),
                scale: 4
            );

            // Number Option (int)
            configMenu.AddNumberOption(
                mod: this.ModManifest,
                name: () => this.Helper.Translation.Get("config.example.int_option.name"),
                tooltip: () => this.Helper.Translation.Get("config.example.tooltip"),
                getValue: () => this.Config?.ExampleInt ?? 0,
                setValue: value => { if (this.Config != null) this.Config.ExampleInt = value; },
                min: 0,
                max: 10,
                interval: 1
            );

            // Number Option (float)
            configMenu.AddNumberOption(
                mod: this.ModManifest,
                name: () => this.Helper.Translation.Get("config.example.float_option.name"),
                tooltip: () => this.Helper.Translation.Get("config.example.tooltip"),
                getValue: () => this.Config?.ExampleFloat ?? 0f,
                setValue: value => { if (this.Config != null) this.Config.ExampleFloat = value; },
                min: 0f,
                max: 10f,
                interval: 0.1f
            );

            // Text Option
            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => this.Helper.Translation.Get("config.example.text_option.name"),
                tooltip: () => this.Helper.Translation.Get("config.example.tooltip"),
                getValue: () => this.Config?.ExampleString ?? "value1",
                setValue: value => { if (this.Config != null) this.Config.ExampleString = value; },
                allowedValues: new[] { "value1", "value2" },
                formatAllowedValue: value => this.Helper.Translation.Get($"config.example.text_option.value.{value}")
            );

            // Keybind
            configMenu.AddKeybind(
                mod: this.ModManifest,
                name: () => this.Helper.Translation.Get("config.example.keybind.name"),
                tooltip: () => this.Helper.Translation.Get("config.example.tooltip"),
                getValue: () => this.Config?.ExampleKeybind ?? SButton.None,
                setValue: value => { if (this.Config != null) this.Config.ExampleKeybind = value; }
            );

            // Keybind List
            configMenu.AddKeybindList(
                mod: this.ModManifest,
                name: () => this.Helper.Translation.Get("config.example.keybind_list.name"),
                tooltip: () => this.Helper.Translation.Get("config.example.tooltip"),
                getValue: () => this.Config?.ExampleKeybindList ?? KeybindList.None,
                setValue: value => { if (this.Config != null) this.Config.ExampleKeybindList = value; }
            );

            // Page
            configMenu.AddPage(
                mod: this.ModManifest,
                pageId: "page1",
                pageTitle: () => this.Helper.Translation.Get("config.example.page.title")
            );

            // Page Link
            configMenu.AddPageLink(
                mod: this.ModManifest,
                pageId: "page1",
                text: () => this.Helper.Translation.Get("config.example.page_link.text"),
                tooltip: () => this.Helper.Translation.Get("config.example.tooltip")
            );

            // Subheader
            configMenu.AddSubHeader(
                mod: this.ModManifest,
                text: () => this.Helper.Translation.Get("config.example.subheader.text")
            );
            */
        }

        public sealed class ModConfig
        {
            public bool Eleanor_SMAPI_on { get; set; } = true;
            /*
            public string ExampleDropdown { get; set; } = "Option 1";
            public int ExampleInt { get; set; } = 0;
            public float ExampleFloat { get; set; } = 0f;
            public string ExampleString { get; set; } = "value1";
            public SButton ExampleKeybind { get; set; } = SButton.None;
            public KeybindList ExampleKeybindList { get; set; } = KeybindList.None;
            */
        }
    }

    /// <summary>The API which lets other mods add a config UI through Generic Mod Config Menu.</summary>
    public interface IGenericModConfigMenuApi
    {
        void Register(IManifest mod, Action reset, Action save, bool titleScreenOnly = false);
        /*
        void AddSectionTitle(IManifest mod, Func<string> text, Func<string>? tooltip = null);
        void AddSubHeader(IManifest mod, Func<string> text);
        void AddParagraph(IManifest mod, Func<string> text);
        void AddImage(IManifest mod, Func<Texture2D> texture, Rectangle? texturePixelArea = null, int scale = Game1.pixelZoom);
        */
        void AddBoolOption(IManifest mod, Func<bool> getValue, Action<bool> setValue, Func<string> name, Func<string>? tooltip = null, string? fieldId = null);
        /*
        void AddNumberOption(IManifest mod, Func<int> getValue, Action<int> setValue, Func<string> name, Func<string>? tooltip = null, int? min = null, int? max = null, int? interval = null, Func<int, string>? formatValue = null, string? fieldId = null);
        void AddNumberOption(IManifest mod, Func<float> getValue, Action<float> setValue, Func<string> name, Func<string>? tooltip = null, float? min = null, float? max = null, float? interval = null, Func<float, string>? formatValue = null, string? fieldId = null);
        void AddTextOption(IManifest mod, Func<string> getValue, Action<string> setValue, Func<string> name, Func<string>? tooltip = null, string[]? allowedValues = null, Func<string, string>? formatAllowedValue = null, string? fieldId = null);
        void AddKeybind(IManifest mod, Func<SButton> getValue, Action<SButton> setValue, Func<string> name, Func<string>? tooltip = null, string? fieldId = null);
        void AddKeybindList(IManifest mod, Func<KeybindList> getValue, Action<KeybindList> setValue, Func<string> name, Func<string>? tooltip = null, string? fieldId = null);
        void AddPage(IManifest mod, string pageId, Func<string>? pageTitle = null);
        void AddPageLink(IManifest mod, string pageId, Func<string> text, Func<string>? tooltip = null);
        void AddComplexOption(IManifest mod, Func<string> name, Action<SpriteBatch, Vector2> draw, Func<string>? tooltip = null, Action? beforeMenuOpened = null, Action? beforeSave = null, Action? afterSave = null, Action? beforeReset = null, Action? afterReset = null, Action? beforeMenuClosed = null, Func<int>? height = null, string? fieldId = null);
        void SetTitleScreenOnlyForNextOptions(IManifest mod, bool titleScreenOnly);
        void OnFieldChanged(IManifest mod, Action<string, object> onChange);
        void OpenModMenu(IManifest mod);
        void OpenModMenuAsChildMenu(IManifest mod);
        bool TryGetCurrentMenu(out IManifest mod, out string page);
        */
    }
}