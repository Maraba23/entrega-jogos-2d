using UnityEngine;

public class Teleporter1 : MonoBehaviour
{
    public string objectToTeleportTag = "Player2"; // Tag do objeto que será teletransportado
    public string targetLocationTag = "Teleporter1"; // Tag do objeto que define o destino do teletransporte

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1")) // Verifica se é o jogador que colidiu com o quadrado
        {
            // Encontrar o objeto que deve ser teletransportado
            GameObject objectToTeleport = GameObject.FindGameObjectWithTag(objectToTeleportTag);
            
            // Encontrar o destino do teletransporte
            GameObject targetLocation = GameObject.FindGameObjectWithTag(targetLocationTag);

            if (objectToTeleport != null && targetLocation != null)
            {
                // Teletransportar o objeto para o destino
                objectToTeleport.transform.position = targetLocation.transform.position;
            }
            else
            {
                // Se um dos objetos não for encontrado, registre um aviso
                Debug.LogWarning("Objeto de teletransporte ou localização de destino não encontrado.");
            }
        }
    }
}
