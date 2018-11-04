using UnityEngine;
using System.Collections;

public class perro : MonoBehaviour {
    public Animation animo;
    public AudioSource Altavoz;
    public AudioClip enfadado;
    public AudioClip ladra;
    public Transform perraco;
    public Transform player;
    public float distancia;
    public bool furia = true;
    public bool ladr = true;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        distancia = Vector3.Distance(perraco.position, player.transform.position);

        if (distancia > 36 )
        {
            animo.Play("idleLookAround");
            Debug.Log("me paro");
             Altavoz.Stop();
            furia = true;
        }

        else if (distancia < 36&& distancia >= 28)
        {
            if (furia)
            {
                Altavoz.clip = enfadado;
                Altavoz.Play();
            }
            animo.Play("idleAggresive");
          
            
            furia = false;
            ladr = true;
        }
        else if (distancia < 28)
        {
          
            animo.Play("runBite");
            if (ladr)
            {
                Altavoz.clip = ladra;
                Altavoz.Play();
            }
            furia = true;
            ladr = false;
        }
        // animo.Play("runBite");

    }
}
