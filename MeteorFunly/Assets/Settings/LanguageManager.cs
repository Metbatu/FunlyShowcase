using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
    void Start()
    {
        string systemLanguageCode = Application.systemLanguage.ToString().ToLower();
        string detectedLanguageCode = MapSystemLanguage(systemLanguageCode);
        SetLanguage(detectedLanguageCode);
    }
    private string MapSystemLanguage(string systemLanguageCode)
    {
        systemLanguageCode = systemLanguageCode.ToLower();
        
        switch (systemLanguageCode)
        {
            case "english":
            case "en":
                return "en";
            case "turkish":
            case "tr":
                return "tr";
            default:
                return "en"; // Default English
        }
    }
    private void SetLanguage(string languageCode)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(languageCode);
    }
}