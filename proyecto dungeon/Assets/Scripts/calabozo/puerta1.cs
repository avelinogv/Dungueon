using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class puerta1 : MonoBehaviour {
    
    public Animation animo;
    public Controladorpanel hoja;
    public persocompleto acceso;
    public GameObject brazaletes;
    public Objetivo scripob;
    public Resume Scripresume;
    // Use this for initialization
    void Start () {
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();
        acceso = GameObject.Find("PersonajeJuego").GetComponent<persocompleto>();
        brazaletes = GameObject.Find("brazaletes");
        brazaletes.SetActive(false);
        scripob = GameObject.Find("Camera_mapa").GetComponent<Objetivo>();
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void  OnTriggerEnter()
    {
        scripob.primerito = true;
    
        if (acceso.fuerza < 15&& Scripresume.primerapuerta ==false)
        {
            hoja.activo();
            hoja.texto.text = "Muy debil, necesitas 15 puntos de fuerza y tienes " + acceso.fuerza + " buscate unos buenos guantes en la sala";
            brazaletes.SetActive(true);

        }
        else if(acceso.fuerza < 15 && Scripresume.primerapuerta == true)
        {
            hoja.activo();
            hoja.texto.text = "Olvidadizo, esta puerta requiere 15 de fuerza, anda y equipate con algo¡¡¡¡";
        }

        else 
        {
            animo.Play("Open");
        }
        //gameObject.GetComponent(Animation).Play("Open");

    }

public void OnTriggerExit()
{
        hoja.Desactivo();
        if (acceso.fuerza >= 15)
        {
            animo.Play("Close");
        }
        //gameObject.GetComponent(Animation).Play("Close");

    }

}
