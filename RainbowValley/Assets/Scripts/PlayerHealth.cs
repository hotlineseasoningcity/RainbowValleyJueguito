using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float currentHp, hp;
    public bool isDead;
    public TMP_Text hpTxt;

    void Start()
    {
        currentHp = hp;
    }

    public void TakeDmg(float dmg)
    {
        currentHp -= dmg;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        isDead = true;
    }

    void Fall()
    {
        if (transform.position.y < -10)
        {
            Die();
        }
    }

    void Update()
    {
        hpTxt.text = currentHp.ToString();
        Fall();
    }
}
