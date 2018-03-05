////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: DeleteScript.cs
////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class DeleteScript : MonoBehaviour
{
    // Objeto del cual se va a restar un carácter
    public Text ipAddress;

    /// <summary>
    /// Método que se llamará al hacer click.
    /// </summary>
    /// <remarks>Se obtendrá la cdena de texto y se le hará un substring restando el último caráter.</remarks>
    public void Click()
    {
        string text = ipAddress.GetComponent<Text>().text;
        if (text.Length > 0)
        {
            ipAddress.GetComponent<Text>().text = text.Substring(0, text.Length - 1);
        }
        
    }
}