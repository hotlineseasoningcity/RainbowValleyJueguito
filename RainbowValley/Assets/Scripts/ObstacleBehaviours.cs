using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviours : MonoBehaviour
{
    public float dmg, slowDownFactor, slowDownTime;
    public PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        dmg = Random.Range(0.5f, 3);
    }

    IEnumerator SlowDown(PlayerMovement player)
    {
        player.spd *= slowDownFactor;
        yield return new WaitForSeconds(slowDownTime);
        player.spd /= slowDownFactor;
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDmg(dmg);

            PlayerMovement player = col.gameObject.GetComponent<PlayerMovement>();
            StartCoroutine(SlowDown(player));
        }
    }
}
