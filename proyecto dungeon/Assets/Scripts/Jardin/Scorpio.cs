using UnityEngine;
using System.Collections;

public class Scorpio : MonoBehaviour {

    public Animation animo;
    public AudioSource Altavoz;
    public AudioClip tenazitas;
    public AudioClip pincho;
    public AudioClip murmullo;
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
            animo.Play("walkForward");
            Debug.Log("me paro");
            Altavoz.Stop();
            furia = true;
        }

        else if (distancia < 36 && distancia >= 28)
        {
            if (furia)
            {
                Altavoz.clip = murmullo;
                Altavoz.Play();
                
            }
            animo.Play("strafeLeftClawAttack");
            //pinchito();

            furia = false;
            ladr = true;
        }
        else if (distancia < 28)
        {

            animo.Play("clawsStingerAttack3HitCombo");
            if (ladr)
            {
                //Altavoz.clip = golpea;
                //Altavoz.Play();
            }
            // Altavoz.PlayOneShot(yunque);
            furia = true;
            ladr = false;
        }
        // animo.Play("runBite");

    }


    public void tenaza()
    {
        Altavoz.PlayOneShot(tenazitas);


    }

    public void enfa()
    {
        Altavoz.PlayOneShot(murmullo);

    }

    public void pinchito()
    {

        
        Altavoz.PlayOneShot(pincho);

    }


  

}