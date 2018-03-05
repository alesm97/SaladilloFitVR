////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: CustomPointerScript.cs
////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class CustomPointerTimer : MonoBehaviour
{
    // Objeto compartido por todos los scripts
    public static CustomPointerTimer cpt;
    // Indica cuando está contanto
    [HideInInspector] public bool counting = false;
    // Indica si ha llegado al final
    [HideInInspector] public bool ended = false;


    // Tiempo por defecto que vamos a tener que esperar para que el contador se llene
    private float timeToWait = 3f;
    // Temporizador
    private float timer;
    // Componente Image de la imagen de relleno
    private Image image;

    // Se invoca antes que start()
    private void Awake()
    {
        //Se comprueba si el objeto está inicilizado
        if (cpt == null)
        {
            // Se obtiene el objeto
            cpt = GetComponent<CustomPointerTimer>();
        }
        // Se obtiene la imagen del reloj
        image = GetComponentInChildren<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            // Se incrementa el temporizador la porción de tiempo que ha tardado en renderizar el último Update.
            // De esta manera se tiene un control de tiempo real independientemente de las características de la máquina
            timer += Time.deltaTime;
            // Se rellena la imagen la cantidad proporcional al temporizador
            image.fillAmount = timer / timeToWait;
        }
        else
        {
            // Se reinicia el temporizador
            timer = 0f;
            // Se reinicia el relleno de la imagen
            image.fillAmount = timer;
        }
        
        // Se comprueba si se ha cumplido el tiempo de espera
        if (timer >= timeToWait)
        {
            // Se indica que el contador ha finalizado
            ended = true;
        }
    }

    /// <summary>
    /// Inicia el temporizador utilizando el tiempo indicado.
    /// </summary>
    /// <param name="time">Tiempo de espera.</param>
    public void startCounting(float time)
    {
        counting = true;
        ended = false;
        timeToWait = time;
    }

    /// <summary>
    /// Para el temporizador.
    /// </summary>
    public void stopCounting()
    {
        counting = false;
        ended = true;
    }
    
}