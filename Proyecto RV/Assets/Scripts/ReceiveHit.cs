using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ReceiveHit : MonoBehaviour
{
    public UnityEvent myEvent;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void MyOnPointerEnter()
    {
        animator.SetTrigger("Highlighted");
    }
    public void MyOnPointerExit()
    {
        animator.SetTrigger("Normal");
    }
    public void MyOnPointerClick()
    {
        myEvent.Invoke();
    }


}