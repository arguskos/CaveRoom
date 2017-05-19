using SynchronizerData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeat : MonoBehaviour {

	public Vector3[] beatPositions;

	private BeatObserver beatObserver;
	private int beatCounter;

	private float _toleranceTime = 0.2f;
	public float _toleraceTimer = 0;
	public bool _canBeHitted = false;
	void Start()
	{
		beatObserver = GetComponent<BeatObserver>();
		beatCounter = 0;
	}

	void Update()
	{
		if (_canBeHitted)
		{
			_toleraceTimer += Time.deltaTime;
		}
		if (_toleraceTimer > _toleranceTime)
		{
			_toleraceTimer = 0;
			_canBeHitted = false;
			GetComponent<Renderer>().material.color = Color.blue;
		}
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat)
		{
			transform.position = beatPositions[beatCounter];
			beatCounter = (++beatCounter == beatPositions.Length ? 0 : beatCounter);

			_canBeHitted = true;
			GetComponent<Renderer>().material.color = Color.red;
		}
		if ((beatObserver.beatMask & BeatType.OffBeat) == BeatType.OffBeat)
		{

		}
		if (Input.GetKeyDown(KeyCode.Space))
		{

		}
	}
}
