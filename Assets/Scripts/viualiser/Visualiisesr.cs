using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualiisesr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float [] all=GetComponent<AudioSource>().GetSpectrumData(1024, 0, FFTWindow.Hanning);
	    var c1 = all[3] + all[2] + all[4];
        var c3 = all[11] + all[12] + all[13];
        var c4 = all[22] + all[23] + all[24];
        var c5 = all[44] + all[45] + all[46] + all[47] + all[48] + all[49];
        print(c1+"  "+c3);
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
	    for (int i = 0; i < cubes.Length; i++)
	    {
	        switch (cubes[i].name)
	        {

                case "c1":
                    cubes[i].transform.localScale=new Vector3( 1,c1*20,1);
	                break;
                case "c3":
                    cubes[i].transform.localScale= new Vector3(1, c3*20,1);
                    break;
                case "c4":
                    cubes[i].transform.localScale= new Vector3(1, c4*20, 1);
                    break;
                case "c5x`":
                    cubes[i].transform.localScale= new Vector3(1, c5*20, 1);
                    break;

            }
	    }
	}
}
