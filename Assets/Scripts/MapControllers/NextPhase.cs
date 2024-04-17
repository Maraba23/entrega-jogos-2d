using UnityEngine.SceneManagement;
using UnityEngine;

public class NextPhase : MonoBehaviour
{

    public string targetTag;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) || targetTag == "Any")
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        string name = SceneManager.GetActiveScene().name;
        string next_name = (int.Parse(name.Split(' ')[0]) + 1).ToString() + " Room";
        FindObjectOfType<SceneTransition>().LoadNextScene(next_name);
    }

}
