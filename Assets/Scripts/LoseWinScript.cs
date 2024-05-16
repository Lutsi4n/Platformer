using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinScript : MonoBehaviour
{
    private Scene crntScene;
    void Start() { crntScene = SceneManager.GetActiveScene(); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathTr"))
            SceneManager.LoadScene(crntScene.buildIndex);
        if (collision.CompareTag("NextLvl"))
        {
            if (crntScene.buildIndex < 5)
            {
                SceneManager.LoadScene(crntScene.buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
