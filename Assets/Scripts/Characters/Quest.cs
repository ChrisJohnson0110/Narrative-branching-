/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 26/05/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quests", menuName = "ScriptableObjects/Quest")]
public class Quest : ScriptableObject
{
    //regualar quest
    public string sQuestPrompt = ""; //dialog for quest
    public string sCompletedDialog = ""; //dialog to show on completion
    public string sItemName = ""; //item to obtain or complete interaction with // the bObtained value of the pick up script determines this
    public string sAreaName = ""; //quest condition


    //special condition dialog
    public string sSpecialConditionMetDialog = ""; //dialog to display if the 
    public string sSpecialAreaName = ""; //time to have spent the most time in to meet special condition


}


//old was declared in character script may re use for story 2

//[SerializeField]string sQuestPrompt = "Oh I see you spent a long time in the rocky mountains, by any chance did you find the " +
//    "Flowers that bloom there?"; // if condition met this quest will be given to the player
//[SerializeField] string sQuestCompleteDialog = ""; //dialog for completing the quest

//[SerializeField] GameObject goQuestObjective; //item that will need to be obtained to complete quest //check pickup script bool

//[SerializeField] GameObject goAreaVisted; //area to check if visited //will be quest condition


////special quest
//[SerializeField] string sSpecialConditionMet = "Oh I see you visited the desert, when I was last there I heard a rumor of a " +
//    "lost chest in an oasis, if you ever go back it might be worth a look"; //if an area has been accessed prompt to display
//[SerializeField] GameObject goAreaStayedInToEnquireAbout; //area to check how long spent in //will be special condition

