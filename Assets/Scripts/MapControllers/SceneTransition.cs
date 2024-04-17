using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;

    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName)
    {
        // Fade out (tela fica preta)
        yield return StartCoroutine(Fade(1));
        // Carrega a cena
        SceneManager.LoadScene(sceneName);
        // Fade in (tela clareia)
        yield return StartCoroutine(Fade(0));
    }

    IEnumerator Fade(float targetAlpha)
    {
        float alpha = fadePanel.color.a;
        
        for (float t = 0f; t < 1f; t += Time.deltaTime / fadeDuration)
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, targetAlpha, t));
            fadePanel.color = newColor;
            yield return null;
        }
    }
}
