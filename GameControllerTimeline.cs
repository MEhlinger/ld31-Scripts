using UnityEngine;
using System.Collections;

public class GameControllerTimeline : MonoBehaviour {

	public GameObject westWindow;
	public GameObject backWindow;
	public GameObject eastWindow;
	public GameObject door;

	private float monsterVal;
	private string toSpawn;

	private float entryVal;
	private GameObject activeEntry;

	private float entryTimer;
	private float entryIntervalMultiplier;

	
	void Start () 
	{
		entryTimer = 500; //Subject to change.
		entryIntervalMultiplier = 3000;
	}
	
	
	void Update () 
	{
		entryTimer --;

		if (entryTimer <= 0)
		{
			entryTimer = (Random.value + .15f) * entryIntervalMultiplier;
			if (entryIntervalMultiplier >= 501)
			{
				entryIntervalMultiplier -= 500.0f;
			}

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

				//DETERMINE WHICH MONSTER TO SPAWN
				monsterVal = Mathf.Round(Random.Range(1.0f, 4.0f));


				if (monsterVal == 1)
				{
					toSpawn = "Slime";
				}
				if (monsterVal == 2)
				{
					toSpawn = "Hulk";
				}
				if (monsterVal == 3)
				{
					toSpawn = "Slither";
				}
				if (monsterVal == 4)
				{
					toSpawn = "Spider";
				}


				GameObject monster = Instantiate
					(
						Resources.Load(toSpawn), 
						new Vector2 (activeEntry.transform.position.x, activeEntry.transform.position.y - 0.3f),
						transform.rotation
					) 
				as GameObject;
			}
			
		}
	}
}
