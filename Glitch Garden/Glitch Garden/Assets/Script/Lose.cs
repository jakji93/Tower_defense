using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    [SerializeField] float baseHealth = 5;
    [SerializeField] Text healthText;
    float gameHealth;

    private void Start()
    {
        gameHealth = baseHealth - PlayerPrefsController.GetDifficulty();
        healthText.text = gameHealth.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameHealth--;
        Destroy(collision.gameObject);
        healthText.text = gameHealth.ToString();
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (gameHealth <= 0)
        {
            FindObjectOfType<LevelController>().HandleLose();
        }
    }

    public float GetHealth()
    {
        return gameHealth;
    }
}
