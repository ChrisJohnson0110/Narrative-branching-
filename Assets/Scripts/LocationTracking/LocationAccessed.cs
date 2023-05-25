/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 25/05/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAccessed : MonoBehaviour
{
    public bool bAreaAccessed = false; //if the area has been accessed

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player enters the area
        {
            bAreaAccessed = true; //store that the player has entered the area
        }
    }
}
