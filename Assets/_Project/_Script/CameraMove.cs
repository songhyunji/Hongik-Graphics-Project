using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public float movespeed;
	public int minheight;
	public int maxheight;

	Vector2 mouseposition1;
	Vector2 mouseposition2;
	Vector3 camerartation;
	Quaternion beforerotate;
	bool mousepress = false;
	float height;


	// Start is called before the first frame update
	void Start()
    {
		beforerotate = GetComponent<Transform>().localRotation;
		height = GetComponent<Transform>().position.y;
		Debug.Log(height);
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetMouseButtonDown(0))
		{
			mouseposition1 = Input.mousePosition;
			mousepress = true;
		}
		if(Input.GetMouseButtonUp(0))
		{
			mousepress = false;
			GetComponent<Transform>().localRotation = beforerotate;
		}

		if(mousepress)
		{
			mouseposition2 = Input.mousePosition;
			camerartation = new Vector3(mouseposition1.y - mouseposition2.y, mouseposition2.x - mouseposition1.x, 0);
			transform.Rotate(camerartation * movespeed);
		}

		if (height > minheight && height < maxheight)
		{
			height -= Input.mouseScrollDelta.y;
			GetComponent<Transform>().localPosition = new Vector3(0, height, -0.7f * height);
		}
		else if(height <= minheight)
		{
			height = minheight + 1;
			GetComponent<Transform>().localPosition = new Vector3(0, height, -0.7f * height);
		}
		else if(height >= maxheight)
		{
			height = maxheight - 1;
			GetComponent<Transform>().localPosition = new Vector3(0, height, -0.7f * height);
		}
	}

}
