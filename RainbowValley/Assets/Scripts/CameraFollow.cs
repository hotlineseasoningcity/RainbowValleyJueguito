using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        float spd = 0.15f;
        Vector3 offset = new(0, 5, -10);

        Vector3 pos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, pos, spd);
        transform.position = smoothPos;

        transform.LookAt(player);
    }
}
