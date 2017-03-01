using UnityEngine;
using System.Collections;

public class CarBehaviour_elipse : CarBehaviour {
	
	void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.GetGaussianOutput (); //força do detector de luz esq
		float rightSensor = RightLD.GetGaussianOutput (); //força do detector de luz dir

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		 m_RightWheelSpeed= rightSensor * MaxSpeed;
	}
}
