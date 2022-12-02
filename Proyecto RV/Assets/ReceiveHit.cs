using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ReceiveHit : MonoBehaviour
{
    public UnityEvent myEvent; 
    public void OnPointerEnter() { }
    public void OnPointerExit() { }
    public void OnPointerClick() { myEvent.Invoke(); }
}
