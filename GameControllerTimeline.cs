using UnityEngine;
using System.Collections;

public class GameControllerTimeline : MonoBehaviour {

	public GameObject westWindow;
	public GameObject backWindow;
	public GameObject eastWindow;
	public GameObject door;

	private float entryVal;
	private GameObject activeEntry;

	private float entryTimer;
	private float entryIntervalMultiplier;

	
	void Start () 
	{
		entryTimer = 500; //Subject to change.
		entryIntervalMultiplier = 5000;
	}
	
	
	void Update () 
	{
		entryTimer --;

		if (entryTimer <= 0)
		{
			entryTimer = (Random.value + 0.1f) * entryIntervalMultiplier;
			entryIntervalMultiplier -= 100.0f;

			entryVal = Mathf.Round(Random.Range(1.0f, 4.0f));



			if (entryVal == 1)
			{
				activeEntry = westWindow;
			}
			if (entryVal == 2)
			{
				activeEntry = backWindow;
			}
			if (entryVal == 3)
			{
				activeEntry = eastWindow;
			}
			if (entryVal == 4)
			{
				activeEntry = door;
			}



			if (activeEntry.GetComponent<EntryControl>().open == false)
			{
				activeEntry.GetComponent<EntryControl>().stateChanging = true;
			}
			else
			{
				GameObject monster = Instantiate
					(
						Resources.Load("Slime"), 
						new Vector2 (activeEntry.transform.position.x, activeEntry.transform.position.y - 0.5f),
						transform.rotation
					) 
				as GameObject;
			}
			
		}
	}
}
