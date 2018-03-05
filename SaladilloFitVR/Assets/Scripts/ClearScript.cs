////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: ClearScript.cs
////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class ClearScript : MonoBehaviour
{
    public Text ipAddress;

    public void Click()
    {
        ipAddress.GetComponent<Text>().text = "";
    }
}