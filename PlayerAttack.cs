using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private float attackTimer;
	private bool canAttack;
	private Vector3 oldPos;

	private bool attackFrame2; //should make the player less vulnerable while attacking
	public bool attacking;

	void Start() 
	{
		canAttack = true;
		attackTimer = 20;
	}


	void Update()
	{
		if (attacking)
		{
			transform.position = oldPos;
			if (attackFrame2)
			{
				attacking = false;
				attackFrame2 = false;
			}
			else
			{
				attackFrame2 = true;
			}
		}

		attackTimer --;

		if  (attackTimer <= 0)
		{
			attackTimer = 20;
			canAttack = true;
		}

		if ((Input.GetKeyDown (KeyCode.LeftShift)) && (canAttack))
		{
			attacking = true;
			oldPos = transform.position;
			transform.position += new Vector3(-0.2f, 0.0f, 0.0f);
			canAttack = false;
		}
		else if ((Input.GetKeyDown (KeyCode.RightShift)) && (canAttack))
		{
			attacking = true;
			oldPos = transform.position;
			transform.position += new Vector3(0.2f, 0.0f, 0.0f);
			canAttack = false;
		}
	}
}
