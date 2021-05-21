using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMove : MonoBehaviour
{
	public int timespeed;
	public GameObject pointLight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(Vector3.right * timespeed * Time.deltaTime);

		if (transform.rotation.x < 0 && transform.rotation.x > -180)
		{

			pointLight.SetActive(false);
		}
		else
		{
			pointLight.SetActive(true);
		}
	}
}
