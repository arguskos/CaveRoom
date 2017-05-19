using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
    public int counter;
    public Vector3[] Pos;
	void Start () {
		AudioProcessor processor = FindObjectOfType<AudioProcessor> ();
		processor.onBeat.AddListener (Beat);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Beat()
    {
        transform.position = Pos[counter];
        counter++;
        counter %= 4;
    }
}
