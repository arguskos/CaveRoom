using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRecorder : MonoBehaviour {
	public List<float> Clicks;
	private int _current;
	private int _counter;


	private float _reductnionRate = 1f;
	public List<float> _time;
	public float _toleraceTimer = 0;
	private float _toleranceTime = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	private bool Approximately(float one , float two, float tolerance)
	{
		if (Mathf.Abs(one - two) < tolerance)
		{
			return true;
		}
		else
			return false; ;
	}
	// Update is called once per frame
	void Update () {
		for (int i = _time.Count - 1; i > -1; i--)
		{
			if (Time.time - _time[i] > _toleranceTime)
			{
				_time.RemoveAt(i);
				GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r - _reductnionRate, 0, 0, 1);

			}

		}
		if (_current<Clicks.Count && Approximately(Clicks[_current],Time.time,0.02f))
		{
			_current++;
			GetComponent<Renderer>().material.color = new Color(_reductnionRate * _time.Count, 0, 0, 1);

			_time.Add(Time.time);
			//print(_current);
		}

		if ( Input.GetMouseButtonDown(0))
		{
			//Clicks.Add(Time.time);
		}
	}
}
