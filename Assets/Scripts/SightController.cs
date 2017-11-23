using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightController : MonoBehaviour
{
    Vector3 posMouse;


    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

        posMouse.z = 0;
        gameObject.transform.position = posMouse;
        posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.visible = false;
    }
}
