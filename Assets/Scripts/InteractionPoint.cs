using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPoint : MonoBehaviour
{

	public GameObject CurrentCircle;

	public int Scale = 1;

	public int CurrentStep = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			CurrentStep++;
			CurrentStep %= 5;
			CurrentCircle.transform.localScale=new Vector3(Scale*CurrentStep, 1, Scale*CurrentStep);
		}
		foreach (var stalacktit in GameObject.FindObjectsOfType<EmissionController>())
		{
			if (Vector2.Distance(
				    new Vector2(stalacktit.transform.position.x, stalacktit.transform.position.z)
				    , new Vector2(transform.position.x, transform.position.z)) <= Scale * CurrentStep)
			{
				stalacktit.Emmsion = 1;
			}
			else
			{
				stalacktit.Emmsion = 0;

			}
		}
		foreach (var stalacktit in GameObject.FindObjectsOfType<EmissionController>())
		{
			if (Vector2.Distance(
				    new Vector2(stalacktit.transform.position.x, stalacktit.transform.position.z)
				    , new Vector2(transform.position.x, transform.position.z)) <= (Scale * CurrentStep)/2.0f)
			{
				stalacktit.Emmsion = 1;
			}
			else
			{
				stalacktit.Emmsion = 0;

			}
		}
	}


}
