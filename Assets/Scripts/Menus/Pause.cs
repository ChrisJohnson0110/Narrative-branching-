/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 22/05/2023
/// Purpose : Pause functionality
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (!PauseMenu) //if unable to find pause menu set inactive
        {
            gameObject.SetActive(false);
        }
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //switch visability of the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(!PauseMenu.activeSelf);
        }
    }

    public void HidePause()
    {
        PauseMenu.SetActive(false);
    }

}
