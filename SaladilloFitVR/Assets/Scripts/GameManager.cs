////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: GameManager.cs
////////////////////////////////////////////////
public static class GameManager
{

	// Clave para al dirección IP
	public const string IP_ADDRESS = "IPAddress";
	// Variabl para almacenar la dirección IP de la web api
	public static string ipAddress;
	// Variabl para almacenar el dni
	public static string dni;
	// Variabl para almacenar la dirección IP de la web api
	public static int training;
	// Variabl para almacenar el nombre
	public static string name;
	
	
	
	
	// Constante con la URL del métpdp de la web API para guardar un cliente
	public const string WEP_API_LOG_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/LogTraining";
	// Constante con la URL del método de la web API para comprobar la conectividad
	public const string WEP_API_CHECK_CONNECTIVITY = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/CheckConnectivity";
	// Constante con la URL del método de la web API para conseguir el nombre de un cliente
	public const string WEP_API_GET_CLIENT_NAME = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetClientName?dni={1}";
	// Constante con la URL del método de la web API para conseguir un entrenamiento
	public const string WEP_API_GET_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetTraining?training={1}";
}
