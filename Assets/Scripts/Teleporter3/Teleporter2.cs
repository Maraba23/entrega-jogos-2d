using UnityEngine;

public class Teleporter2 : MonoBehaviour
{
    public string objectToTeleportTag = "Player1";
    public string targetLocationTag = "Teleporter2";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
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
