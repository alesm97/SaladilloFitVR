////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: MovementDisc.cs
////////////////////////////////////////////////
using UnityEngine;

public class MovementDisc : MonoBehaviour {

	// Velocidad máxima de desplazamiento.
	public float maxSpeed = 0.5f;
	// Fuerza de empuje.
	public float pushForce = 10f;
	// Si el usuario está mirnado directamente.
	[HideInInspector]public bool isHover = false;
	// Referencia al RigidBody que queremos mover.
	public Rigidbody rb;
	
	
	void FixedUpdate () {
		if (isHover)
		{
			if (rb.velocity.magnitude < maxSpeed)
			{
				rb.AddForce((GvrPointerInputModule.Pointer.CurrentRaycastResult.worldPosition - transform.position).normalized * pushForce);
			}
		}
	}

	
	/// <summary>
	/// Acciones a realizar para el evento de mirar el disco.
	/// </summary>
	public void StartLookingAtDisc()
	{
		isHover = true;
	}

	/// <summary>
	/// Acciones a realizar para el evento de dejar de mirar el disco.
	/// </summary>
	public void StopLookingAtDisc()
	{
		isHover = false;
	}
}
