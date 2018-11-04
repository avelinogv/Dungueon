using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class Personaje_Entrada : MonoBehaviour {
    public Personaje person;
    public Text Nombre;
    public Toggle hombre;
    public Toggle Mujer;
    public Dropdown RAZAS;
    public Slider Sledad;
    public Text edadtex;
    public Text textodentro;
    public Text Puntosrestantes;
    public Slider Slfuerza;
    public Slider Sldaño;
    public Slider Slvelocidad;
    public Slider Sldefensa;
    public float puntos;
    public bool cambios=false;
    public GameObject hoja;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
        hoja = GameObject.Find("error");
        hoja.SetActive(false);
        person =new Personaje(); 
        puntos = 20;
        Sldaño = GameObject.Find("sliderDaño").GetComponent<Slider>();
        Slfuerza = GameObject.Find("Sliderfuer").GetComponent<Slider>();
        Slvelocidad= GameObject.Find("Slidervelocidad").GetComponent<Slider>();
        Sldefensa = GameObject.Find("Sliderdefensa").GetComponent<Slider>();
        textodentro = GameObject.Find("Placeholdernom").GetComponent<Text>();
        Puntosrestantes = GameObject.Find("puntostex").GetComponent<Text>();
        edadtex =GameObject.Find("Edadtext").GetComponent<Text>();
        Sledad=GameObject.Find("SliderEdad").GetComponent<Slider>();
        Nombre = GameObject.Find("Nombrepersona").GetComponent<Text>();
        hombre = GameObject.Find("Tomacho").GetComponent<Toggle>();
        Mujer = GameObject.Find("Tohembra").GetComponent<Toggle>();
        RAZAS = GameObject.Find("Razas").GetComponent<Dropdown>();
        hombre.isOn = false;
        Mujer.isOn = false;
        

    }
	
	// Update is called once per frame
	void Update () {

        escritor();
    }


    public void escritor()
    {

        if (edadtex != null)
        {
            edadtex.text = Mathf.Round(Sledad.value).ToString();

            Sliderpunto();
        }
    }

     public void Sliderpunto()
    {
        float locafu= Slfuerza.value;
        float locade= Sldefensa.value;
        float locada= Sldaño.value;
        float locavel= Slvelocidad.value;
        float total = locafu + locade + locada + locavel;
        //Debug.Log("locafu" + locafu + "locade" + locade + "locada" + locada+"locavel"+locavel+"total"+total);
        Puntosrestantes.text =total.ToString()+"/"+puntos;
        if (total > puntos)
        {
            Slfuerza.value--;
            Sldefensa.value--;
            Sldaño.value--;
            Slvelocidad.value--;
        }


    }
        public void Guardar()
    {

        person.nombre = Nombre.text;
        person.edad = (int)Sledad.value;
        if (hombre.isOn) person.genero = true;
        else person.genero = false;
        person.daño = (int)Sldaño.value;
        person.fuerza = (int)Slfuerza.value;
        person.defensa = (int)Sldefensa.value;
        person.velocidad = (int)Slvelocidad.value;
        person.raza = (int)RAZAS.value;


        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveGame.avelino");
        bf.Serialize(file, person);
        file.Close();

        cambios = true;
    }

    public void Cargar()
    {



        if (File.Exists(Application.persistentDataPath + "/saveGame.avelino"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveGame.avelino", FileMode.Open);
           person = (Personaje)bf.Deserialize(file);
            file.Close();
        }


        textodentro.text = person.nombre;
       
        Debug.Log("NOMBRE ES "+textodentro.text);
        RAZAS.value = person.raza;
        Sledad.value=person.edad;
        Sldaño.value = (float)person.daño;
        Slfuerza.value = (float)person.fuerza;
        Sldefensa.value = (float)person.defensa;
        Slvelocidad.value = (float)person.velocidad;
        if (person.genero) hombre.isOn = true;
        else Mujer.isOn = true;

        cambios = true;

    }


  
  public void Siguiente()
    {

        if (cambios) Application.LoadLevel("inventario");
        else hoja.SetActive(true);

    }
    public void desactivohoja()
    {

        
      hoja.SetActive(false);

    }

    public void toohombre()
    {
        if (hombre.isOn) Mujer.isOn = false;
      
    }

    public void tomujer()
    {

        if (Mujer.isOn) hombre.isOn = false;
    }

    public void raza()
    {
       

    }
public void nombre()
    {
        Debug.Log("se llama:" + Nombre.text);

    }


}
