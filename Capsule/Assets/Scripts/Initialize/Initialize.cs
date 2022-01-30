using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class Initialize : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        await LocalizationSettings.InitializationOperation.ToUniTask();

        SceneManager.LoadScene("Title");
    }
}
