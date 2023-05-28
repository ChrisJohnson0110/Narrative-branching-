/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 25/05/2023
/// Purpose : hold all of the trackers for both accessed and stayed locations
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTracker : MonoBehaviour
{
    public List<GameObject> li_gLocationsAccessed = new List<GameObject>(); //will hold gameobjects that can be accessed
    public List<GameObject> li_gTimeSpentInEachArea = new List<GameObject>(); //will hold gameobjects that can be accessed

    // Start is called before the first frame update
    void Awake()
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
        GameObject gMostVisitedArea = new GameObject(); //store most visted
        float HighestValue = 0; //store highest value

        foreach (GameObject g in li_gTimeSpentInEachArea) //check each time spent in area
        {
            if (g.GetComponent<TimeSpentInArea>().fTimeSpentInArea >= HighestValue) //if value higher than highest found so far
            {
                gMostVisitedArea = g; //hold new highest
                HighestValue = g.GetComponent<TimeSpentInArea>().fTimeSpentInArea; //store value
            }
        }
        return gMostVisitedArea; //return the most visted area
    }


    /// <summary>
    /// find if the given area has been accessed
    /// </summary>
    /// <param area to check="a_gAreaToCheck"></param>
    /// <returns>if the area has been accessed</returns>
    public bool HasAreaBeenAccessed(string a_sAreaFoundToCheck)
    {
        foreach (GameObject go in li_gLocationsAccessed) //check each areas
        {
            if (a_sAreaFoundToCheck.Contains(go.name)) //find area to check
            {
                if (go.GetComponent<LocationAccessed>().bAreaAccessed == true) //get if accessed
                {
                    return true; //has been accessed
                }
            }
        }
        return false; //has not been accessed
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
