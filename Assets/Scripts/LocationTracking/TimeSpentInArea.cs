/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 25/05/2023
/// Purpose : store the amount of time spent in the attached objects trigger collider
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpentInArea : MonoBehaviour
{
    public float fTimeSpentInArea = 0; //total time spent in area

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player is within the collider
        {
            fTimeSpentInArea += Time.deltaTime; //increase the time the player has spent in the area
        }
        
    }
}
