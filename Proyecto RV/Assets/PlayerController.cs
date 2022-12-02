using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        print("collision");
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1.6f, gameObject.transform.position.z - 3.5f);
    }
}
