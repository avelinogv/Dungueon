using UnityEngine;
using System.Collections;

public class scripdinero : MonoBehaviour {

    public persocompleto acceso;
    public Controladorpanel hoja;
    public Resume Scripresume;
    // Use this for initialization
    void Start()
    {
        
        acceso = GameObject.Find("PersonajeJuego").GetComponent<persocompleto>();
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "Dinerito para el bolsillito";

        Scripresume.dinero += 2000;
    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        Scripresume.cadinero = true;
      
        DestroyObject(gameObject);


    }
}