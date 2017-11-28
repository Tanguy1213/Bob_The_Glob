﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{

    public Transform Target;

    // Use this for initialization
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Target.position.x, Target.position.y, -10);
    }
}
