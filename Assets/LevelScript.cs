using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public int health = 100; // Set initial health for the enemy

    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            LoadNextLevel();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}