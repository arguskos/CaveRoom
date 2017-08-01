using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPrint : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    MainObserver.Instance.OnRight += OnRight;
	    MainObserver.Instance.OnWrong += OnWrong;
	    MainObserver.Instance.OnSkipped += OnSkipped;

    }

    private void OnSkipped()
    {
        print("skipped");
    }
    private void OnRight()
    {
        print("right");
    }
    private void OnWrong()
    {
        print("wrong");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
