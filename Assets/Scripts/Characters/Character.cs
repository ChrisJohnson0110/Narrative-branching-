/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] GameObject gDialogBox;

    bool bPlayerHasInteractedWith = false;


    public string sIdleDialog = ""; //default dialog if no conditions met

    //quest?
    public Quest qCharacterQuest;



    public bool bIsTheQuestActive; //is the quest active


    //popup timer
    float fTimer;
    [SerializeField] float fTimerStart = 5f;
    bool bTimerActive = false;

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

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player walks into
        {
            if (Input.GetKey(KeyCode.E))
            {
                InteractedWith();
            }
        }
    }



    void InteractedWith()
    {
        gDialogBox.SetActive(true); //show the characters dialog
        bPlayerHasInteractedWith = true; //store that the character has been interacted with

        //start the timer for how long the dialog will be visable
        fTimer = fTimerStart;
        bTimerActive = true;
    }























}

