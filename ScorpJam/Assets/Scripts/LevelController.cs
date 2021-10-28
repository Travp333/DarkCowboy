using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject pauseMenu;
    public GameObject player;
    bool pause = false;
    public AudioMixer mixer;
    public Slider slider;
    
    
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
                inventoryUI.SetActive(true);
                pauseMenu.SetActive(true);
                player.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0;
                Debug.Log("paused");
            }
            if (pause)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                inventoryUI.SetActive(false);
                player.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("unpaused");
            }
            pause = !pause;
        }
    }

    public void SetLevel(float sliderValue) {
        float adjVol = Mathf.Log10(sliderValue) * 20;
        mixer.SetFloat("Volume", adjVol);
        PlayerPrefs.SetFloat("Volume", adjVol); 
    }
}
