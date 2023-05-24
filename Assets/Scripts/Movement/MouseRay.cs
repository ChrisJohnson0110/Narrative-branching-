/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose :
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour
{
    [SerializeField] Material mCharacterOutlineMaterial;
    [SerializeField] Material mPickupOutlineMaterial;

    ClickToMove ClickToMoveRef;
    Outline OutlineRef;
    //AutoAttack AutoAttackRef;

    // Start is called before the first frame update
    void Start()
    {
        ClickToMoveRef = GetComponent<ClickToMove>();
        OutlineRef = GetComponent<Outline>();
        //AutoAttackRef = GetComponent<AutoAttack>();
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.tag == "Character") //if can attack
            {
                OutlineRef.OutlineMaterial = mCharacterOutlineMaterial;
                OutlineRef.ApplyOutline(hit.transform.gameObject); //apply outline

                //if (Input.GetMouseButtonDown(0)) //if mouse down
                //{
                //    //AutoAttackRef.Attack(hit);
                //    ClickToMoveRef.StopMoving();
                //}

                if (Input.GetMouseButtonDown(0)) //move
                {
                    ClickToMoveRef.MoveToClickPoint(hit, false);
                }
            }
            else if (hit.transform.gameObject.tag == "Pickup") //if can attack
            {
                OutlineRef.OutlineMaterial = mPickupOutlineMaterial;
                OutlineRef.ApplyOutline(hit.transform.gameObject); //apply outline

                if (Input.GetMouseButtonDown(0)) //move
                {
                    ClickToMoveRef.MoveToClickPoint(hit, false);
                }
            }
            else
            {
                OutlineRef.RemoveOutline(); //remove outline
                //if (Input.GetMouseButtonDown(0)) //move
                //{
                //    ClickToMoveRef.MoveToClickPoint(hit);
                //}
                if (Input.GetMouseButtonDown(0)) //move
                {
                    ClickToMoveRef.MoveToClickPoint(hit, true);
                }
            }



            
        }
    }
}
