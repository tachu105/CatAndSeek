using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(Cursor.visible == true){
                Cursor.visible = false;
            }else{
                Cursor.visible = true;
            }
            //Cursor.lockState = CursorLockMode.None;
        }
    }
}