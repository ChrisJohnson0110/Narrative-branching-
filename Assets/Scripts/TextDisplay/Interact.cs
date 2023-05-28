/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : when the player is with in the trigger collider, enable the given gameobejct
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] GameObject gPopUp; //text pop up to display


    private void Start()
    {
        gPopUp.SetActive(false); //hide pop up
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player walks into
        {
            gPopUp.SetActive(true);

        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player walks into
        {
            gPopUp.SetActive(false);
        }
    }
}
