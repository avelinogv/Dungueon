using UnityEngine;
using System.Collections;

public class scripborracho : MonoBehaviour {


    public Controladorpanel hoja;
    // Use this for initialization
    void Start()
    {
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
    }



    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "El famoso monje borracho que ha incendiado la sala";


    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}