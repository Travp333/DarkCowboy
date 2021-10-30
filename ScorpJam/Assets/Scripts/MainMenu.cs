using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject Menu, OptionsMenu;
    [SerializeField]
    public Slider slider;
    [SerializeField]
    public AudioMixer mixer;
    

	private void Start()
	{
        Menu.SetActive(true);
        OptionsMenu.SetActive(false);
        
    }
	public void Play(int index = 1) {
        SceneManager.LoadScene(index);
    }
    public void QuitGame() {
        //fire
        //Application.Quit();
        Debug.Log("quit");
    }
    public void Goobaba()
    {
        Debug.Log("boobaba");
        Invoke("QuitGame", 5f);
    }
    public void Options() {
        Menu.SetActive(false);
        OptionsMenu.SetActive(true);
        slider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
    }
    public void BackToMainMenu() {
        Menu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    public void SetLevel(float sliderValue)
    {
        float adjVol = Mathf.Log10(sliderValue) * 20;
        mixer.SetFloat("Volume", adjVol);
        PlayerPrefs.SetFloat("Volume", adjVol);
    }
}
