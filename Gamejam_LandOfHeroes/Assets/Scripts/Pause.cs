using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public GameObject Pausewindow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPausedd();
        }
        Debug.Log("ispaused = " + isPaused);
    }

    public void ButtonPause()
     {
        isPausedd();
     }

    void isPausedd()
    {
        if (isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0f;
            Pausewindow.SetActive(true);
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            Pausewindow.SetActive(false);
        }
    }
}
