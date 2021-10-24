using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    bool pause = false;
    void Start()
    {
        pause = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {


            if (!pause)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                player.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;

            }
            if (pause)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                player.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            pause = !pause;
        }
    }

    public void Options() { }
}
