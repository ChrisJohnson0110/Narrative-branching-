/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 25/05/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTracker : MonoBehaviour
{
    List<GameObject> li_gLocationsAccessed = new List<GameObject>(); //will hold gameobjects that can be accessed
    List<GameObject> li_gTimeSpentInEachArea = new List<GameObject>(); //will hold gameobjects that can be accessed

    // Start is called before the first frame update
    void Start()
    {
        GetTimeSpentInAreaList(); //load all time spent in area scripts into list
        GetAreaAccessedList(); //load all area accessed scripts into list
    }

    /// <summary>
    /// find the area the player has spent the most time in
    /// </summary>
    /// <returns> the most visted area</returns>
    public GameObject GetMostVistedArea()
    {
        GameObject gMostVisitedArea = new GameObject();
        float HighestValue = 0;
        foreach (GameObject g in li_gTimeSpentInEachArea)
        {
            if (g.GetComponent<TimeSpentInArea>().fTimeSpentInArea >= HighestValue)
            {
                gMostVisitedArea = g;
                HighestValue = g.GetComponent<TimeSpentInArea>().fTimeSpentInArea;
            }
        }
        return gMostVisitedArea;
    }


    /// <summary>
    /// find if the given area has been accessed
    /// </summary>
    /// <param area to check="a_gAreaToCheck"></param>
    /// <returns>if the area has been accessed</returns>
    public bool HasAreaBeenAccessed(GameObject a_gAreaToCheck)
    {
        return a_gAreaToCheck.GetComponent<LocationAccessed>().bAreaAccessed;
    }


    /// <summary>
    /// get all instances of the time spent in area scritps
    /// </summary>
    void GetTimeSpentInAreaList()
    {
        TimeSpentInArea[] objectsWithScripttsa = FindObjectsOfType<TimeSpentInArea>();//array to hold all found instances
        //load the array into the list
        foreach (TimeSpentInArea scriptObject in objectsWithScripttsa)
        {
            li_gTimeSpentInEachArea.Add(scriptObject.gameObject);
        }
    }


    /// <summary>
    /// get all the instances of the location accessed scripts
    /// </summary>
    void GetAreaAccessedList()
    {
        LocationAccessed[] objectsWithScriptla = FindObjectsOfType<LocationAccessed>(); //array to hold all found instances
        //load the array into the list
        foreach (LocationAccessed scriptObject in objectsWithScriptla)
        {
            li_gLocationsAccessed.Add(scriptObject.gameObject);
        }
    }
}
