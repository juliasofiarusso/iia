﻿using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class ObjectDetectorScript : MonoBehaviour {

	public float angle;
	private bool useAngle = true;
	public float strength;
	public int numObjects;

	void Start () {
		strength = 0;
		numObjects = 0;

		if (angle >= 360) {
			useAngle = false;
		}

	}

	void Update () {
		GameObject[] Objects;

		if (useAngle) { //se o < for <360
			Objects = GetAllObjects (); //feito com batota  -visible
		} else {
			Objects = GetVisibleObjects (); //all
		}


		strength = 0;
		numObjects = Objects.Length;
		float minDist = Mathf.Infinity;
		float current;

		foreach (GameObject Object in Objects) {
			current = Vector3.Distance (transform.position, Object.transform.position);
		

			if (minDist > current) {
				minDist = current;
			}

		}

		strength = 1.0f / minDist; //corrigir

	}

	// Get linear output value
	public float GetLinearOutput()
	{
		return strength;
	}

	// Get gaussian output value
	public virtual float GetGaussianOutput()
	{
		throw new NotImplementedException ();
	}

	// Returns all "Light" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllObjects()
	{
		return GameObject.FindGameObjectsWithTag ("object");
	}

	// Returns all "Light" tagged objects that are within the view angle of the Sensor. 
	// Only considers the angle over the y axis. Does not consider objects blocking the view.
	GameObject[] GetVisibleObjects()
	{
		ArrayList visibleObjects = new ArrayList();
		float halfAngle = angle / 2.0f;

		GameObject[] objects = GameObject.FindGameObjectsWithTag ("object"); //retorna tds os Light activos

		foreach (GameObject Object in objects) {
			Vector3 toVector = (Object.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle (forward, toVector);

			if (angleToTarget <= halfAngle) {
				visibleObjects.Add (Object);
			}
		}

		return (GameObject[])visibleObjects.ToArray(typeof(GameObject));
	}


}
