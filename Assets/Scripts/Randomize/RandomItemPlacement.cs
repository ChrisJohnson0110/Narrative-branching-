/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 28/05/2023
/// Purpose : randomly place a given obeject within a given area of this object
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemPlacement : MonoBehaviour
{
    [SerializeField] GameObject goItemToPlace; //item that will be created
    [SerializeField] Vector2 v2AreaSize = new Vector2(5,5); //size of the area that the item can be created within

    // Start is called before the first frame update
    void Start()
    {
        //get a random position within the given bounds
        float x = Random.Range(transform.position.x - v2AreaSize.x, transform.position.x + v2AreaSize.x);
        float y = Random.Range(transform.position.z - v2AreaSize.y, transform.position.z + v2AreaSize.y);

        //create pickup item within bounds
        GameObject go =  Instantiate(goItemToPlace, new Vector3(x, transform.position.y + 0.1f, y), goItemToPlace.transform.rotation);
        go.transform.SetParent(this.transform);
    }


    /// <summary>
    /// would use to generate items for quest only when quest is given
    /// </summary>
    public void CreateItem()
    {
        float x = Random.Range(transform.position.x - v2AreaSize.x, transform.position.x + v2AreaSize.x);
        float y = Random.Range(transform.position.z - v2AreaSize.x, transform.position.z + v2AreaSize.y);

        GameObject go = Instantiate(goItemToPlace, new Vector3(x, transform.position.y + 0.1f, y), goItemToPlace.transform.rotation);
        go.transform.SetParent(this.transform);
    }


}
