using System.Collections;
using System.Collections.Generic;
using SynchronizerData;
using UnityEngine;

public class alll : MonoBehaviour {

    public Vector3[] beatPositions;

    private BeatObserver beatObserver;
    private int beatCounter;

    private float _toleranceTime = 0.4f;
    public float _toleraceTimer = 0;
    public bool _canBeHitted = false;
	private int _multiplayer=0;
	private float _reductnionRate=1f;
	public  List<float> _time;
    void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
        beatCounter = 0;
		StartCoroutine (WaitPrint ());
    }
	IEnumerator WaitPrint(	)
	{
		while(true){
			//print (_time.Count);
			yield return new WaitForSeconds(0.01f);

		}
	}
    void Update()
    {
		for (int i =_time.Count-1; i>-1;i--) {
			if (Time.time-_time[i]>_toleranceTime)
			{
				_time.RemoveAt(i);
				GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r-_reductnionRate,0,0,1);

			}

		}
        if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat
			|| (beatObserver.beatMask & BeatType.OffBeat) == BeatType.OffBeat

            )
        {
            //transform.position = beatPositions[beatCounter];
            //beatCounter = (++beatCounter == beatPositions.Length ? 0 : beatCounter);

            //_canBeHitted = true;
            //GetComponent<Renderer>().material.color = Color.black;
			GetComponent<Renderer>().material.color = new Color(_reductnionRate*_time.Count,0,0,1);

			_time.Add (Time.time);
        }
        if ((beatObserver.beatMask & BeatType.OffBeat) == BeatType.OffBeat)
        {

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
			if (_time.Count > 0) {
				_time.RemoveAt (0);
				GetComponent<Renderer> ().material.color = new Color (GetComponent<Renderer> ().material.color.r -_reductnionRate, 0, 0, 1);

			} else {
				//print ("wromg");
			}
        }
    }
}
