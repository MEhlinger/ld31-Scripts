using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax;
}

public class PlayerController : MonoBehaviour {

	public float health;
	public float sanity;
	public bool onCouch;
	public Boundary boundary;

	private float hungerTimer;
	private float sanityTimer;

	void Start () 
	{
		hungerTimer = 100;
		sanityTimer = 300;
		onCouch = false;
	}
	

	void Update () 
	{
		SitOnCouch();
		StatDecrement();
		Movement();
	}



	void Movement()
	{
		if (onCouch == false)
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

		transform.position = new Vector3
		(
			Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax),
			transform.position.y
		);

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
			if (onCouch == false)
			{
				sanity --;
			}
			else
			{
				sanity += 10;
				onCouch = false;
				if (sanity > 100)
				{
					sanity = 100;
				}
			}
			sanityTimer = 300;
		}

	}

	void SitOnCouch()
	{
		if (onCouch)
		{
			GetComponent<SpriteRenderer>().enabled = false;
			// Call to change the sprite of couch to couch w/ player on it...
		}
		else
		{
			GetComponent<SpriteRenderer>().enabled = true;
			// Call to change sprite of couch back to only couch

		}
	}

}
