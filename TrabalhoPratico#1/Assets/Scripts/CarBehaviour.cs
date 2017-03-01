using UnityEngine;
using System.Collections;

public class CarBehaviour : MonoBehaviour {
	
	public float MaxSpeed;
	public WheelCollider RR; 
	public WheelCollider RL;
	public LightDetectorScript LeftLD;
	public LightDetectorScript RightLD;
	public ObjectDetectorScript LeftOB;
	public ObjectDetectorScript RightOB;

	private Rigidbody m_Rigidbody;
	public float m_LeftWheelSpeed;
	public float m_RightWheelSpeed;
	private float m_axleLength;

	void Start()
	{
		m_Rigidbody = GetComponent<Rigidbody> ();
		m_axleLength = (RR.transform.position - RL.transform.position).magnitude; //tamanho do vector do centro ao espaço 
	}

	void FixedUpdate () {
		//Calculate forward movement
		float targetSpeed = (m_LeftWheelSpeed + m_RightWheelSpeed) / 2;
		Vector3 movement = transform.forward * targetSpeed * Time.deltaTime; //movimento do carro

		//Calculate turn degrees based on wheel speed
		float angVelocity = (m_LeftWheelSpeed - m_RightWheelSpeed) / m_axleLength * Mathf.Rad2Deg * Time.deltaTime; //velocidade de cada toda = a 1 valor / tamanho do vector * graus
		Quaternion turnRotation = Quaternion.Euler (0.0f, angVelocity, 0.0f); //rotação sobre cada eixo x,y,z

		//Apply to rigid body
		m_Rigidbody.MovePosition (m_Rigidbody.position + movement); //aplicação do mov ao carro
		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation); //aplicação da rotação sobre o eixo do y ao carro
	}
}
