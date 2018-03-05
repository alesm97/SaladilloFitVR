////////////////////////////////////////////////
// Proyecto: SaladilloFitVR
// Alumno: Alejandro Segura Meléndez
// Curso: 2017/2018
// Archivo: TrainingButtonScript.cs
////////////////////////////////////////////////
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrainingButtonScript : MonoBehaviour {

	// Indica el número del entrenamiento
    public int training;
    // GameObject que representa el panel de detalles
    public GameObject detail;
    // Prefab de un GameObject que repesenta un ejercicio
    public GameObject trainingItem;

    /// <summary>
    /// Método que se ejecuta cuando se pulsa el botón de entrenamiento.
    /// </summary>
    /// <remarks>
    /// Se activa el panel de detalles y llama al método que carga los entrenamientos.
    /// </remarks>
    public void Click()
    {
        detail.SetActive(true);
        CheckExercises();
    }

    /// <summary>
    /// Obtiene los ejercicios de un entrenamiento.
    /// </summary>
    /// <remarks>
    /// Llamará a la corrutina GetExercisesWebApi para obtenerlos.
    /// </remarks>
    private void CheckExercises()
    {
        StartCoroutine(CheckExercisesWebAPI());
    }

    private IEnumerator CheckExercisesWebAPI()
    {
        // Prepara la petición a la web API
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEP_API_GET_TRAINING, GameManager.ipAddress, training.ToString()))))
        {
            // Hace la petición a la web API
            yield return www.SendWebRequest();

            // Si no hay error
            if (!www.isNetworkError)
            {
                // Se recupera el entrenamiento
                ExercisesList exercisesList = JsonUtility.FromJson<ExercisesList>(www.downloadHandler.text);
                
                // Destruye los entrenamientos anteriores que pueda haber
                foreach (Transform child in detail.transform) {
                    Destroy(child.gameObject);
                }
                
                
                // Se crea el objeto
                GameObject title = Instantiate(trainingItem);
                // Se asigna el texto que debe mostrar
                title.GetComponentInChildren<Text>().text = String.Format("Ejercicio {0}", training.ToString());
                // Se establece el padre
                title.transform.SetParent(detail.transform);
                // Se posiciona
                title.GetComponent<RectTransform>().localPosition = new Vector3(0, -0.5f, 0);
                
                for (int i = 0; i < exercisesList.training.Length; i++)
                {
                    // Se crea el ejercicio
                    GameObject newTrainingItem = Instantiate(trainingItem);
                    // Se asigna el texto
                    newTrainingItem.GetComponentInChildren<Text>().text = exercisesList.training[i].machine;
                    // Se establece su padre
                    newTrainingItem.transform.SetParent(detail.transform);
                    // Se posiciona
                    newTrainingItem.GetComponent<RectTransform>().localPosition = new Vector3(0, -0.5f * (i+2), 0);
                }

                GameManager.training = training;
            }
        }
    }

    #region Entidades

    [Serializable]
    public class ExercisesList
    {
        public Exercise[] training;
    }
    
    [Serializable]
    public class Exercise
    {
        public int training;
        public string machine;
    }

    #endregion
}
