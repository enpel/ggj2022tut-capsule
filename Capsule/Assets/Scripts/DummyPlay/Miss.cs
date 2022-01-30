using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core.Global;
using Sound;

public class Miss : MonoBehaviour
{
    static 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Global.SoundPlayer.PlaySE(SeType.GariPunch);
            SceneManager.LoadScene("PreInGame");
        }
    }
}
