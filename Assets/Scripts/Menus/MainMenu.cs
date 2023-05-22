/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 22/05/2023
/// Purpose : functionality for switching between menus
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject MainMenuCamera; //camera within main menu scene

    [Header("Menus")]
    [SerializeField] GameObject StartMenu; //start menu ref
    [SerializeField] GameObject InfoMenu; //Info menu ref
    [SerializeField] GameObject StorySelectorMenu; //StorySelect menu ref
    [SerializeField] GameObject InGameMenu; //in game menu ref
    [SerializeField] GameObject StoriesCompleted; //stories completed menu ref

    
    public enum Menus
    { //All menus
        Start,
        Info,
        Select,
        InGame,
        Completed
    }
    [Header("Menus selection")]

    public Menus CurrentMenu = Menus.Start; //Store Current menu

    [Header("Story completetion status")]
    public bool StoryOneComplete = false;
    public bool StoryTwoComplete = false;

    [SerializeField] Button StoryOneButton;
    [SerializeField] Button StoryTwoButton;

    [SerializeField] Color cInactiveButtonColor = new Color(0.5f, 0.5f, 0.5f);

    void Start()
    {
        if (!StartMenu | !InfoMenu | !StorySelectorMenu | !InGameMenu | !StoriesCompleted) //if any menu not found menu will not display
        {
            this.gameObject.SetActive(false);
        }
        UpdateMenu();
    }

    /// <summary>
    /// Switch displayed menu
    /// </summary>
    void UpdateMenu()
    {
        HideAllMenus(); //hide all menus
        switch (CurrentMenu) { //switch between menus

            //////////////////////START////////////////////////
            case Menus.Start:
                StartMenu.SetActive(true); //display start menu
                MainMenuCamera.SetActive(true); //enable main menu camera
                break;
            //////////////////////INFO////////////////////////
            case Menus.Info:
                InfoMenu.SetActive(true); //display info menu
                MainMenuCamera.SetActive(true); //enable main menu camera
                break;
            //////////////////////SELECTED////////////////////////
            case Menus.Select:
                StorySelectorMenu.SetActive(true); //display story select menu
                MainMenuCamera.SetActive(true); //enable main menu camera

                //if story completed disable the button
                if (StoryOneComplete)
                {
                    StoryOneButton.interactable = false;
                    StoryOneButton.image.color = cInactiveButtonColor;
                }
                if (StoryTwoComplete)
                {
                    StoryTwoButton.interactable = false;
                    StoryTwoButton.image.color = cInactiveButtonColor;
                }

                //if both stories have been completed display completed menu instead
                if (StoryOneComplete && StoryTwoComplete) 
                {
                    UpdateCurrentMenu(Menus.Completed);
                }
                break;
            //////////////////////INGAME////////////////////////
            case Menus.InGame:
                InGameMenu.SetActive(true); //display ingame menu
                MainMenuCamera.SetActive(false); //disable main menu camera
                break;
            //////////////////////COMPLETED////////////////////////
            case Menus.Completed:
                StoriesCompleted.SetActive(true); //display ingame menu
                MainMenuCamera.SetActive(true); //disable main menu camera
                break;
        }

    }

    /// <summary>
    /// Hide all menus
    /// </summary>
    void HideAllMenus()
    {
        StartMenu.SetActive(false);
        InfoMenu.SetActive(false);
        StorySelectorMenu.SetActive(false);
        InGameMenu.SetActive(false);
        StoriesCompleted.SetActive(false);

    }


    /// <summary>
    /// update current menu to given menu
    /// </summary>
    /// <param name="a_MenuToDisplay"></param>
    public void UpdateCurrentMenu(Menus a_MenuToDisplay)
    {
        CurrentMenu = a_MenuToDisplay;
        UpdateMenu();
    }
}
