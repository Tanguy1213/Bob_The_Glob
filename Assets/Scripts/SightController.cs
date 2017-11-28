using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightController : MonoBehaviour
{
    Vector3 PosMouse;

    // Use this for initialization
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        PosMouse.z = 0;
        gameObject.transform.position = PosMouse;
        PosMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);    //Check the input mouse position each frame to store it in the variable
        Cursor.visible = false;
    }
}
