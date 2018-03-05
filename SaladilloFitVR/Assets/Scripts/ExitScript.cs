////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: ExitScript.cs
////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

	/// <summary>
	/// Método que se llamará al hacer click.
	/// </summary>
	/// <remarks>Se pondrá el entrenamiento activo a 0 y se cargará la escena principal 'Main'.</remarks>
	public void Click()
	{
		GameManager.training = 0;
		SceneManager.LoadScene("Main");
	}
}
