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
	public float baseSpeed;
	private float speed;
	private bool running;

	public Sprite onCouchSpr;
	public Sprite offCouchSpr;

	public GameObject Couch;

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
			if (Input.GetKey (KeyCode.Q))
			{
				speed = baseSpeed * 2f;
				running = true;
			}
			else
			{
				speed = baseSpeed;
				running = false;
			}
			if ((Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.LeftArrow)))
			{
				transform.position += new Vector3(speed * -1.0f, 0.0f, 0.0f);
				transform.eulerAngles = new Vector2(0, 0);
			}
			if ((Input.GetKey (KeyCode.D)) || (Input.GetKey (KeyCode.RightArrow)))
			{
				transform.position += new Vector3(speed, 0.0f, 0.0f);
				transform.eulerAngles = new Vector2(0, 180);
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
			if (running)
			{
				health--;
			}
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
			Couch.GetComponent<SpriteRenderer>().sprite = onCouchSpr;
		}
		else
		{
			GetComponent<SpriteRenderer>().enabled = true;
			Couch.GetComponent<SpriteRenderer>().sprite = offCouchSpr;

		}
	}

}
