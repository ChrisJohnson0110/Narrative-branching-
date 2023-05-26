/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTracker : MonoBehaviour
{
    public List<GameObject> li_gPickedUpObjects; //

    /// <summary>
    /// add the given object to the list of items picked up
    /// </summary>
    public void PickUpObject(GameObject a_gPickup)
    {
        li_gPickedUpObjects.Add(a_gPickup);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a_gPickupToRemove"></param>
    public void RemovePickUpObject(GameObject a_gPickupToRemove)
    {
        li_gPickedUpObjects.Remove(a_gPickupToRemove);
    }


}
