using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemPlacement : MonoBehaviour
{

    [SerializeField] GameObject goItemToPlace;
    [SerializeField] Vector2 v2AreaSize = new Vector2(5,5);

    // Start is called before the first frame update
    void Start()
    {
        //create pickup item within bounds

        float x = Random.Range(transform.position.x - v2AreaSize.x, transform.position.x + v2AreaSize.x);
        float y = Random.Range(transform.position.z - v2AreaSize.x, transform.position.z + v2AreaSize.y);

        GameObject go =  Instantiate(goItemToPlace, new Vector3(x, transform.position.y + 0.1f, y), goItemToPlace.transform.rotation);
        go.transform.SetParent(this.transform);
    }
}
