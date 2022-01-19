using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Button load;

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("LastArea"))
        {
            load.interactable = false;
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("IntroScene");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastArea"));
    }
    
    public void goToMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void goToOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}