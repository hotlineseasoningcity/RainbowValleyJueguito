using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float spd;
    public GroundGenerator groundGenerator;

    bool isMoving;
    Vector3 finalPos;

    void Move()
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);

        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            if (PosIsWalkable(x, y + 1)) { transform.position += Vector3.forward; }
        }
        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            if (PosIsWalkable(x - 1, y)) { transform.position -= Vector3.right; }
        }
        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            if (PosIsWalkable(x, y - 1)) { transform.position -= Vector3.forward; }
        }
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            if (PosIsWalkable(x + 1, y)) { transform.position += Vector3.right; }
        }
    }

    bool PosIsWalkable(int newX, int newY)
    {
        if (newX == 5 || newX < 0) { return false; }
        if (groundGenerator.grid[newX, newY] == 1) { return false; }

        return true;
    }

    void Update()
    {
        Move();

        if (isMoving)
        {
            if (transform.position != finalPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, finalPos, Time.deltaTime * spd);
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
