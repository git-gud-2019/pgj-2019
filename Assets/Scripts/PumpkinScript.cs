using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScript : MonoBehaviour {

    public Light light;

	public void LightOn()
    {
        light.enabled = true;
    }

    public void LightOff()
    {
        light.enabled = false;
    }
}
