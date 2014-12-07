using UnityEngine;
using System.Collections;

public class GetFood : MonoBehaviour 
{

	private bool atFridge;
	private bool fridgeReady;
	private float fridgeTimer;

	public GameObject PC;

	void Start()
	{
		fridgeTimer = 300;
		fridgeReady = true;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atFridge = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atFridge = false;
		}
	}

	void Update()
	{
		fridgeTimer --;


		if (fridgeTimer <= 0)
		{
			fridgeReady = true;
			fridgeTimer = 300;
		}


		if (Input.GetKeyDown (KeyCode.Space) && atFridge && fridgeReady)
		{
			GameObject food = Instantiate(Resources.Load("Mushroom"), transform.position, transform.rotation) as GameObject;
			fridgeReady = false;
			PC.GetComponent<PlayerController>().sanity -= 2;
			PC.GetComponent<PlayerController>().health += 10;
			if (PC.GetComponent<PlayerController>().health > 100)
			{
				PC.GetComponent<PlayerController>().health = 100;
			}
		}
	}
}

