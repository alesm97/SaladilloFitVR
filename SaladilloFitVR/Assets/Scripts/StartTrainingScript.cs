////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: StartTrainingScript.cs
////////////////////////////////////////////////
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StartTrainingScript : MonoBehaviour {

	/// <summary>
	/// Método que se llamará al hacer click.
	/// </summary>
	public void Click()
	{
		StartTraining();
	}

	/// <summary>
	/// Método que llamará a la corrutina que abre el entrenamiento.
	/// </summary>
	private void StartTraining()
	{
		StartCoroutine(StartTrainingWepApi());
	}

	/// <summary>
	/// Corrutina que realizará la llamada a la api.
	/// </summary>
	/// <returns></returns>
	IEnumerator StartTrainingWepApi()
	{
		if (GameManager.training > 0)
		{
			// Construimos la información que se envia a la webAPI
			WWWForm form = new WWWForm();
			form.AddField("dni", GameManager.dni);
			form.AddField("name", GameManager.training);
			
			// Crea la petición a la webAPI
			using (UnityWebRequest www = UnityWebRequest.Post(
				Uri.EscapeUriString(string.Format(GameManager.WEP_API_LOG_TRAINING, GameManager.ipAddress)), form))
			{
				// Envia la petición a la webAPI y espera la respuesta
				yield return www.SendWebRequest();

				// Acción a realizar si la petición se ha ejecutado sin error
				if (!www.isNetworkError)
				{
					// Carga la escena de entrenamiento
					SceneManager.LoadScene("Machines");
				}
			}
		}
	}
}
