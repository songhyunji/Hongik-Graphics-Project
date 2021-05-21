using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public float movespeed;
	public float rotatespeed;
	public int minheight;
	public int maxheight;

	Vector2 mouseposition1;
	Vector2 mouseposition2;
	Vector3 camerartation;
	Quaternion beforerotate;
	Camera beforecamerastate;
	bool leftmousepress = false;
	bool rightmousepress = false;
	float height;
	float rotatedir;


	// Start is called before the first frame update
	void Start()
    {
		beforerotate = GetComponent<Transform>().localRotation;
		beforecamerastate = GetComponent<Camera>();
		height = GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetMouseButtonDown(0))
		{
			mouseposition1 = Input.mousePosition;
			leftmousepress = true;
		}
		if(Input.GetMouseButtonUp(0))
		{
			leftmousepress = false;
			GetComponent<Transform>().localRotation = beforerotate;
		}

		if(leftmousepress)
		{
			mouseposition2 = Input.mousePosition;
			camerartation = new Vector3(mouseposition1.y - mouseposition2.y, mouseposition2.x - mouseposition1.x, 0);
			transform.Rotate(camerartation * movespeed);
		}

		if (Input.GetMouseButtonDown(1))
		{
			mouseposition1 = Input.mousePosition;
			rightmousepress = true;
			transform.LookAt(this.gameObject.transform.parent);
		}
		if (Input.GetMouseButtonUp(1))
		{
			rightmousepress = false;
			GetComponent<Transform>().localRotation = beforerotate;
		}

		if (rightmousepress)
		{
			mouseposition2 = Input.mousePosition;
			rotatedir = mouseposition2.x - mouseposition1.x;
			transform.RotateAround(this.gameObject.transform.parent.position, rotatedir * Vector3.down, rotatespeed);
		}

		if(!rightmousepress)
		{
			if (height > minheight && height < maxheight)
			{
				height -= Input.mouseScrollDelta.y;
				GetComponent<Transform>().localPosition = new Vector3(0, height, -0.5f * height);
			}
			else if (height <= minheight)
			{
				height = minheight + 1;
				GetComponent<Transform>().localPosition = new Vector3(0, height, -0.5f * height);
			}
			else if (height >= maxheight)
			{
				height = maxheight - 1;
				GetComponent<Transform>().localPosition = new Vector3(0, height, -0.5f * height);
			}
		}

	}

}
