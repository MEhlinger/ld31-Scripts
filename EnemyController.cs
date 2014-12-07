using UnityEngine;
using System.Collections;



public class EnemyController : MonoBehaviour {

	public float damage;
	public float insanityCost;

	public float speed; //Should be .02 for player speed. Adjust in editor accordingly.
	public GameObject PC;

	public Boundary boundary;

	private float directionTimer;
	public float direction;

	void Start()
	{
		directionTimer = 100;
		PC = GameObject.FindWithTag("playerChar");
	}

	void Update()
	{
		directionTimer --;


		if (directionTimer <= 0)
		{
			direction = Mathf.Round(Random.value);
			if (direction ==0)
			{
				direction = -1.0f;
			}
			directionTimer = 100;
		}


		if (direction == 1)
		{
			transform.position += new Vector3(speed, 0.0f, 0.0f);
		}

		if (direction == -1)
		{
			transform.position += new Vector3(speed * -1.0f, 0.0f, 0.0f);
		}


		transform.position = new Vector3
		(
			Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax),
			transform.position.y
		);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if ((other.gameObject == PC) && (PC.GetComponent<PlayerAttack>().attacking == false))
		{
			PC.GetComponent<PlayerController>().health -= damage;
			PC.GetComponent<PlayerController>().sanity -= insanityCost;
			direction *= -1;
		}
	}


	void OnTriggerStay2D(Collider2D other)
	{

		if ((other.gameObject == PC) && (PC.GetComponent<PlayerAttack>().attacking == true))
		{
			Destroy(gameObject);
		}
	}

}
