using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {
	
	void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.GetLinearOutput (); //força do detector de luz esq
		float rightSensor = RightLD.GetLinearOutput (); //força do detector de luz dir

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;
	}
}
