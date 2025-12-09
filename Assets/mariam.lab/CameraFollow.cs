using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Cameraspeed;

    public float offsetX = -3f;   // Move player to the left
    public float offsetY = 1f;    // Slightly higher view

    public float minX, maxX;
    public float minY, maxY;

    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector3 targetPos = new Vector3(
                Target.position.x + offsetX,
                Target.position.y + offsetY,
                -10f
            );

            Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * Cameraspeed);

            float ClampX = Mathf.Clamp(smoothPos.x, minX, maxX);
            float ClampY = Mathf.Clamp(smoothPos.y, minY, maxY);

            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
}
