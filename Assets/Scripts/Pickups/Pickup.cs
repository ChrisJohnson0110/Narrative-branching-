/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : allow the player to pick this object up
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool bObtained = false; //has this item been obtained
    [SerializeField] GameObject goInteractObject; // interact dialog popup

    /// <summary>
    /// if the player interacts with hide this gameobject and save that its been picked up
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player walks into
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameObject.FindAnyObjectByType<PickupTracker>().PickUpObject(this.gameObject); //add to list of picked up items

                //hide the object
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;
                bObtained = true;

                goInteractObject.SetActive(false); //hide the interact dialog

                //disable children
                foreach (Transform tChild in transform)
                {
                    tChild.gameObject.SetActive(false);
                }

            }
        }
    }
}
