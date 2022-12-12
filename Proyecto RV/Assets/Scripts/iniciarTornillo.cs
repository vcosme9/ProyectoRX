using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniciarTornillo : MonoBehaviour
{
    // se asignan manualmente
    public Transform screw;
    public Transform spaceship;
    public Transform[] screwPos;
    public GameObject myHand;

    private int screwCounter = 0;

    [Header("Particle System")]
    public ParticleSystem sparks;
    public ParticleSystem sparksFlash;
    public ParticleSystem smoke;
    public ParticleSystem sparks1;
    public ParticleSystem sparksFlash1;
    public ParticleSystem smoke1;
    public ParticleSystem sparks2;
    public ParticleSystem sparksFlash2;
    public ParticleSystem smoke2;

    // se asignan en el start
    [HideInInspector] public Transform player;
    [HideInInspector] public Animator screwAnim;
    [HideInInspector] public Transform playerHand;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        screwAnim = screw.gameObject.GetComponent<Animator>();
        playerHand = myHand.transform; // la mano es hija de la camara, que es hija de player
    }

    void Update()
    {
        if(playerHand.childCount == 1)
        {
            screw = playerHand.GetChild(0);
            screwAnim = screw.gameObject.GetComponent<Animator>();
        }
    }

    IEnumerator StopParticlesCoroutine()
    {
        yield return new WaitForSeconds(2f);

        sparks.Stop();
        sparksFlash.Stop();
        smoke.Stop();

    }

    IEnumerator StopParticlesCoroutine1()
    {
        yield return new WaitForSeconds(2f);

        sparks1.Stop();
        sparksFlash1.Stop();
        smoke1.Stop();

    }

    IEnumerator StopParticlesCoroutine2()
    {
        yield return new WaitForSeconds(2f);

        sparks2.Stop();
        sparksFlash2.Stop();
        smoke2.Stop();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "TP" && playerHand.childCount > 0)
        {
            // posicionamos el siguiente tornillo en su posicion
            for (int i=0; i < screwPos.Length; i++)
            {
                if (screwCounter == i)
                {
                    screw.position = screwPos[i].position;
                    print(screw.position);
                }
            }
            // sacamos el tornillo de Player y lo metemos en Nave
            screw.GetComponent<Light>().intensity = 0;
            screw.SetParent(spaceship);
            switch (screwCounter)
            {
                default: 
                    StartCoroutine(StopParticlesCoroutine());
                    break;
                case 1:
                    StartCoroutine(StopParticlesCoroutine1());
                    break;
                case 2:
                    StartCoroutine(StopParticlesCoroutine2());
                    break;
            }
            // desactivamos particulas de nave rota
            //StartCoroutine(StopParticlesCoroutine());
            // activamos animacion de meter tornillo
            screwAnim.Play("Tornillo");

            screwCounter += 1;
            //Debug.Log("colision detectada: " + screwCounter);
        }
    }
}
