using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControllerGrab : MonoBehaviour
{

    // Variables Globales
    public GameObject myHand; // EmptyObject dentro de MainCamera de Player
    bool inHands = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myHand.transform.childCount == 0)
        {
            inHands = false;
        }
        
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerClick()
    {
        if (!inHands)
        {
            inHands = true;
            // El objeto se hace hijo de myHand
            transform.SetParent(myHand.transform);
            // Se posiciona un poco hacia abajo de la camara
            transform.localPosition = new Vector3(0f, -0.672f, 0f);
            
        }
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
       
    }

    public void OnPointerEnter()
    {

    }

}
