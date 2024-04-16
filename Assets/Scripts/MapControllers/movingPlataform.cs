using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlataform : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float speed = 0.3f;

    private void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector2.Lerp(startPoint, endPoint, time);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPoint, endPoint);
    }
}
