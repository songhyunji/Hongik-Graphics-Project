﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
	public int timespeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		transform.RotateAround(Vector3.zero, Vector3.right, timespeed * Time.deltaTime);
		transform.LookAt(Vector3.zero);
	}
}
