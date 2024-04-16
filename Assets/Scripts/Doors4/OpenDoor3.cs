using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor3 : MonoBehaviour
{
    public string targetTag = "Porta3";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            GameObject target = GameObject.FindGameObjectWithTag(targetTag);

            if (target != null)
            {
                Destroy(target);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Objeto de teletransporte ou localização de destino não encontrado.");
            }
        }
    }
}
