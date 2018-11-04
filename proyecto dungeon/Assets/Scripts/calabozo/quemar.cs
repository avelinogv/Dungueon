using UnityEngine;
using System.Collections;

public class quemar : MonoBehaviour {
    public GameObject fuegote;

    public Controladorpanel hoja;
    public Resume scripresume;
    public persocompleto acceso;
    // Use this for initialization
    void Start () {
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
        acceso = GameObject.Find("PersonajeJuego").GetComponent<persocompleto>();
        fuegote = GameObject.Find("Fuego");
        fuegote.SetActive(false);
        scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter()
    {
      


    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();

        fuegote.SetActive(false);

    }


    public void OnTriggerStay()
    {
        float resto;
        fuegote.SetActive(true);
        if (acceso.defensa > 40) resto = 0.05f;
        else if (acceso.defensa > 30) resto = 0.1f;
        else if (acceso.defensa > 20) resto = 0.5f;
        else if (acceso.defensa > 10) resto = 1;
        else resto = 2;

       
        scripresume.recivodaño = true;
        Debug.Log("le resto :" + resto);
        acceso.contadorvida = acceso.contadorvida - resto;
        if (acceso.contadorvida <= 0)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("destru"))
            {
                Destroy(g);

            }
            Application.LoadLevel("DatosPersonaje");

        }
        // hoja.texto.text = "tu vida"+ Mathf.Round(vida);

    }


}
