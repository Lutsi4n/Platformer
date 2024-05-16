using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool isAlive;
    [SerializeField] private Image healthBar;
    //[SerializeField] private GameObject loseImg;
    private Scene crntscene;

    private void Awake()
    {
        crntscene = SceneManager.GetActiveScene();
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (gameObject.name == "Knight")
        {
            healthBar.fillAmount = currentHealth * 0.01f;
        }
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
            isAlive = true;
        else
            isAlive = false;
    }

    private void Update()
    {
        if (isAlive == false)
        {
            Destroy(gameObject);
            //loseImg.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damagable"))
        {
            collision.GetComponent<Health>().TakeDamage(20);
            gameObject.GetComponent<Health>().TakeDamage(100);
            SceneManager.LoadScene(crntscene.buildIndex);
            Time.timeScale = 1f;
        }
    }
}
