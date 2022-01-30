using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public GameObject ClearEffect;
    private bool FlagEffect = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && FlagEffect)
        {
            SceneManager.LoadScene("Result", LoadSceneMode.Additive);

            FlagEffect = false;
        }
    }

    private void MoveToResult()
    {
    }
}
