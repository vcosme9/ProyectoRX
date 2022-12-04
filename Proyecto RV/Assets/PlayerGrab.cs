using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Añadir un EmptyObject dentro de MainCamera de Player un poco separado, untilizar un box collider para posicionarlo bien y despues eliminar el box collider
 *
 * Añadir un EventTrigger al objeto (PointerEnter) y arrastrar Player, en la funcion poner PlayerGrab.enabled y clickamos en el checkbox
 * Añadir otro evento (PointerExit) y arrastrar Player, en la funcion poner layerGrab.enabled y quitar en el checkbox
 * 
 * Quitar ek check del script de PlayerGrab de Player
*/
public class PlayerGrab : MonoBehaviour
{
    // Variables Globales
    public GameObject obj; // Objeto que queremos coger
    public GameObject myHand; // EmptyObject dentro de MainCamera de Player

    bool inHands = false;
    Vector3 objPos;

    // Start is called before the first frame update
    void Start()
    {
        objPos = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Variables Locales
        RaycastHit hit;
        // Cambiar por el boton del mando
        if (Input.GetButtonDown("Fire1"))
        {
            // Comprobamos que estamos apuntando al objeto
            if (Physics.Raycast(transform.position, Vector3.forward, out hit)) {
                if (hit.transform.tag == "tornillo")
                {
                    Debug.DrawRay(transform.position, Vector3.forward + hit.point, Color.red);
                    // Si el objeto no esta en mis manos, posicionarlo en mis manos
                    if (!inHands)
                    {
                        // El objeto se hace hijo de myHand
                        obj.transform.SetParent(myHand.transform);
                        // Se posiciona un poco hacia abajo de la camara
                        obj.transform.localPosition = new Vector3(0f, -0.672f, 0f);
                        inHands = true;
                    }
                    // Si el objeto esta en mis manos, soltarlo
                    else if (inHands)
                    {
                        // El objeto ya no es hijo de mis manos
                        obj.transform.SetParent(null);
                        // El objeto se devuelve a su posicion inicial
                        obj.transform.localPosition = objPos;
                        inHands = false;
                    }
                } else
                {
                    Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.red);
                }
                
            }
            
           

        }
        
    }
}
