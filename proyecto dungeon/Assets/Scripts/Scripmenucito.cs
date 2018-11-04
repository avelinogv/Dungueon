using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Scripmenucito : MonoBehaviour {

 
    public Controlador_hoja_menusito hoja;
    public GameObject menu;
    public GameObject menu2;
    public GameObject botonopcion;
    public GameObject botonopcion1;
    public GameObject pantalla;
    public Slider Slidemusi;
    public GameObject controlmusi;
    public Musicote scripmusi;
    GameObject muscia;
    GameObject guar;
    public bool joe = false;
    // Use this for initialization
    void Start()
    {
        pantalla = GameObject.Find("Canvas");
        hoja = GameObject.Find("Controlador_hoja_menu").GetComponent<Controlador_hoja_menusito>();
        menu = GameObject.Find("Menu");
        menu2 = GameObject.Find("MenuSecundario");
        menu.SetActive(false);
        menu2.SetActive(false);
        Slidemusi = GameObject.Find("Slidermusi").GetComponent<Slider>();
            controlmusi = GameObject.Find("Controlmusi");
            controlmusi.SetActive(false);
        scripmusi = GameObject.Find("Musica").GetComponent<Musicote>();
        Slidemusi.value = scripmusi.volumen;
        muscia = GameObject.Find("Musica");
        guar = GameObject.Find("Manageguardado");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.M))
        {

            pantalla.SetActive(false);
            menu.SetActive(true);
            GameObject myEventSystem = GameObject.Find("EventSystem");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(botonopcion1);
        }

        if (Input.GetKey(KeyCode.E))
        {
            hoja.Desactivo();
            controlmusi.SetActive(false);
            if (joe)
            {
                GameObject myEventSystem = GameObject.Find("EventSystem");
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(botonopcion);
                joe = false;
            }
            }

    }


    public void sonido()
    {
        hoja.Activo();
        hoja.texto.text = "                                                              ";
        controlmusi.SetActive(true);

        joe = true;
    }

    public void cambiosonido()
    {

        scripmusi.volumen = Slidemusi.value;
    }

    public void cargar()
    {
        hoja.Activo();
        hoja.texto.text = "Lo siento este juego no llega a tanto"+ "\n<color=green><size=10>(Pulsa e para quitar mensaje)</size></color>";

    }

    public void NuevaPartida()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("destru"))
        {
            Destroy(g);
           
        }
        Application.LoadLevel("DatosPersonaje");
    }

    public void salir()
    {
        GameObject muscia = GameObject.Find("Musica");
        GameObject guar = GameObject.Find("Manageguardado");
        Destroy(muscia);
        Destroy(guar);
        Application.Quit();

    }

    public void opciones()
    {

        Time.timeScale = 1.0f; 
        menu2.SetActive(true);
        menu.SetActive(false);
          GameObject myEventSystem = GameObject.Find("EventSystem");
         myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(botonopcion);




    }

    /*
        IEnumerator espera()
        {
         StartCoroutine("espera");
            yield return new WaitForSeconds(3);
        }

        */
    public void video()
    {
        hoja.Activo();
        hoja.texto.text = "Tienes una resolucion del copom" + "\n<color=green><size=10>(Pulsa e para quitar mensaje)</size></color>";

    }


    public void volver2()
    {
        Time.timeScale = 1.0f;
        menu2.SetActive(false);
        menu.SetActive(true);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(botonopcion1);

    }
    public void activo()
    {
        
        hoja.Desactivo();

    }

    public void online()
    {
        hoja.Activo();
        hoja.texto.text = "Eso para el año que viene"+ "\n<color=green><size=10>(Pulsa e para quitar mensaje)</size></color>";
    }

    public void creditos()
    {

        hoja.Activo();
        hoja.texto.text = "Andres Avelino Gonzalez Villena\n @avesthyle"+ "\n<color=green><size=10>(Pulsa e para quitar mensaje)</size></color>";
    }
    public void Hojadesactivo()
    {

        hoja.Desactivo();

    }

    public void volver()
    {
        pantalla.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1.0f;
       
      
    }

 


}
