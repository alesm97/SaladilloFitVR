////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: ButtonClick.cs
////////////////////////////////////////////////
using UnityEngine;

public class ButtonClick : MonoBehaviour {

	// GameObject que se modifica cuando se pulsa el botón
	public GameObject clickObject;

	public void Click()
	{
		// Si el objeto está activo lo desactiva y viceversa
		clickObject.SetActive(!clickObject.activeSelf);
	}
	
}
