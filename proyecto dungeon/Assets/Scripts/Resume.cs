using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Resume : MonoBehaviour {
    public bool cacomida = false;
    public bool cadinero = false;
   // public GameObject Inventario;
    public GameObject equipo;
    public int dinero;

    private InventarioManager scripInven;
    private InventarioEquipado scripEquipo;
    private Tienda ScripTienda;
    public List<Item> listainventario = new List<Item>();
    public List<Item> listaequipo = new List<Item>();
    public int fuerza;
    public int defensa;
    public int velocidad;
    public int daño;
    public int vida;
    public bool recivodaño = false;
    public bool recibodinero = false;
    public float contadorvida;
    public bool cambioescena = false;
    public bool primerapuerta = false;
    public bool segundo_objet = false;
    public bool intro = false;
   
    public new Vector3 posi;
    public new Vector3 rotacion;
  

    void Awake()
    {

       
      
       
        DontDestroyOnLoad(gameObject);
    }


    void Start () {

        scripEquipo = GameObject.Find("Personaje").GetComponent<InventarioEquipado>();

        }
	
	// Update is called once per frame
	void Update () {
	
	}
}
