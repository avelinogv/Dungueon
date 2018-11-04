using UnityEngine;
using System.Collections;

public class cofre : MonoBehaviour {

    public Animation animo;
    public Controladorpanel hoja;
    // Use this for initialization
    void Start()
    {
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}


void OnTriggerEnter()
    {

       animo.Play("Open");
        hoja.activo();
        hoja.texto.text = "Ni oro ni joya , esta vacio";
    }

    void OnTriggerExit()
    {
        hoja.Desactivo();
        animo.Play("Close");

    }
}
