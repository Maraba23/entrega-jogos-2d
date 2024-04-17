using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add me!!

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void OnPlay2RoomButton ()
    {
        SceneManager.LoadScene("2 Room");
    }

    public void OnPlay3RoomButton ()
    {
        SceneManager.LoadScene("3 Room");
    }

    public void OnPlay4RoomButton ()
    {
        SceneManager.LoadScene("4 Room");
    }

    public void OnPlay5RoomButton ()
    {
        SceneManager.LoadScene("5 Room");
    }
    public void OnPlay6RoomButton ()
    {
        SceneManager.LoadScene("6 Room");
    }
    public void OnPlay7RoomButton ()
    {
        SceneManager.LoadScene("7 Room");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
