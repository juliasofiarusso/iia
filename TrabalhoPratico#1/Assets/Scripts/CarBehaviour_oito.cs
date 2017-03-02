using UnityEngine;
using System.Collections;

public class CarBehaviour_oito : CarBehaviour {
	public float a;
	public float b;
	public float leftSensor;
	public float rightSensor;
	void Update()
	{
		//Read sensor values
	leftSensor = LeftLD.GetGaussianOutput (); //força do detector de luz esq
	rightSensor = RightLD.GetGaussianOutput (); //força do detector de luz dir

		//Calculate target motor values
//		m_LeftWheelSpeed = leftSensor * MaxSpeed;
//		m_RightWheelSpeed = rightSensor * MaxSpeed;

	
		if (leftSensor > 0.25f && leftSensor < 0.75f) {
			m_LeftWheelSpeed = (1.0f / (b * Mathf.Sqrt (2 * Mathf.PI))) * Mathf.Exp (-1f * Mathf.Pow (leftSensor - a, 2.0f) / (2 * Mathf.Pow (b, 2.0f))) * MaxSpeed;
		} else {
			m_LeftWheelSpeed = 0;
		}
		if (rightSensor > 0.25f && rightSensor < 0.75f) {
			m_RightWheelSpeed = (1.0f / (b * Mathf.Sqrt (2 * Mathf.PI))) * Mathf.Exp (-1f * Mathf.Pow (rightSensor - a, 2.0f) / (2 * Mathf.Pow (b, 2.0f))) * MaxSpeed;
		} else {
			m_RightWheelSpeed = 0;
		}


	}
}
