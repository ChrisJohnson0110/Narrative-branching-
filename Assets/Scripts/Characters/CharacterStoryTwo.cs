/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 28/05/2023
/// Purpose : script to attach to the npcs this handles all character dialog - story two
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStoryTwo : MonoBehaviour
{
    [SerializeField] GameObject goDialogPopupBox;

    [SerializeField] string sQuestPrompt;
    [SerializeField] string sQuestRewardMessage;
    [SerializeField] string sItemRequired;


    [SerializeField] CharacterStoryTwo csPreviousCharacter;

    public bool isQuestActive = false;
    public bool isQuestComplete = false;


    //popup timer
    float fTimer;
    [SerializeField] float fTimerStart = 5f;
    bool bTimerActive = false;

    //interact cooldown
    float fTimerInteract;
    [SerializeField] float fTimeBetweenInteraction = 1f;
    bool bInteractTimerActive = false;


    // Start is called before the first frame update
    void Start()
    {
        fTimer = fTimerStart; //set timer duration
        goDialogPopupBox.SetActive(false); //hide dialog box
    }

    // Update is called once per frame
    void Update()
    {
        if (bTimerActive == true) //if the timer hould be running
        {
            fTimer -= Time.deltaTime; //decrease the time
            if (fTimer <= 0) //check if zero'd
            {
                bTimerActive = false; //disable timer
                goDialogPopupBox.SetActive(false); //hide dialog box
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
                    Interact();
                    bInteractTimerActive = true;
                    fTimerInteract = fTimeBetweenInteraction;
                }
            }
        }
    }

    void Interact()
    {
        goDialogPopupBox.GetComponent<Text>().text = "hmmm";

        if (csPreviousCharacter.isQuestComplete == true) //unlock condition
        {
            if (isQuestActive == false) //no active quest
            {
                if (isQuestComplete == false) //quest not already done
                {
                    goDialogPopupBox.GetComponent<Text>().text = sQuestPrompt;
                    isQuestActive = true;
                }
            }
            else if (isQuestActive == true)
            {
                if (isQuestComplete == false)
                {
                    //check for item
                    if (QuestHandInCheck() == true)
                    {
                        //quest finished
                        goDialogPopupBox.GetComponent<Text>().text = sQuestRewardMessage;
                        isQuestComplete = true;
                    }
                    else
                    {
                        //quest not finished
                        goDialogPopupBox.GetComponent<Text>().text = sQuestPrompt;
                    }
                }
                else
                {
                    //quest is active and complete
                    goDialogPopupBox.GetComponent<Text>().text = "hmm";
                }
                
            }
            
        }

        goDialogPopupBox.SetActive(true); //show the characters dialog

        //start the timer for how long the dialog will be visable
        fTimer = fTimerStart;
        bTimerActive = true;
    }



    /// <summary>
    /// check if condition met to complete quest
    /// </summary>
    bool QuestHandInCheck()
    {
        PickupTracker pt = FindAnyObjectByType<PickupTracker>(); //find pickup tracker

        foreach (GameObject g in pt.li_gPickedUpObjects)
        {
            if (g.gameObject.name.Contains(sItemRequired)) //if the item needed for quest one is found
            {
                pt.RemovePickUpObject(g); //remove the item from the list
                return true;
            }
        }
        return false;
    }


}
