# **Development versions changelog (f.e. 1.0.0-alpha.1)**

This is a changlog including officially unreleased versions of NPC Eleanor. You can download the one you want by browsing the proper [GitHub repo commits page](https://github.com/DenisSilent/Eleanor/commits/development_UNSTABLE!/).

If you want to use any of the unreleased versions, please be aware that they are not tested, they contain probably A LOT of bugs and will easily crash your game (and I don't take any responsibility for that). If you want to use them anyway, please make sure to back up your save files before using them.
Instructions for downloading the unreleased versions:

1. Go to `{{SystemDrive}}:\Users\{{UserName}}\AppData\Roaming\StardewValley` and make a copy of the `Saves` folder, in case anything would go wrong.
2. Go to the [GitHub repo with correct branch](https://github.com/DenisSilent/Eleanor/tree/development_UNSTABLE!).
3. Click on the green button "Code" and select "Download ZIP"
4. Unzip the downloaded file and copy the extracted `[NPC] Eleanor` folder to your `.../Stardew Valley/Mods` folder
5. Test the mod in your game and report any bugs you find to the [GitHub issues page](https://github.com/DenisSilent/Eleanor/issues), please include the version number of the mod you used and a description of the bug, if possible also a screenshot or a video of the bug happening in your game.
6. Enjoy the mod (and its bugs)!

---

## version 1.0.0-alpha.16 (4.5.2025)

* Multi-device connectivity tests
* Fixed A LOT of errors at the new Eleanor's home map
  * Yet found out that NPC pathfinding does not work
* Updated `Pathoschild.Stardew.ModBuildConfig` for the C# part of the mod
* A lot of marriage fixes
* Sprite marriage fixes
* Probably fixed y2 festivals

---

## version 1.0.0-alpha.15 (3.5.2025)

* Multi-device connectivity tests
* Fixed A LOT of errors at the new Eleanor's home map
* Moved the spawning and the fake sleeping point to Eleanor's new home
* Created Idea keeper
* Additonal fixes

---

## version 1.0.0-alpha.14 (1.5.2025)

* Multi-device connectivity tests
* Fixed missing changelog for some versions
* Added and slightly reorginized some dialouges (`RejectMermaidPendant` and `RejectBouquet`)
* Started creating Eleanor's home map
* Created addons file
  * First addon: CT's created with BETAS
* Added 2 false/soft dependencies - BETAS and SpaceCore (for future addons)
* Event formating edits
* Added festival locations

---

## version 1.0.0-alpha.13 (26.4.2025)

* Multi-device connectivity tests
* Fixed missing changelog for some versions
* Added and slightly reorginized some dialouges (`RejectMermaidPendant` and `RejectBouquet`)

---

## version 1.0.0-alpha.12 (25.4.2025)

* Multi-device connectivity tests
* Fixed incorrect mail after Eleanor gets back from summer trip year 1 if Hogwarts mod is installed
* Rewritten the events code (and modernized their preconditions) to be more readable and easier to maintain

---

## version 1.0.0-alpha.11 (20.4.2025)

* Multi-device connectivity tests
* C# maybe fixed itself back again, I don't care right now, I will when I'll get to 1.0.0-beta.1
* Added some marriage dialogues and hopefully fixed them
* Debugging marriage dialogues

---

## version 1.0.0-alpha.10 (20.4.2025)

* Multi-device connectivity tests
* C# maybe fixed itself back again, I don't care right now, I will when I'll get to 1.0.0-beta.1

---

## version 1.0.0-alpha.9 (20.4.2025)

* Multi-device connectivity tests
* C# maybe broke itself, I don't care right now, I will when I'll get to 1.0.0-beta.1
* Manifest version fix one more time (and there will be many more manifest version fixes in the future, I guess)

---

## version 1.0.0-alpha.8 (20.4.2025)

* Multi-device connectivity tests
* That automatic C# change is not bothering me until I run *"dotnet run"* command to compile the C# component's .dll file, and it propably shouldn't matter even then
* Manifest version fix one more time (and there will be many more manifest version fixes in the future, I guess)

---

## version 1.0.0-alpha.7 (20.4.2025)

* Multi-device connectivity tests
* Automatic C# change of the mod location in other device - will check out how many things it'll break

---

## version 1.0.0-alpha.6 (19.4.2025)

* Finally found a valid method to translate the dynamic tokens
* Fixed wrong manifest version (again)
* Parted the changelog to different files

---

## version 1.0.0-alpha.5 (12.4.2025)

* The dialogues fixed themselfs back again!
* Fixed old manifest version

---

## version 1.0.0-alpha.4 (12.4.2025)

* Found out that I broke all the dialogues, testing out!

---

## version 1.0.0-alpha.3 (6.4.2025)

* Fixed a potentionall error with wrong key in gifts
* event commands Discord help by:
  * `@sinz163`
  * `@abagaianye`

---

## version 1.0.0-alpha.2 (5.4.2025)

* Changed development structure - now the `development_UNSTABLE!` GitHub branch is used instead of the `main` branch, that leads to separate development and bugfixing
* version formating Discord help by:
  * `@chu2.718281828459045235360287471`
* Marriage Mermaid pendant dialogue + crashing SMAPI Discord help by:
  * `@abagaianye`
  * `@atravita`
  * `@shockah`
  * `@thelimeydragon`

---

## version 1.0.0-alpha.1 (31.3.2025)

* Fixed the mermaid bouquet (from Polyamory Sweet) fix so now it'll refer to correct i18n key
* Added a mail after Eleanor gets back from summer trip year 1 if Hogwarts mod is installed
* Prepared parts of the dialogues and code for 1.0.0 update
* Rewritten some 14 hearts event dialogues and therefore slightly changed Eleanor's (unrevealed) history
* Cleaned up some code mess
* Fixed some spelling errors here in changelog
* Probably fixed unknown installation check error in CSharp part of the mod
