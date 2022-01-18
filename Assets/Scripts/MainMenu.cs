using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    
    public string SceneSauvegarde = "";

    public void NewGame()
    {
        Debug.Log("Lance la première partie UwU WOULA!!");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        Debug.Log("Continue la partie XwX WOULA!!");
        /*if (SceneSauvegarde == "")
        {
            SceneManager.LoadScene(1);
        }
        SceneManager.LoadScene(SceneSauvegarde);*/
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
        Debug.Log("QUIT WOULA!!");
        Application.Quit();
    }
}