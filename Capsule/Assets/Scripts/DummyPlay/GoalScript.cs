using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public GameObject ClearEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(ClearEffect);

            Invoke("MoveToResult", 3);
        }
    }

    private void MoveToResult()
    {
        SceneManager.LoadScene("Result", LoadSceneMode.Additive);
    }
}
