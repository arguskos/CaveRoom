using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameManagerBase {

	public AudioSource Source;

    public static GameManager Instance;

    public void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
    }
	// Use this for initialization
	new void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();
		
		//StartCoroutine(Helpers.SlowPrint(GetParameter(Parameters.GetParameter(Parameters.ParamsName.SongTempo)).ToString(), 1f));
		Source.pitch = GetParameter(Parameters.GetParameter(Parameters.ParamsName.SongTempo));
	}
}
