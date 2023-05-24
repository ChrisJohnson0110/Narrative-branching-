/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] GameObject gDialogBox;

    //popup timer
    float fTimer;
    [SerializeField] float fTimerStart = 5f;
    bool bTimerActive = false;

    private void Start()
    {
        fTimer = fTimerStart;
        gDialogBox.SetActive(false);
    }

    private void Update()
    {
        if (bTimerActive == true)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                bTimerActive = false;
                gDialogBox.SetActive(false);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player walks into
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("interact");
                gDialogBox.SetActive(true);
                fTimer = fTimerStart;
                bTimerActive = true;
            }
        }
    }



}
