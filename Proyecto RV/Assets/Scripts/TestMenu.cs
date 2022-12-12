using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMenu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("C"))
        {
            Destroy(gameObject);
        }
    }
}
