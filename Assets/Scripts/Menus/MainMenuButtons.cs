/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 22/05/2023
/// Purpose : Functionality for the menu buttons in the menu scene
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
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
    /// change the displayed menu to the start menu
    /// </summary>
    public void ChangeMenuToStart()
    {
        MainMenuRef.UpdateCurrentMenu(MainMenu.Menus.Start);
    }

    /// <summary>
    /// change the displayed menu to the info menu
    /// </summary>
    public void ChangeMenuToInfo()
    {
        MainMenuRef.UpdateCurrentMenu(MainMenu.Menus.Info);
    }

    /// <summary>
    /// change the displayed menu to the select story menu
    /// </summary>
    public void ChangeMenuToSelect()
    {
        MainMenuRef.UpdateCurrentMenu(MainMenu.Menus.Select);
    }

    /// <summary>
    /// load the first story sscene
    /// </summary>
    public void LoadStorySceneOne()
    {
        SceneManager.LoadScene("StoryOne", LoadSceneMode.Additive);
        MainMenuRef.UpdateCurrentMenu(MainMenu.Menus.InGame);
    }

    /// <summary>
    /// load the second story scene
    /// </summary>
    public void LoadStorySceneTwo()
    {
        SceneManager.LoadScene("StoryTwo", LoadSceneMode.Additive);
        MainMenuRef.UpdateCurrentMenu(MainMenu.Menus.InGame);
    }
    
    /// <summary>
    /// open the form url
    /// </summary>
    public void OpenFormURL()
    {
        Application.OpenURL("https://forms.gle/4k7vW5sGwA1ahDwY9");
    }

}
