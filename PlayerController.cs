using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float health;
	public float sanity;

	private float hungerTimer;
	private float sanityTimer;

	void Start () 
	{
		hungerTimer = 100;
		sanityTimer = 300;
	}
	

	void Update () 
	{
		StatDecrement();
		Movement();
	}



	void Movement()
	{
		if ((Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.LeftArrow)))
		{
			transform.position += new Vector3(-0.02f, 0.0f, 0.0f);
		}
		if ((Input.GetKey (KeyCode.D)) || (Input.GetKey (KeyCode.RightArrow)))
		{
			transform.position += new Vector3(0.02f, 0.0f, 0.0f);
		}
	}

	void StatDecrement()
	{
		hungerTimer --;
		sanityTimer --;

		if (hungerTimer <= 0)
		{
			health --;
			hungerTimer = 100;
		}
		if (sanityTimer <= 0)
		{
			sanity --;
			sanityTimer = 300;
		}

	}

}
