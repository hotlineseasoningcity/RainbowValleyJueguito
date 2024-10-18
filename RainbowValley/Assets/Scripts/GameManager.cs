using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public PlayerHealth playerHealth;

    void Victory()
    {
        SceneManager.LoadScene("Victory");
    }

    void Defeat()
    {
        if (playerHealth.isDead)
        {
            SceneManager.LoadScene("Defeat");
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene("Game");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Victory();
        }
    }

    void Update()
    {
        Defeat();
    }
}
