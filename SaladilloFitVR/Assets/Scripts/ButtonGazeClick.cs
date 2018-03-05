////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: ButtonGazeClick.cs
////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class ButtonGazeClick : MonoBehaviour {

	// Tiempo que tardará en activarse el temporizador
	public float activationTime = 3f;
	// Indica si el puntero está sobre el objeto
	private bool isHover = false;
	// Indica si la acción se ha realizado
	private bool executed = false;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Si el usuario está mirando el objeto y el temporizador ha terminado de contar o si el suario está mirando el objeto
		// y pulsa el botón Fire1 del mando y la acción aún no se ha ejecutado, realizamos la acción corespondiente.
		if ((isHover && CustomPointerTimer.cpt.ended && !executed) || (isHover && Input.GetButtonDown("Fire1") && !executed))
		{
			// Se indica que ya se ha realizado la acción
			executed = true;
			// Desactivamos el contador de tiempo del cursor, para qevitar que se quede bloqueado
			CustomPointerTimer.cpt.stopCounting();
			// Invocar al click del botón
			GetComponent<Button>().onClick.Invoke();
		}
	}
	
	public void startHover()
	{
		// Indicamos que el objeto está siendo mirado directamente
		isHover = true;
		// Marcamos la acción como no realizado
		executed = false;
		// Iniciamos el contador del puntero, indicándole el tiempo de activación
		CustomPointerTimer.cpt.startCounting(activationTime);
	}

	/// <summary>
	/// Método que llamaremos desde el EventTrigger PointerExit
	/// </summary>
	public void endHover()
	{
		// Indicamos que el objeto ya no está siendo mirado
		isHover = false;
		// Reiniciamos el contador del puntero
		CustomPointerTimer.cpt.stopCounting();
	}
}
