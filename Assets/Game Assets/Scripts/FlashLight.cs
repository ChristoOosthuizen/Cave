using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour 
{
	private Light flashLight;
	public bool lightOn = false;
	
	
	void Start ()
	{
		flashLight = GetComponent<Light>();
	}

	void Update ()
	{
		if(lightOn == false)
		{
			if(Input.GetKeyDown(KeyCode.F))
			{
				flashLight.enabled = true;
				lightOn = true;
			}
		}


		if(Input.GetKeyUp(KeyCode.F)& lightOn == true)
		{
			flashLight.enabled = false;
			lightOn = false;
		}
	}
}
