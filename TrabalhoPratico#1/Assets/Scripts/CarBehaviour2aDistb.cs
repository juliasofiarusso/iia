using UnityEngine;
using System.Collections;

public class CarBehaviour2aDistb : CarBehaviourDist {

	void Update()
	{
		//Read sensor values
		float leftSensor = LeftOB.GetLinearOutput (); //força do detector de luz esq
		float rightSensor = RightOB.GetLinearOutput (); //força do detector de luz dir

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;
	}
}
