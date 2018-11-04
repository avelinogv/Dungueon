using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Romperpuerta : MonoBehaviour {
    public Controladorpanel hoja;
    public persocompleto acceso;
    // Use this for initialization
    void Start () {
        acceso = GameObject.Find("PersonajeJuego").GetComponent<persocompleto>();
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.E))
        {
            DestroyObject(gameObject);
            hoja.Desactivo();

        }

    }


    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "Usa el boton e para romper la puerta";


    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
