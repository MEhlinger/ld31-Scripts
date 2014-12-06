using UnityEngine;
using System.Collections;

public class AscendStair : MonoBehaviour {

	private bool atAscend;
	public GameObject PC;



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atAscend = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atAscend = false;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) && atAscend)
		{
			PC.transform.position += new Vector3(0.0f, 1.65f, 0.0f);
		}
	}
}
