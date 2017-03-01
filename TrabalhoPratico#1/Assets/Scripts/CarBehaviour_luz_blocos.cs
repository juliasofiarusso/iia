using UnityEngine;
using System.Collections;

public class CarBehaviour_luz_blocos : CarBehaviour {
	
	void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.GetLinearOutput (); //força do detector de luz esq
		float rightSensor = RightLD.GetLinearOutput (); //força do detector de luz dir

		float leftSensor2 = LeftOB.GetLinearOutput (); //força do detector de luz esq
		float rightSensor2 = RightOB.GetLinearOutput (); //força do detector de luz dir

		//Calculate target motor values
		m_LeftWheelSpeed = (leftSensor +leftSensor2) * MaxSpeed /2;
		m_RightWheelSpeed = (rightSensor2 + rightSensor) * MaxSpeed/2;
	}
}
