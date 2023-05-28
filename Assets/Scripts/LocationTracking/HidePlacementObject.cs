/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : destory attached object on awake
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlacementObject : MonoBehaviour
{
    /// <summary>
    /// on awake destory this object
    /// </summary>
    void Awake()
    {
        Destroy(this.gameObject); //destory attached object
    }
}
