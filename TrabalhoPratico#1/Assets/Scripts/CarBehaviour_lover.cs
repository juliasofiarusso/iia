using UnityEngine;
using System.Collections;

public class CarBehaviour_lover : CarBehaviour {
	
	void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.GetLinearOutput (); //força do detector de luz esq
		float rightSensor = RightLD.GetLinearOutput (); //força do detector de luz dir

		//Calculate target motor values
		m_LeftWheelSpeed = MaxSpeed -(leftSensor * MaxSpeed);
		m_RightWheelSpeed= MaxSpeed -(rightSensor * MaxSpeed);
	}
}
