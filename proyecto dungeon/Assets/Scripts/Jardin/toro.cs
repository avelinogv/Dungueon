using UnityEngine;
using System.Collections;

public class toro : MonoBehaviour {

    public Animation animo;
    public AudioSource Altavoz;
    public AudioClip enfadado;
    public AudioClip golpea;
    public AudioClip yunque;
    public Transform mino;
    public Transform player;
    public float distancia;
    public bool furia = true;
    public bool ladr = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        distancia = Vector3.Distance(mino.position, player.transform.position);

        if (distancia > 36)
        {
            animo.Play("idleBreatheWeapon");
            Debug.Log("me paro");
            Altavoz.Stop();
            furia = true;
        }

        else if (distancia < 36 && distancia >= 28)
        {
            if (furia)
            {
                Altavoz.clip = enfadado;
                Altavoz.Play();
            }
            animo.Play("getHitNoWeapon");


            furia = false;
            ladr = true;
        }
        else if (distancia < 28)
        {

            animo.Play("attack3Weapon");
            if (ladr)
            {
                Altavoz.clip = golpea;
                Altavoz.Play();
            }
           // Altavoz.PlayOneShot(yunque);
            furia = true;
            ladr = false;
        }
        // animo.Play("runBite");

    }


public void martillaco()
    {
        Altavoz.PlayOneShot(yunque);


    }

    public void enfa()
    {
        Altavoz.PlayOneShot(golpea);

    }

    public void ruge()
    {
        Altavoz.PlayOneShot(enfadado);

    }


}

