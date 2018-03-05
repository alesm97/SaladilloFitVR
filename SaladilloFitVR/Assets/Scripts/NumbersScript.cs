////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: NumberScript.cs
////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class NumbersScript : MonoBehaviour
{
	// Carácter que se sumará
	public string number;
	// Cadena a la cual se añadirá
	public Text ipText;
	
	// Use this for initialization
	void Start ()
	{
		GetComponentInChildren<Text>().text = number;
	}

	/// <summary>
	/// Método que se llamará al hacer click.
	/// </summary>
	/// <remarks>Se añadirá el carácter especificado a la cadena del objeto.</remarks>
	public void Click()
	{
		ipText.GetComponent<Text>().text += GetComponentInChildren<Text>().text;
	}
}
