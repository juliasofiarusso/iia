using UnityEngine;
using System.Collections;

public class CarBehaviour2aDist : CarBehaviourDist {

	void Update()
	{
		//Read sensor values
		float leftSensor = LeftOB.GetLinearOutput (); //força do detector de luz esq
		float rightSensor = RightOB.GetLinearOutput (); //força do detector de luz dir

		//Calculate target motor values
		m_LeftWheelSpeed = rightSensor * MaxSpeed;
		m_RightWheelSpeed = leftSensor * MaxSpeed;
	}
}
