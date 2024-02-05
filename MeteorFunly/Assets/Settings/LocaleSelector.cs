using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    //English ID = 0
    //Turkish ID = 1 and goes on for other additional languages

    private bool active = false;
    
    private const string LocaleIDKey = "SelectedLocaleID";
    
    void Start()
    {
        // Load the saved locale ID, defaulting to 0 (English) if not present
        int savedLocaleID = PlayerPrefs.GetInt(LocaleIDKey, 0);
        StartCoroutine(SetLocale(savedLocaleID));
    }
    
    public void ChangeLocale(int localeID)
    {
        if (active)
            return;
        StartCoroutine(SetLocale(localeID));
    }
    
    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        
        PlayerPrefs.SetInt(LocaleIDKey, _localeID);
        PlayerPrefs.Save();
        
        active = false;
    }
}
