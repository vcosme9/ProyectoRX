using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    public Transform player;
    public Transform centro;
    private bool justJumped = false;
    private float targetTime = 2f;

    public void OnPointerEnter() { }
    public void OnPointerExit() { }
    public void OnPointerClick() {
        if (justJumped == false)
        {   
            player.position = new Vector3(this.transform.position.x, 1.6f, player.position.z + 3.5f);            
            justJumped = true;
            targetTime = 2f;
            centro.position = new Vector3(player.position.x, 0.01f, player.position.z);
        }

    }



    private void Update()
    {
        centro.eulerAngles = new Vector3(0f, player.eulerAngles.y, 0f);
        if (justJumped == true)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                justJumped = false;
            }
        }

    }
}
