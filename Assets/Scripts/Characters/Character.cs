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

    //quest?
    public Quest qCharacterQuest;

    public bool bIsTheQuestActive = false; //is the quest active
    public bool bIsQuestCompleted = false; //is the quest completed


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
        }
    }



    void InteractedWith()
    {
        LocationTracker lt = FindAnyObjectByType<LocationTracker>();

        if (QuestHandInCheck()) //if quest can be handed in //hand in
        {
            bIsTheQuestActive = false;
            bIsQuestCompleted = true;
            gDialogBox.gameObject.GetComponent<Text>().text = qCharacterQuest.sCompletedDialog;
        }
        else if (bIsQuestCompleted == false) //is the quest not completed
        {
            if (lt.HasAreaBeenAccessed(qCharacterQuest.sAreaName) == true) //has the area required to start the quest been accessed
            {
                bIsTheQuestActive = true;
                gDialogBox.gameObject.GetComponent<Text>().text = qCharacterQuest.sQuestPrompt;
            }
            else //idle
            {
                gDialogBox.gameObject.GetComponent<Text>().text = sIdleDialog;
            }
        }
        else //if quest not just handed in //if quest not active
        {
            if (bIsQuestCompleted == true) //if the quest is completed
            {
                if (lt.GetMostVistedArea().gameObject.name == qCharacterQuest.sSpecialAreaName)
                {
                    gDialogBox.gameObject.GetComponent<Text>().text = qCharacterQuest.sSpecialConditionMetDialog;
                }
                else
                {
                    gDialogBox.gameObject.GetComponent<Text>().text = sIdleDialog;
                }
            }
            else //idle 
            {
                gDialogBox.gameObject.GetComponent<Text>().text = sIdleDialog;
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
            if (g.gameObject.name == qCharacterQuest.sItemName) //if the item needed for the quest has been found
            {
                pt.RemovePickUpObject(g); //remove the item from the list
                return true;
            }
        }
        return false;
    }

















}

