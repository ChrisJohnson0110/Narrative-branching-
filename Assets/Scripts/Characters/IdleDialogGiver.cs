/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 26/05/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleDialogGiver : MonoBehaviour
{
    [SerializeField] List<string> li_sIdleDialogOptions = new List<string>();
    List<string> li_sDialogWorkingList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        li_sDialogWorkingList = li_sIdleDialogOptions; //load the given list into the working list

        Character[] goCharacters = FindObjectsOfType<Character>(); //find all the npcs in the world

        foreach (Character c in goCharacters)
        {
            int iToUse = Random.Range(0, li_sDialogWorkingList.Count); //get a random dialog to use

            c.sIdleDialog = li_sDialogWorkingList[iToUse]; //set the dialog option of the npc

            li_sDialogWorkingList.RemoveAt(iToUse); //remove to avoid duplicate idle dialogs appearing
        }

    }
}
