////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: SaveScript.cs
////////////////////////////////////////////////
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour
{

	// Objeto que indica que se ha establecido la conexión
	public GameObject connected;
	// Objeto que indica que no se ha establecido la conexión
	public GameObject disconnected;	
	// Objeto con la direccion IP introducida por el usuario
	public Text IPAddress;	
	// Objeto correspondiente al panel que permite seleccionar entrenamiento
	public GameObject trainingPanel;
	// Objeto que corresponde al panel del cliente
	public GameObject clientPanel;
	
	/// <summary>
	/// Método que se ejecuta al pulsar el botón Save.
	/// </summary>
	/// <remarks>Obtiene la IP introducida por el usuario y la guarda en las preferencias de la aplicación.</remarks>
	public void Click()
	{
		// Se obtiene la dirección IP introducida por el usuario
		GameManager.ipAddress = IPAddress.GetComponent<Text>().text;
		// Se guardala dirección IP
		PlayerPrefs.SetString(GameManager.IP_ADDRESS,GameManager.ipAddress);
		// Se almacena el valor en la configuración de la aplicación
		PlayerPrefs.Save();

		CheckConnectivity();
	}
	
	/// <summary>
	/// Comprueba si existe conexión con la webApi
	/// </summary>
	/// <remarks>Llamar a una corrutina CheckConnectivityWebapi para comprobar la conexión</remarks>
	private void CheckConnectivity()
	{
		StartCoroutine(CheckConnectivityWebapi());
	}
	
	IEnumerator CheckConnectivityWebapi()
	{
		// Prepara la petición a la webApi
		using (UnityWebRequest www =
			UnityWebRequest.Get(
				Uri.EscapeUriString(String.Format(GameManager.WEP_API_CHECK_CONNECTIVITY, GameManager.ipAddress))))
		{
			// Se hace la petición a la webApi
			yield return www.SendWebRequest();
            
			// Comprueba el valor devuelto por el método, si la respuesta es correcta activa el objeto que indica qie se ha establecido la conexión, si no, el otro
			connected.SetActive(www.responseCode == 200);
			disconnected.SetActive(!connected.activeSelf);
			clientPanel.SetActive(www.responseCode == 200);
			if (www.responseCode != 200)
			{
				trainingPanel.SetActive(false);
			}
		}

	}
}
