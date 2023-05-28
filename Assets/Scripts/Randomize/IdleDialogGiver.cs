/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 26/05/2023
/// Purpose : give dialog for both idle and hints to all the characters within the scene
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleDialogGiver : MonoBehaviour
{
    [Multiline] public List<string> li_sIdleDialogOptions = new List<string>(); //all idle dialog options
    [Multiline] public List<string> li_sHints = new List<string>(); //all dialog hints

    /// <summary>
    /// gives all the characters in the scene an idle dialog
    /// </summary>
    public void GiveIdleDialog()
    {
        Character[] goCharacters = FindObjectsOfType<Character>(); //find all the npcs in the world

        foreach (Character c in goCharacters)
        {
            int iToUse = Random.Range(0, li_sIdleDialogOptions.Count); //get a random dialog to use
            c.sIdleDialog = li_sIdleDialogOptions[iToUse]; //set the dialog option of the npc
            li_sIdleDialogOptions.RemoveAt(iToUse); //remove to avoid duplicate idle dialogs appearing
        }
    
    }

    /// <summary>
    /// give all characters found in scene a hint
    /// </summary>
    public void GiveHints()
    {
        Character[] goCharacters = FindObjectsOfType<Character>(); //find all the npcs in the world

        foreach (Character c in goCharacters)
        {
            int iToUse = Random.Range(0, li_sHints.Count); //get a random dialog to use
            c.sQuestHint = li_sHints[iToUse]; //set the dialog option of the npc
            li_sHints.RemoveAt(iToUse); //remove to avoid duplicate idle dialogs appearing
        }
    }


}
