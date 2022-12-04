using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool justJumped = false;
    private float targetTime = 2f;
    public Transform centro;
    public GameObject flecha;
    public Transform camara;

    private void Update()
    {
        if (justJumped)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                justJumped = false;
            }
        }


        // La plataforma de salto sigue al jugador
        centro.position = new Vector3(this.transform.position.x, 0.01f, this.transform.position.z);
        centro.eulerAngles = new Vector3(0f, camara.eulerAngles.y, 0f);
    }

    public void Teleport()
    {
        if (!justJumped)
        {
            this.transform.position = new Vector3(flecha.transform.position.x, 1.6f, flecha.transform.position.z);
            justJumped = true;
            targetTime = 2f;
        }

    }

}