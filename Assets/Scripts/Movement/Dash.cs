/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : allow the player to do a quick dash
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dash : MonoBehaviour
{
    NavMeshAgent navAgent;
    [SerializeField] float fDashSpeed = 100;
    [SerializeField] float fDashDuration = 0.5f;

    bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask layerMask = 3 << LayerMask.NameToLayer("MoveRayCanHit");
            if (Physics.Raycast(ray, out RaycastHit hit, 100, layerMask))
            {
                navAgent.SetDestination(hit.point); // set destination to hit pos

                if (isDashing == false)
                {
                    StartCoroutine(DashSpace());
                }
            }
        }
    }


    /// <summary>
    /// dash
    /// </summary>
    IEnumerator DashSpace()
    {
        isDashing = true; //prevent another dash wile active

        float fOriginalSpeed = navAgent.speed; //store original speed
        navAgent.speed = fDashSpeed; //set speed to dashing speed

        float fElapsedTime = 0f; //start time
        while (fElapsedTime < fDashDuration) //dash for duration
        {
            navAgent.speed = Mathf.Lerp(fDashSpeed, fOriginalSpeed, fElapsedTime / fDashDuration); //apply speed
            fElapsedTime += Time.deltaTime; //increase time
            yield return null;
        }
        navAgent.speed = fOriginalSpeed; //set speed back after dash
        isDashing = false; //allow to dash again
    }


}
