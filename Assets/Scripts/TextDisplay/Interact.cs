/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] GameObject gPopUp; //

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        gPopUp.SetActive(false);
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
