using UnityEngine;
using System.Collections;

public class SitCouch : MonoBehaviour {
	
	private bool atCouch;
	private float recoveryTimer;

	public GameObject PC;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atCouch = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atCouch = false;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) && (atCouch) && (PC.GetComponent<PlayerController>().onCouch == false))
		{
			PC.GetComponent<PlayerController>().onCouch = true;
		}
	}
}
