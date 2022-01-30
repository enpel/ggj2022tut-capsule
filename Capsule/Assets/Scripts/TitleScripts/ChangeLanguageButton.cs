using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ChangeLanguageButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    
    

    // Start is called before the first frame update
    async void  Start()
    {
        await LocalizationSettings.InitializationOperation;
        
        int _currentLocateIndex = 0;
        _currentLocateIndex = LocalizationSettings.AvailableLocales.Locales.FindIndex(x => x == LocalizationSettings.SelectedLocale);
        if (_currentLocateIndex < 0) _currentLocateIndex = 0;
        
        _button.OnClickAsObservable().Subscribe(x =>
        {
            var nextIndex = _currentLocateIndex;
            nextIndex++;
            if (nextIndex >= LocalizationSettings.AvailableLocales.Locales.Count)
            {
                nextIndex = 0;
            }
        
            _currentLocateIndex = nextIndex;
            LocalizationSettings.SelectedLocale =  LocalizationSettings.AvailableLocales.Locales[nextIndex];
        }).AddTo(this);
    }
    
    

}
