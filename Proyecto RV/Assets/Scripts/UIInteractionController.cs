using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInteractionController : MonoBehaviour
{

    public GameObject instrucciones;

    public void ButtonActions(string action)
    {
        Debug.Log("Le he dado al boton");
        switch (action)
        {
            case "INSTRUCCIONES":
                instrucciones.SetActive(!instrucciones.activeSelf);
                break;
            case "VIDEO":
                SceneManager.LoadScene("video360");
                break;
            case "JUEGO":
                SceneManager.LoadScene("Nave rota");
                break;
            case "SALIR":
                Application.Quit();
                break;
            default:
                Debug.Log("no existe el botón " + action);
                break;
        }
    }
}