using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour
{
    public string tagOfFirstObject = "Player1";
    public string tagOfSecondObject = "Player2";
    public float cooldownTime = 2f;
    private bool canSwap = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag(tagOfFirstObject) || collision.gameObject.CompareTag(tagOfSecondObject)) && canSwap)
        {
            GameObject firstObject = GameObject.FindGameObjectWithTag(tagOfFirstObject);
            GameObject secondObject = GameObject.FindGameObjectWithTag(tagOfSecondObject);

            if (firstObject != null && secondObject != null)
            {
                Vector3 tempPosition = firstObject.transform.position;
                firstObject.transform.position = secondObject.transform.position;
                secondObject.transform.position = tempPosition;
                
                canSwap = false;
                StartCoroutine(ResetSwapCooldown());
            }
            else
            {
                Debug.LogError("Um dos objetos não foi encontrado. Verifique se as tags estão corretas e aplicadas aos objetos.");
            }
        }
    }

    IEnumerator ResetSwapCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canSwap = true;
    }
}
