using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class persocompleto : MonoBehaviour {
    public Resume Scripresume;
    public Personaje_Entrada Scrippersonaje;
    public FirstPersonController controller;
    public new Vector3 camara;
   

 public int velocidad;
    public int daño;
    public int defensa;
    public int fuerza;
    public float vidacompleta;
    public float contadorvida;
    public Text barravida;
    public Transform primera;
    public GameObject Intro;
 
    // Use this for initialization
    void Start () {
        Intro = GameObject.Find("Introducion");
        controller = GameObject.FindObjectOfType<FirstPersonController>();
        barravida = GameObject.Find("textovida").GetComponent<Text>();
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();
        Scrippersonaje = GameObject.Find("Managerpersonaje").GetComponent<Personaje_Entrada>();
        fuerza = Scripresume.fuerza + Scrippersonaje.person.fuerza;
        defensa = Scripresume.defensa + Scrippersonaje.person.defensa;
        velocidad = Scripresume.velocidad + Scrippersonaje.person.velocidad;
        daño = Scripresume.daño + Scrippersonaje.person.daño;

        vidacompleta = Scripresume.vida + Scrippersonaje.person.vida;
        if (Scripresume.recivodaño == false) contadorvida = vidacompleta;
        else contadorvida = Scripresume.contadorvida;
        

        if (Scripresume.posi.x!= 0 && Scripresume.posi.y != 0)
        {
            Debug.Log("cargo la posicion del personage con rotacion :"+ Scripresume.rotacion.y);
            GameObject.Find("Primerapersona").transform.eulerAngles = new Vector3(0, Scripresume.rotacion.y,0) ;
            GameObject.Find("Primerapersona").transform.position = new Vector3(Scripresume.posi.x, Scripresume.posi.y, Scripresume.posi.z);
        
        }

       if(Scripresume.intro) Intro.SetActive(false);



    }
	
	// Update is called once per frame
	void Update () {
        controller.mi_velocidad= velocidad;

        barravida.text = vidacompleta+ " / " +Mathf.Round(contadorvida);
        //Debug.Log(primera.position.x+ primera.position.y+ primera.position.z);
        if (Input.GetKey(KeyCode.I))
        {

            Scripresume.rotacion= new Vector3(primera.rotation.eulerAngles.x, primera.rotation.eulerAngles.y, primera.rotation.eulerAngles.z);
       
            Scripresume.posi = new Vector3(primera.position.x, primera.position.y, primera.position.z);
            Scripresume.contadorvida = contadorvida;
            Scripresume.cambioescena = true;
            Application.LoadLevel("inventario");
        }
     
	}


public void cerrarintro()
    {
        Intro.SetActive(false);
        Scripresume.intro = true;

    }
}
