using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaiMenuManager : MonoBehaviour
{
    //This script will allow bring functionality to ahndle the showing of the main menu and credits menu\

    //Needs to "Deactivate" main menu
    //Code Reference: gameobject.SetActive(False)
    //Needs to "Activate" Credits Pannel
    //Code Reference: gameobject.SetActive(True)
    //Needs to allow the reverse as well (Activate main menu, Deactivate Credits)


    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsPannel;


    private void Start()
    {
        //Default state of the main menu

        mainMenu.SetActive(true);
        creditsPannel.SetActive(false);

        //Debug statement to make sure the default main menu has loaded

        Debug.Log("The default main menu has loaded");
    }

    // Start and quit the game using public variables and the button list
    public void StartButton()
    {
        //Start the game

        Debug.Log("Player has started the game");

    }

    public void QuitButton()
    {
        //Quit the game

        Debug.Log("Player has quit the game");
        
    }


    //This code used to actually load the scene desired (for game start button)
    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);

    }


    // Code for the activation of main menu and credits UI
    public void SetInactiveMainMenu()
    {
        //Disable Main Menu 

        mainMenu.SetActive(false);

    }

    public void SetActiveMainMenu()
    {
        //Enable Main Menu

        mainMenu.SetActive(true);

    }

    public void SetInactiveCredits()
    {
        //Disable Credists

        creditsPannel.SetActive(false);

    }

    public void SetActiveCredits()
    {
        //Enable Credits

        creditsPannel.SetActive(true);

    }
}

