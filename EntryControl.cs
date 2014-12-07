using UnityEngine;
using System.Collections;

public class EntryControl : MonoBehaviour {

	public bool open;
	public bool stateChanging; //Stores whether the window/door is slated to be opened/closed

	public GameObject PC;

	private bool atEntry;

	public Sprite openImg;
	public Sprite closedImg;

	private SpriteRenderer spriteRenderer;


	void Start () 
	{
		open = false;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	

	void Update () 
	{
		OpenClose();
		if (Input.GetKeyDown (KeyCode.Space) && atEntry)
		{
			stateChanging = true;
		}
	}


	void OpenClose()
	{
		if (stateChanging && open)
		{
			open = false;
			//Play sound
			spriteRenderer.sprite = closedImg;
			stateChanging = false;
		}
		else if (stateChanging && (open == false))
		{
			open = true;
			//Play Sound
			spriteRenderer.sprite = openImg;
			stateChanging = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atEntry = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == PC)
		{
			atEntry = false;
		}
	}
}
