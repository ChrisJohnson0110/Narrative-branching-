/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 22/05/2023
/// Purpose : Functionality for the menu buttons in game
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour
{
    [SerializeField] MainMenu MainMenuRef;

    // Start is called before the first frame update
    void Start()
    {
        if (MainMenuRef == null)
        {
            MainMenuRef = GameObject.FindObjectOfType<MainMenu>(); //if no menu try to find
        }
        if (MainMenuRef == null)
        {
            gameObject.SetActive(false); //if still no menu hide
        }
    }

    /// <summary>
    /// return to the story select menu
    /// </summary>
    public void ExitStoryCompleted()
    {
        //unload current story scene and mark as completed
        if (SceneManager.GetSceneByName("StoryOne").isLoaded)
        {
            SceneManager.UnloadSceneAsync("StoryOne");
            MainMenuRef.StoryOneComplete = true;
        }
        else if (SceneManager.GetSceneByName("StoryTwo").isLoaded)
        {
            SceneManager.UnloadSceneAsync("StoryTwo");
            MainMenuRef.StoryTwoComplete = true;
        }
        MainMenuRef.UpdateCurrentMenu(MainMenu.Menus.Select); //display story select menu
    }

    /// <summary>
    /// change the displayed menu to the start menu
    /// </summary>
    public void ExitStoryUnComplete()
    {
        //unload current story scene
        if (SceneManager.GetSceneByName("StoryOne").isLoaded)
        {
            SceneManager.UnloadSceneAsync("StoryOne");
        }
        else if (SceneManager.GetSceneByName("StoryTwo").isLoaded)
        {
            SceneManager.UnloadSceneAsync("StoryTwo");
        }
        MainMenuRef.UpdateCurrentMenu(MainMenu.Menus.Select); //display story select menu
    }
}
