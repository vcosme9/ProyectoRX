using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraPointer2 : MonoBehaviour
{

    // Variables Globales
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    private GameObject _objectInHands = null;

    private bool inHands = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            //Debug.Log(hit.transform.gameObject.tag);
            // GameObject detected in front of the camera and Tag is "tornillo" and users clicks mouse left button.
            if (_gazedAtObject != hit.transform.gameObject && hit.transform.tag == "tornillo")
            {
                Debug.Log("ESTOY APUNTANDOLO CRACK!!!!");
                if (Input.GetButtonDown("Fire1") && !inHands)
                {
                    Debug.Log("Quiero cogerlo...");
                    inHands = true;
                    // New GameObject.
                    _gazedAtObject?.SendMessage("OnPointerExit");
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("OnPointerEnter");
                    _objectInHands = hit.transform.gameObject;
                    
                }
            }

            if (Input.GetButtonDown("Fire2") && inHands)
            {
                inHands = false;
                Debug.Log("QUIERO SOLTARLOOOOOO!!!!");
                _objectInHands?.SendMessage("ThrowObject");
                _objectInHands = null;
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = null;
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null; 
        }
    }
}
