using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetector_invert : MonoBehaviour {

	public float angle;
	private bool useAngle = true;

	public float strength;
	public float y;
	public int numObjects;

	public float height = 1;
	public float center = 0.5f;
	public float stanDevi = 0.12f;




	void Start () {
		strength = 0;
		numObjects = 0;

		if (angle >= 360) {
			useAngle = false;
		}
	}

	void Update () {
		GameObject[] lights;

		if (useAngle) { //se o < for <360
			lights = GetVisibleLights (); //retorna tds as luzes naquele ang
		} else {
			lights = GetAllLights (); //retorna tds as luzes
		}

		strength = 0;
		numObjects = lights.Length;

		foreach (GameObject light in lights) {
			float r = light.GetComponent<Light> ().range;
			strength += 1.0f / ((transform.position - light.transform.position).sqrMagnitude / r + 1);
		}

		if (numObjects > 0) {
			strength = strength / numObjects;
		}
	}

	// Get linear output value
	public float GetLinearOutput()
	{
		return strength;
	}

	// Get gaussian output value
	public virtual float GetGaussianOutput()
	{
		//throw new NotImplementedException ();

		//	y= Mathf.Exp(-1f * Mathf.Pow(strength - center, 2) / (2 * stanDevi * stanDevi));  //height is always 1

		//y= Mathf.Exp(-1f * Mathf.Pow(strength - 0.5f, 2) / (2 * 0.12f * 0.12f));  //height is always 1
		y =  height  * Mathf.Exp(-1f * Mathf.Pow(strength - center, 2) / (2 * stanDevi * stanDevi));  //height is always 1
		return y;
	}

	// Returns all "Light" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllLights()
	{
		return GameObject.FindGameObjectsWithTag ("Light");
	}

	// Returns all "Light" tagged objects that are within the view angle of the Sensor. 
	// Only considers the angle over the y axis. Does not consider objects blocking the view.
	GameObject[] GetVisibleLights()
	{
		ArrayList visibleLights = new ArrayList();
		float halfAngle = angle / 2.0f;

		GameObject[] lights = GameObject.FindGameObjectsWithTag ("Light"); //retorna tds os Light activos

		foreach (GameObject light in lights) {
			Vector3 toVector = (light.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle (forward, toVector);

			if (angleToTarget <= halfAngle) {
				visibleLights.Add (light);
			}
		}

		return (GameObject[])visibleLights.ToArray(typeof(GameObject));
	}


}
