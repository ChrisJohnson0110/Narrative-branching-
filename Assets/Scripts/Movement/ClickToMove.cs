/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose :
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent navAgent;
    [SerializeField] private GameObject ClickEffect;
    [SerializeField] private float EffectDuration = 2f;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// cast ray and move to
    /// </summary>
    public void MoveToClickPoint(RaycastHit hit, bool a_bShowEffect)
    {
        navAgent.SetDestination(hit.point); // set destination to hit pos

        if (a_bShowEffect == true)
        {
            CreateClickEffect(hit.point); //create effect at hit pos
        }
    }

    /// <summary>
    /// stop the current movement path
    /// </summary>
    public void StopMoving()
    {
        navAgent.SetDestination(gameObject.transform.position);
    }

    /// <summary>
    /// create effect
    /// </summary>
    private void CreateClickEffect(Vector3 a_v3Pos)
    {
        GameObject go = Instantiate(ClickEffect, a_v3Pos, transform.rotation);
        Destroy(go, EffectDuration);
    }
}
