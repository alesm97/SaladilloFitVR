////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: ConfigurationText.cs
////////////////////////////////////////////////
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConfigurationText : MonoBehaviour
{
    // Objeto que indica que se ha establecido la conexión
    public GameObject connected;

    // Objeto que indica que no se ha establecido la conexión
    public GameObject disconnected;

    // Use this for initialization
    void Start()
    {
        // Se recupera el valor de dirección IP almacenado en al configuración de la aplicación
        GameManager.ipAddress = PlayerPrefs.GetString(GameManager.IP_ADDRESS);
        // Mostramos la dirección IP
        GetComponent<Text>().text = GameManager.ipAddress;
        // Se comprueba la conectividad con la webapi
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
            
            // Compruebo el valor devuelto por el método, si la respuesta es correcta activa el objeto que indica qie se ha establecido la conexión, si no, el otro
            connected.SetActive(www.responseCode == 200);
            disconnected.SetActive(!connected.activeSelf);
        }

    }
}