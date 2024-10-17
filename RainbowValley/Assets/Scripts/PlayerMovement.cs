using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 targetPos;
    float spd = 5f;
    bool isMoving = false;

    void Awake()
    {
        transform.position = new Vector3(77.5f, 0.6f, 2);
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    IEnumerator Movement() 
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f) 
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, spd * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    void Move(Vector3 newPos) 
    {
        targetPos = newPos;
        StartCoroutine(Movement());
    }

    void PressKeys() 
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            Move(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
        } 
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1));
        } 
        else if (Input.GetKeyDown(KeyCode.W)) 
        {
            Move(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
        } 
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            Move(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
        }
    }

    void Update()
    {
        if (!isMoving && Input.anyKeyDown)
        {
            PressKeys();
        }
    }
}
