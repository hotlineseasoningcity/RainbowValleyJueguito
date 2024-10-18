using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    public GameObject creature;
    public float time;
    public TMP_Text txt;

    void ChangeColor()
    {
        time += Time.deltaTime;

        Color color = Color.HSVToRGB(time % 1, 1, 1);
        txt.color = color;
    }

    void Rotate()
    {
        creature.transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    void Update()
    {
        ChangeColor();
        Rotate();
    }
}
