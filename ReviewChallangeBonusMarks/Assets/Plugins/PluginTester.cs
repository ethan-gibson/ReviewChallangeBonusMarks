using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
public class PluginTester : MonoBehaviour
{
	public TextMeshProUGUI uiText;
	// Dictionary to hold translations
	private Dictionary<string, Dictionary<string, string>> languages;
	void Start()
	{
		Debug.Log("PluginTester has started!");
		// Load language data from the CSV file
		LoadLanguagesFromCSV();
		// Set the default language to English
		ChangeLanguage("en");
	}
	// Method to load language data from a CSV file
	void LoadLanguagesFromCSV()
	{
		string filePath = Path.Combine(Application.streamingAssetsPath + @"/Languages.csv");
		Debug.Log("" + filePath);
		if (File.Exists(filePath))
		{
			try
			{
				// Read all lines from the CSV file
				string[] lines = File.ReadAllLines(filePath);
				Debug.Log("CSV file loaded. Number of lines: " + lines.Length);
				// Parse the first line to get the language codes
				string[] headers = lines[0].Split(',');
				Debug.Log("Language codes found: " + string.Join(", ", headers.Skip(1))); // Skipping 'Key' column
																						  // Initialize the dictionary
				languages = new Dictionary<string, Dictionary<string, string>>();
				// Skip the first line (headers) and parse the rest of the CSV
				for (int i = 1; i < lines.Length; i++)
				{
					string[] columns = lines[i].Split(',');
					string key = columns[0].Trim(); // The key (e.g., "greeting", "farewell")
					Debug.Log("Found key: " + key);

					// Loop through each language code (starting from the second column)
					for (int j = 1; j < headers.Length; j++)
					{
						string languageCode = headers[j].Trim(); // e.g., "en", "es", "fr"
						string translation = columns[j].Trim(); // The translation text
						if (!languages.ContainsKey(languageCode))
						{
							languages[languageCode] = new Dictionary<string, string>();
						}
						languages[languageCode][key] = translation;
						Debug.Log("Added translation: " + languageCode + " -> " + key + " = " + translation);
					}
				}
				Debug.Log("CSV file loaded and parsed successfully.");
			}
			catch (System.Exception e)
			{
				Debug.LogError("Error loading or parsing CSV file: " + e.Message);
			}
		}
		else
		{
			Debug.LogError("CSV file not found at: " + filePath);
		}
	}
	void ChangeLanguage(string languageCode)
	{
		if (languages == null)
		{
			Debug.LogError("Languages dictionary is null! CSV might not have been loaded correctly.");
			return;
		}
		if (!languages.ContainsKey(languageCode))
		{
			Debug.LogWarning("Language code not found: " + languageCode);
			return;
		}
		if (uiText == null)
		{
			Debug.LogError("UI Text reference is missing! Please assign the UI Text in the inspector.");
			return;
		}

		// Change the text based on the 'greeting' key
		if (languages[languageCode].ContainsKey("text1"))
		{
			uiText.text = languages[languageCode]["text1"];
			Debug.Log("Language changed to: " + languageCode + " with text: " + uiText.text);
		}
		else
		{
			Debug.LogWarning("Key 'text1' not found for language: " + languageCode);
		}
	}
	public void OnLanguageChangeButtonClicked(string newLanguageCode)
	{
		ChangeLanguage(newLanguageCode);
	}
}

