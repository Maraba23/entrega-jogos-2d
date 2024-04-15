using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public string objectToTeleportTag = "Player2";
    public string targetLocationTag = "Teleporter1";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            GameObject objectToTeleport = GameObject.FindGameObjectWithTag(objectToTeleportTag);
            
            GameObject targetLocation = GameObject.FindGameObjectWithTag(targetLocationTag);

            if (objectToTeleport != null && targetLocation != null)
            {
                objectToTeleport.transform.position = targetLocation.transform.position;
            }
            else
            {
                Debug.LogWarning("Objeto de teletransporte ou localização de destino não encontrado.");
            }
        }
    }
}
