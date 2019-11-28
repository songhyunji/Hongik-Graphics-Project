using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YatchMove : MonoBehaviour
{
	public float speed = 10;
	public float rotateangle = 1;
	public int boost = 2;
	public int boostendtime = 3;
	public GameObject waterparticle;

	private bool spacePress = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
		{
			waterparticle.SetActive(true);
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}

		if (Input.GetKey(KeyCode.S))
		{
			waterparticle.SetActive(true);
			transform.Translate(Vector3.back * Time.deltaTime * speed);
		}

		if(Input.GetKey(KeyCode.D))
		{
			waterparticle.SetActive(true);
			transform.Rotate(Vector3.left * Time.deltaTime * rotateangle);
		}
		if(Input.GetKeyUp(KeyCode.D))
		{
			transform.Rotate(Vector3.left * 0);
		}


		if (Input.GetKey(KeyCode.A))
		{
			waterparticle.SetActive(true);
			transform.Rotate(Vector3.right * Time.deltaTime * rotateangle);
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			transform.Rotate(Vector3.right * 0);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(Boost());
		}

		if(!Input.anyKey)
		{
			waterparticle.SetActive(false);
		}
	}

	IEnumerator Boost()
	{
		if(!spacePress)
		{
			spacePress = true;
			Debug.Log("Boost start");

			speed *= boost;
			yield return new WaitForSeconds(3);
			speed /= boost;
			spacePress = false;
			Debug.Log("Boost End");
		}
	}
}
