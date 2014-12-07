using UnityEngine;
using System.Collections;

public class AnimateSlow : MonoBehaviour {

	public Sprite frame1, frame2;
	public float aniSpeed; // in frames

	private float aniSpeedTimer;
	private SpriteRenderer spriteRenderer;

	void Start()
	{
		aniSpeedTimer = aniSpeed;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		aniSpeedTimer --;

		if (aniSpeedTimer <= 0)
		{

			if (spriteRenderer.sprite == frame1)
			{
				spriteRenderer.sprite = frame2;
			}

			else
			{
				spriteRenderer.sprite = frame1;
			}

			aniSpeedTimer = aniSpeed;

		}
	}

}
