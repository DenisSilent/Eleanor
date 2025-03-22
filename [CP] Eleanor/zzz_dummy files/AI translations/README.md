# Stardew Valley translations sheet

This guide explains how to use the provided Google Sheet and Python script to translate the i18n's default.json file for your Stardew Valley mod.

Before you continue, please note that both the python script and the table was created by AI.
In this case, it was Google Gemini 2.0 Flash Thinking (experimental) model, used in Google AI Studio.
Before you continue, please be aware that this was created with the usage of AI.  If you prefer not to use AI-generated tools, you may prefer to use alternative translation methods.
Even though the script itself was successfully tested, using it is at your risk!
(the script is open source on the GitHub here: https://github.com/DenisSilent/Eleanor)


Part 1: Using the Google Sheet for Translations

Make a Copy of the Google Sheet:
Open the shared Google Sheet link in your web browser.
Go to the "File" menu and select "Make a copy...". This will create a copy of the sheet in your own Google Drive that you can edit.

Understand the Sheet Structure:
Column A ("Key"): Contains the unique keys from the content.json file. Do not edit this column.
Column B ("English"): Contains the original English text values from content.json. Do not edit this column.
Columns C onwards (Language Columns): Columns C through M are for translations into different languages.
In vanilla Stardew Valley, these are: German, Spanish, Brazilian Portuguese, Russian, Japanese, Simplified Chinese, Italian, French, Korean, Turkish, and Hungarian.

Translate Text Values:
Copy your whole content of your translation file and paste it into the A1 cell in "Vanilla translations" sheet
(note: the original text has to be in English)

Export to CSV:
Once translations are complete (no "Loading...") and reviewed in Google Sheets, go to the "File" menu and select "Download" -> "Comma-separated values (.csv)".
Save the downloaded translations.csv file to the same directory where you will place the Python script and your content.json file (see Part 2).

Part 2: Using the Python Script to Generate Translated JSON Files

Prerequisites:
Python Installed: Make sure you have Python 3.x installed on your computer (download from https://www.python.org/).
googletrans Library (Potentially - if you want to modify the script for direct translation later):
 You might need to install the googletrans library if you plan to modify the Python script for direct translation in the future (although the current script only uses the CSV).
 To install, open your command prompt or terminal and run:
pip install googletrans==4.0.0-rc1

Download and Prepare Files:
Create a new file with a .py file extension, named "translate_script.py".
To the file, copy the WHOLE script in "Python script" sheet.
Save translate_script.py, content.json, and translations.csv in the same directory on your computer.

Run the Python Script:
Open your command prompt or terminal.
Navigate to the directory where you saved the files using the cd command (e.g., cd Documents\TranslationProject).
(or Shift+right mouse click and open the terminal in the folder)
Run the script using the command:
python translate_script.py
Press Enter.

Check the translations folder:
After the script finishes running, a new folder named translations will be created in the same directory.
This folder will contain 11 new .json files: de.json, es.json, fr.json, etc., each containing the translated content for the respective language.

Review Translated JSON Files:
Open the generated xx.json files in a text editor or code editor.
Carefully review the translations in the JSON files to ensure they are accurate and correctly formatted.
Copy these translated xx.json files into the "i18n" folder

DONE!

Important Notes:
Backup: Always make a backup of your original content.json file before running the script.
CSV Format: Ensure you export the Google Sheet to CSV (Comma Separated Values) format.
Review Translations: Machine translation is not perfect. Always review and correct the translations in Google Sheets before running the Python script, and also review the final JSON files.
File Encoding: The Python script assumes UTF-8 encoding for both default.json and translations.csv. Make sure your files are saved with UTF-8 encoding.
Error Handling: If you encounter any errors while running the script, feel free to contact me on Discord (dennis001_81324 on SV server)!

Disclaimer: Do at your own risk!
The script and the sheet is licensed under the MIT Licence. For full licence, see "Licence" sheet or visit here: https://opensource.org/license/mit
(Permissions were granted from Gemini to use and public the script)
