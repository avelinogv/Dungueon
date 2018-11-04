using UnityEngine;
using System.Collections;

public class Interracion : MonoBehaviour {
    public AudioSource habla;
    public Controladorpanel hoja;
    // Use this for initialization
    void Start()
    {
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
    }



    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "Pulsa el boton e para interactuar";


    }


    public void OnTriggerStay()
    {

        if (Input.GetKey(KeyCode.E))
        {
            hoja.Desactivo();
            habla.Play();

        }

    }


    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
