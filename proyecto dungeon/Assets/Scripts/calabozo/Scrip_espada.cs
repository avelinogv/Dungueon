using UnityEngine;
using System.Collections;

public class Scrip_espada : MonoBehaviour {
    public AudioSource altavoz;
    public AudioClip espada;
    // Use this for initialization
    public void OnTriggerEnter()
    {
        altavoz.clip = espada;
        altavoz.Play();


    }

    public void OnTriggerExit()
    {

        //altavoz.Play(false);
        //hoja.Desactivo();
        //DestroyObject(gameObject);


    }
}
