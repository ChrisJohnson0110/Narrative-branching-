using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTracker : MonoBehaviour
{

    //switch to lists storing scripts so that times can be easily compared
    //have function to get update lists
    //have function to return lists
    //have function to return highest in time spent


    //List<TimeSpentInArea> objectsWithScript = new List<TimeSpentInArea>();
    //objectsWithScript.AddRange(FindObjectsOfType<TimeSpentInArea>());


    List<GameObject> li_gLocationsAccessed = new List<GameObject>();
    List<GameObject> li_gTimeSpentInEachArea = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        TimeSpentInArea[] objectsWithScripttsa = FindObjectsOfType<TimeSpentInArea>();
        foreach (TimeSpentInArea scriptObject in objectsWithScripttsa)
        {
            li_gTimeSpentInEachArea.Add(scriptObject.gameObject);
        }


        LocationAccessed[] objectsWithScriptla = FindObjectsOfType<LocationAccessed>();
        foreach (LocationAccessed scriptObject in objectsWithScriptla)
        {
            li_gTimeSpentInEachArea.Add(scriptObject.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    void UpdateTimeSpentInAreaList()
    {
        
    }


}
