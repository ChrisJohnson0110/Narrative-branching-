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
    [SerializeField] GameObject gPopUp;
    [SerializeField] float fPopupDuration = 5f;

    private void Start()
    {
        gPopUp.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player walks into
        {
            //show interact pop up

            //GameObject popup = Instantiate(gPopUp, transform.position, transform.rotation);
            //popup.transform.transform.SetParent(this.gameObject.transform);
            //Destroy(popup, fPopupDuration);

            gPopUp.SetActive(true);

        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player walks into
        {
            gPopUp.SetActive(false);
        }
    }
}
