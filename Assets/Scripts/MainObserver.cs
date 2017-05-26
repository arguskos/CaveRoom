using System.Collections;
using System.Collections.Generic;
using SynchronizerData;
using UnityEngine;

public class MainObserver : MonoBehaviour {


    public float DistanceSpread ;
    public GameObject Center;
	private bool _hitted =false;




	public Vector3[] beatPositions;

	private BeatObserver beatObserver;
	private int beatCounter;

	private float _toleranceTime = 0.2f;
	public float _toleraceTimer = 0;
	public bool _canBeHitted = false;
	private int _multiplayer = 0;
	private float _reductnionRate = 1f;
	public List<float> _time;
	void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
        beatCounter = 0;
    }

	public void Right()
	{
		DistanceSpread+=1.5f;
		foreach (var child in GetComponentsInChildren<EmissionController>())
		{
			if (DistanceSpread > Vector3.Distance(child.transform.position, Center.transform.position))
			{
				//print(DistanceSpread < Vector3.Distance(child.transform.position, Center.transform.position));

				//child.SetRandomColor();
				child.IncreaseEmmision(0.1f);
			}
		}
	}
	public void Wrong()
	{
		foreach (var child in GetComponentsInChildren<EmissionController>())
		{
			child.ZeroingEmmision();
			DistanceSpread = 0;
		}

	}

	void Update()
    {


		for (int i = _time.Count - 1; i > -1; i--)
		{
			if (Time.time - _time[i] > _toleranceTime)
			{
				_time.RemoveAt(i);
				//GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r - _reductnionRate, 0, 0, 1);

			}

		}
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat
			|| (beatObserver.beatMask & BeatType.OffBeat) == BeatType.OffBeat

			)
		{
			foreach (var child in GetComponentsInChildren<EmissionController>())
			{
				if (DistanceSpread > Vector3.Distance(child.transform.position, Center.transform.position))
				{
					//print(DistanceSpread < Vector3.Distance(child.transform.position, Center.transform.position));

					child.SetRandomColor();
					//child.IncreaseEmmision(2.1f);
				}
			}
			//GetComponent<Renderer>().material.color = new Color(_reductnionRate * _time.Count, 0, 0, 1);

			_time.Add(Time.time);
		}
		if ((beatObserver.beatMask & BeatType.OffBeat) == BeatType.OffBeat)
		{
		}

		if (Input.GetKeyDown(KeyCode.Space))
        {
			if (_time.Count > 0)
			{
				print("Right");
				Right();
				_time.RemoveAt(0);
				//GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r - _reductnionRate, 0, 0, 1);

			}
			else
			{
				print("wromg");
				Wrong();
			}
		}
    }
}
