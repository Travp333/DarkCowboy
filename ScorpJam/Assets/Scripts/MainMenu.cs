using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu, OptionsMenu;

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
    }
    public void BackToMainMenu() {
        Menu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
}
