/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 28/05/2023
/// Purpose : randomly place the npcs within the given area and give them random quests
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNpc : MonoBehaviour
{
    [SerializeField] GameObject goCharacterPrefab; //npc prefab
    [SerializeField] Vector2 v2AreaToSpawnNpcs; //area to create them within
    [SerializeField] List<Quest> qQuestsToGiveNpcs; //quest list that can be given to npcs

    LocationTracker LocationTrackerRef; //location tracker reference

    // Start is called before the first frame update
    void Start()
    {
        LocationTrackerRef = FindAnyObjectByType<LocationTracker>();
        IdleDialogGiver id = GameObject.FindAnyObjectByType<IdleDialogGiver>();


        if (qQuestsToGiveNpcs != null)
        {
            for (int i = 0; i < id.li_sIdleDialogOptions.Count; i++)
            {
                float x = Random.Range(transform.position.x - v2AreaToSpawnNpcs.x, transform.position.x + v2AreaToSpawnNpcs.x);
                float y = Random.Range(transform.position.z - v2AreaToSpawnNpcs.y, transform.position.z + v2AreaToSpawnNpcs.y);


                GameObject newCharacter = Instantiate(goCharacterPrefab, new Vector3(x,1,y), transform.rotation);

                newCharacter.transform.SetParent(this.transform);

                newCharacter.GetComponent<Character>().qCharacterQuest = new Quest();

                int iQuestToGive = Random.Range(0, qQuestsToGiveNpcs.Count);
                newCharacter.GetComponent<Character>().qCharacterQuest = qQuestsToGiveNpcs[iQuestToGive];
                qQuestsToGiveNpcs.Remove(qQuestsToGiveNpcs[iQuestToGive]); //remove the quest

                //set the two conditions for starting either quest

                newCharacter.GetComponent<Character>().qCharacterQuest.sQuestConditionOne = LocationTrackerRef.li_gLocationsAccessed //set to a location
                    [Random.Range(0, LocationTrackerRef.li_gLocationsAccessed.Count)] //a random location
                    .ToString(); //the locations name

                newCharacter.GetComponent<Character>().qCharacterQuest.sQuestConditionTwo = LocationTrackerRef.li_gTimeSpentInEachArea //set to a location
                    [Random.Range(0, LocationTrackerRef.li_gTimeSpentInEachArea.Count)] //a random location
                    .ToString(); //the locations name
            }
        }

        id.GiveIdleDialog();
        id.GiveHints();

    }
}
