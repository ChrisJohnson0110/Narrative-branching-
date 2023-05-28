/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] GameObject gDialogBox;

    public string sIdleDialog = ""; //default dialog if no conditions met
    public string sQuestHint = ""; //default dialog if no conditions met

    //quest?
    public Quest qCharacterQuest;

    bool bIsQuestOneActive = false; //quest one active
    bool bIsQuestTwoActive = false; //qwust two active

    bool bCanPickQuestOne = false;
    bool bCanPickQuestTwo = false;

    bool bQuestComplete = false;


    //popup timer
    float fTimer;
    [SerializeField] float fTimerStart = 5f;
    bool bTimerActive = false;

    //interact cooldown
    float fTimerInteract;
    [SerializeField] float fTimeBetweenInteraction = 1f;
    bool bInteractTimerActive = false;

    private void Start()
    {
        fTimer = fTimerStart; //set timer duration
        gDialogBox.SetActive(false); //hide dialog box
    }

    private void Update()
    {
        if (bTimerActive == true) //if the timer hould be running
        {
            fTimer -= Time.deltaTime; //decrease the time
            if (fTimer <= 0) //check if zero'd
            {
                bTimerActive = false; //disable timer
                gDialogBox.SetActive(false); //hide dialog box
            }
        }

        if (bInteractTimerActive == true)
        {
            fTimerInteract -= Time.deltaTime;
            if (fTimerInteract <= 0) //check if time up
            {
                bInteractTimerActive = false;
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player walks into
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (bInteractTimerActive == false)
                {
                    InteractedWith();
                    bInteractTimerActive = true;
                    fTimerInteract = fTimeBetweenInteraction;
                }
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                QuestPick(1);
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                QuestPick(2);
            }
        }
    }

    /// <summary>
    /// set the active quest based on given number
    /// </summary>
    /// <param name="a_iQuestToActivate"></param>
    void QuestPick(int a_iQuestToActivate)
    {
        if (a_iQuestToActivate == 1)
        {
            bIsQuestOneActive = true;
        }
        else if (a_iQuestToActivate == 2)
        {
            bIsQuestTwoActive = true;
        }
    }


    void InteractedWith()
    {
        LocationTracker lt = FindAnyObjectByType<LocationTracker>();

        gDialogBox.gameObject.GetComponent<Text>().text = sIdleDialog; //idle dialog

        //if neither quest is active
        if (bIsQuestOneActive == false)
        {
            if (bIsQuestTwoActive == false)
            {

                if (bQuestComplete == false) //if quest not completed
                {
                    if (lt.HasAreaBeenAccessed(qCharacterQuest.sQuestConditionOne) == true) //if area has been accessed
                    {
                        bCanPickQuestOne = true;
                    }
                    if (lt.GetMostVistedArea().gameObject.name == qCharacterQuest.sQuestConditionTwo) //if the most visited area is
                    {
                        bCanPickQuestTwo = true;
                    }

                    if (bCanPickQuestOne | bCanPickQuestTwo) //if quest one or two can be picked
                    {
                        gDialogBox.gameObject.GetComponent<Text>().text = "Here are the quests I can give: <color=red>Quest one-" + bCanPickQuestOne.ToString() +
                            "</color> <color=blue>Quest two-" + bCanPickQuestTwo.ToString() + "</color> Press one or two to pick";
                    }
                }

            }
        }

        if (bQuestComplete == true) //if either quest has been completed
        {
            gDialogBox.gameObject.GetComponent<Text>().text = sQuestHint;
        }

        if (bIsQuestOneActive == true)
        {
            if (QuestHandInCheck() == true) //if quest complete
            {
                gDialogBox.gameObject.GetComponent<Text>().text = qCharacterQuest.sQuestCompleteOne;
                bQuestComplete = true;
            }
            else
            {
                gDialogBox.gameObject.GetComponent<Text>().text = qCharacterQuest.sQuestPromptOne;
            }
        }
        else if (bIsQuestTwoActive == true)
        {
            if (QuestHandInCheck() == true) //if quest complete
            {
                gDialogBox.gameObject.GetComponent<Text>().text = qCharacterQuest.sQuestCompleteTwo;
                bQuestComplete = true;
            }
            else
            {
                gDialogBox.gameObject.GetComponent<Text>().text = qCharacterQuest.sQuestPromptTwo;
            }
        }

        


        gDialogBox.SetActive(true); //show the characters dialog

        //start the timer for how long the dialog will be visable
        fTimer = fTimerStart;
        bTimerActive = true;
    }


    /// <summary>
    /// check if condition met to complete quest
    /// </summary>
    bool QuestHandInCheck()
    {
        PickupTracker pt = FindAnyObjectByType<PickupTracker>();

        foreach (GameObject g in pt.li_gPickedUpObjects)
        {
            if (bIsQuestOneActive == true) //if quest one is active
            {
                if (g.gameObject.name.Contains(qCharacterQuest.sQuestOneItem)) //if the item needed for quest one is found
                {
                    pt.RemovePickUpObject(g); //remove the item from the list
                    return true;
                }
            }
            else if (bIsQuestTwoActive == true) //if quest two is active
            {
                if (g.gameObject.name.Contains(qCharacterQuest.sQuestTwoItem)) //if the item needed for quest two is found
                {
                    pt.RemovePickUpObject(g); //remove the item from the list
                    return true;
                }
            }
        }
        return false;
    }

















}

