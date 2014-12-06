using UnityEngine;
using System.Collections;

public class DescendStair : MonoBehaviour {

	private bool atDescend;
	public GameObject PC;



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atDescend = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atDescend = false;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) && atDescend)
		{
			PC.transform.position += new Vector3(0.0f, -1.65f, 0.0f);
		}
	}
}
