using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionController : MonoBehaviour {
    public Material Mat;
    public float Emmsion = 0;
    // Use this for initialization
    void Start()
    {
		SetRandomColor();
	}
    public void IncreaseEmmision(float value)
	{
        Emmsion += value;

        SetEmmision();
    }
    public void SetRandomColor()
	{
		Mat = GetComponent<Renderer>().material;
		Mat.color = new Color(Random.Range(0.2f, 1),Random.Range(0.2f, 1),Random.Range(0.2f, 1),1);
		Color finalColor = Mat.color * Mathf.LinearToGammaSpace(Emmsion);

		Mat.SetColor("_EmissionColor", finalColor);
		GetComponent<Renderer>().UpdateGIMaterials();


	}
	public void DecreaseEmmision(float value)
	{
        Emmsion -= value;

        SetEmmision();
    }
    public void ZeroingEmmision()
	{
        Emmsion = 0;
		SetEmmision();
	}
    private void SetEmmision()
	{
		Color finalColor = Mat.color * Mathf.LinearToGammaSpace (Emmsion);

         Mat.SetColor ("_EmissionColor", finalColor);

		GetComponent<Renderer>().UpdateGIMaterials();

	}
	// Update is called once per frame
	void Update () {
        // if (Input.GetKeyDown(KeyCode.Space))
		// {
		// 	IncreaseEmmision();
		// }
	}
}
