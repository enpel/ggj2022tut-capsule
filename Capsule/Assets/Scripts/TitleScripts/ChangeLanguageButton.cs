using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class ChangeLanguageButton : MonoBehaviour
{

    int _currentLocateIndex = 0;


    // Start is called before the first frame update
    public void ChangeLanguage()
    {
        _currentLocateIndex =
            LocalizationSettings.AvailableLocales.Locales.FindIndex(x => x == LocalizationSettings.SelectedLocale);
        if (_currentLocateIndex < 0) _currentLocateIndex = 0;

        var nextIndex = _currentLocateIndex;
        nextIndex++;
        if (nextIndex >= LocalizationSettings.AvailableLocales.Locales.Count)
        {
            nextIndex = 0;
        }

        _currentLocateIndex = nextIndex;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[nextIndex];
    }
}