using UnityEngine;
using System.Collections;

public class scripcomida : MonoBehaviour
{
    public persocompleto acceso;
    public Controladorpanel hoja;
    public Resume Scripresume;
    // Use this for initialization
    void Start()
    {
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();
        acceso = GameObject.Find("PersonajeJuego").GetComponent<persocompleto>();
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "Mmm que rico recupero vida";

        acceso.contadorvida += 20;
        if (acceso.contadorvida > acceso.vidacompleta)
            acceso.contadorvida = acceso.vidacompleta;
    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        Scripresume.cacomida = true;
        DestroyObject(gameObject);


    }
}