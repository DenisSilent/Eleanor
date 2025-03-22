import json
import csv
import os
import re

def remove_comments_from_json_string(json_string):
    json_string = re.sub(r'/\*.*?\*/', '', json_string, flags=re.DOTALL)
    json_string = re.sub(r'//.*?$', '', json_string, flags=re.MULTILINE)
    return json_string

def create_translated_json_files_from_csv(csv_file, original_json_file, output_dir):
    
    print("\nStardew Valley Translation Python Script")
    print("Version 1.0.0")
    print("Created by StrojvedouciDenis (a.k.a. Dennis001) with help (mainly created) by Google Gemini 2.0 Flash Thinking (experimental) AI model.\n")
    
    try:
        with open(original_json_file, 'r', encoding='utf-8') as f:
            json_content_with_comments = f.read()
            json_content_without_comments = remove_comments_from_json_string(json_content_with_comments)
            original_data = json.loads(json_content_without_comments)
    except FileNotFoundError:
        print(f"Error: Original JSON file '{original_json_file}' not found.\n")
        return
    except json.JSONDecodeError as e:
        print(f"Error: Invalid JSON format in '{original_json_file}' after comment removal. Error details: {e}\n")
        return

    translations = {}
    try:
        with open(csv_file, 'r', encoding='utf-8') as csvfile:
            csv_reader = csv.reader(csvfile)

            for _ in range(10):
                next(csv_reader, None)

            language_names_expected = ["German", "Spanish", "Brazilian Portuguese", "Russian", "Japanese", "Simplified Chinese", "Italian", "French", "Korean", "Turkish", "Hungarian"]

            for row_index, row in enumerate(csv_reader):
                if not row or len(row) < 2:
                    continue

                combined_key_english = row[0].strip()
                key = ""
                english_value = ""
                if combined_key_english:
                    parts = combined_key_english.split(': "', 1)
                    key = parts[0].strip().replace('"', '').replace(':', '')
                    if len(parts) > 1:
                        english_value = parts[1].strip().replace('"', '')

                if not key:
                    continue

                translated_values = [val.strip() if val else "" for val in row[2:]]

                translations[key] = translated_values


    except FileNotFoundError:
        print(f"Error: CSV file '{csv_file}' not found.\n")
        return
    except Exception as e:
        print(f"Error reading CSV file '{csv_file}': {e}\n")
        return

    if not os.path.exists(output_dir):
        os.makedirs(output_dir)

    language_names_expected = ["German", "Spanish", "Brazilian Portuguese", "Russian", "Japanese", "Simplified Chinese", "Italian", "French", "Korean", "Turkish", "Hungarian"]
    language_codes = ["de", "es", "pt", "ru", "ja", "zh", "it", "fr", "ko", "tr", "hu"] # Corrected language codes

    for lang_index, lang_code in enumerate(language_codes): # Use language_codes list
        if lang_index >= len(language_names_expected):
            continue

        lang_name = language_names_expected[lang_index] # Get lang_name from language_names_expected for clarity

        translated_data = {}
        for key, value in original_data.items():
            if isinstance(value, str):
                translated_text = translations.get(key, [])[lang_index] if key in translations and lang_index < len(translations[key]) else value
                translated_data[key] = translated_text.strip() if translated_text else value
            else:
                translated_data[key] = value

        output_file_path = os.path.join(output_dir, f"{lang_code}.json") # Use lang_code for filename
        try:
            with open(output_file_path, 'w', encoding='utf-8') as outfile:
                json.dump(translated_data, outfile, indent=2, ensure_ascii=False)
            print(f"Created translated JSON file for {lang_name} ({lang_code}): '{output_file_path}'\n")
        except Exception as e:
            print(f"Error saving translated file for {lang_name} ({lang_code}): {e}\n")

    print("\nAutomated JSON file creation process completed.")
    print(f"\nFiles are saved in the '{output_directory}' folder.\n")


if __name__ == "__main__":
    csv_translation_file = "translations.csv"
    json_original_file = "default.json"
    output_directory = "i18n"

    create_translated_json_files_from_csv(csv_translation_file, json_original_file, output_directory)