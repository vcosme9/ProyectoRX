using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TeleportButton : MonoBehaviour
{
    // Variables Globales
    private bool isColliding = false;
    private bool isLooking = false;
    public UnityEvent myEvent;

    private Image _myImage;
    public Material red;
    public Material green;
    private Material white;

    public void Start()
    {
        _myImage = GetComponent<Image>();
        white = _myImage.material;
    }

    public void MyOnPointerEnter()
    {
        print("Entra");
        if (!isColliding)
        {
            _myImage.material = green;
        }
        isLooking = true;
    }
    public void MyOnPointerExit()
    {
        print("Sale");
        if (!isColliding)
        {
            _myImage.material = white;
        }
        isLooking = false;
    }
    public void MyOnPointerClick()
    {
        if (!isColliding)
        {
            myEvent.Invoke();
            print("Click");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        _myImage.material = red;
        isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isLooking)
        {
            _myImage.material = white;
        }
        else
        {
            _myImage.material = green;
        }

        isColliding = false;
    }


}