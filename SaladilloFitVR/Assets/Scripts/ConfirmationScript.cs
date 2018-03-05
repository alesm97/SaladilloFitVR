////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: ConfirmationScript.cs
////////////////////////////////////////////////
using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConfirmationScript : MonoBehaviour {

	// Objeto que representa el panel de entrenamientos
    public GameObject trainingPanel;
    // Objeto con del dni del cliente
    public Text dni;
    // Objeto con el mensaje de bienvenida
    public Text welcome;

    /// <summary>
    /// Método que se llama al pulsar el botón de confirmación.
    /// </summary>
    /// <remarks>
    /// Obtiene el dni que ha introducido el usuario y lo guarda
    /// </remarks>
    public void Click()
    {
        // Se obtiene el DNI introducido por el cliente
        GameManager.dni = dni.GetComponent<Text>().text;

        // Se llama a GetClient para recuperar el cliente con ese dni
        GetClient();
    }

    /// <summary>
    /// Obtiene el cliente.
    /// </summary>
    /// <remarks>
    /// Mediante la corrutina se intentará recuperar el cliente. Si no lo recibe, desactiva el panel de entrenamientos.
    /// </remarks>
    private void GetClient()
    {
        StartCoroutine(GetClientWebAPI());
    }

    private IEnumerator GetClientWebAPI()
    {
        // Prepara la petición a la web API
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEP_API_GET_CLIENT_NAME, GameManager.ipAddress,
                GameManager.dni))))
        {
            // Realización de la petición
            yield return www.SendWebRequest();

            // Si no hay error, se sigue
            if (!www.isNetworkError)
            {
                // Se recupera el cliente
                String client = www.downloadHandler.text;
                client = Regex.Replace(client, "\"", "");

                // Se comprueba si el cliente está vacío
                if (!String.IsNullOrEmpty(client))
                {
                    // Se guarda el nombre del cliente
                    GameManager.name = client;
                    // Se pone el nombre donde estaba el dni
                    dni.GetComponent<Text>().text = GameManager.name;
                    // Se activa el panel de entrenamiento
                    trainingPanel.SetActive(true);
                    // Se pone el mensaje de bienvenida personalizado
                    welcome.GetComponent<Text>().text = String.Format("Hola {0}", GameManager.name);
                }
                // Si hay error, se desactiva el panel y se vuelve al mensaje de bienvenida original
                else
                {
                    trainingPanel.SetActive(false);
                    welcome.GetComponent<Text>().text = "Bienvenid@ a Saladillo Fit VR";
                }
            }
        }
    }
}
