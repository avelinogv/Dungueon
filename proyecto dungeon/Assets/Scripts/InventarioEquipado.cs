using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventarioEquipado  : MonoBehaviour
{

    public GameObject Panelslot;
    public GameObject Panelitem;
    public Text Informacio;
    public GameObject botasfuego;
    public int cuentodaño;
    public int cuentofuerza;
    public int cuentovida;
    public int cuentodefensa;
    public int cuentovelocidad;

    GameObject posicionpanel;
    GameObject posicionslot;
    int numceldas;
    public List<Item> itemlist = new List<Item>();
    public List<GameObject> slotlist = new List<GameObject>();
    public Personaje persona;
    public int cuent;

    public Base_datos_items datos;
    private InventarioManager inven;
    public Personaje_Entrada ScripEntrada;
    public Text texnombre;
    GameObject cascoper;
    GameObject armorchest;
    GameObject armorchest1;
    GameObject armorchest2;
    GameObject armorchest3;
    GameObject armorchest4;
    GameObject armorchest5;
    GameObject armorchest6;
    GameObject guante;
    GameObject guante1;
    GameObject guante2;
    GameObject guante3;
    GameObject botes;
    GameObject botes1;
    GameObject botes2;
    GameObject botes3;
    GameObject botes4;
    GameObject botes5;
    GameObject botes6;
    GameObject botes7;
    GameObject espadaca;
    public Resume resu;
    // Use this for initialization

    void Awake()
    {
    
    }


    void Start()
    {
        botasfuego = GameObject.Find("fogata");
        botasfuego.SetActive(false);
        texnombre = GameObject.Find("nombreperso").GetComponent<Text>();
        ScripEntrada=GameObject.Find("Managerpersonaje").GetComponent<Personaje_Entrada>();

        persona = new Personaje();
       
    
            texnombre.text = ScripEntrada.person.nombre;
            persona.daño = ScripEntrada.person.daño;
            persona.fuerza = ScripEntrada.person.fuerza;
            persona.defensa = ScripEntrada.person.defensa;
            persona.velocidad = ScripEntrada.person.velocidad;
       
        Informacio = GameObject.Find("textoInformativo").GetComponent<Text>();

     
        numceldas = 6;
        datos = new Base_datos_items();
        generador_casillas();
        inven = GameObject.Find("Inventariomanager").GetComponent<InventarioManager>();

        IniciandoGameObject();
        casco(false);
        armoer(false);
        guanteper(false);
        bote(false);
        espadaca.SetActive(false);
        resu = GameObject.Find("Manageguardado").GetComponent<Resume>();
        for (int i = 0; i < resu.listaequipo.Count; i++)
        {
          Itempantalla(resu.listaequipo[i].identificador);
        }

        resu.listaequipo.Clear();
    }



    // Update is called once per frame
    void Update()
    {

        if (Informacio != null)
        {

            persona.contador = cuent;
            if (persona.cuenta())
            {
                persona.SubirNivel(persona.nivel);
                cuent = 0;
            }

            escritor();
            recuento();

        }
        }

    public void escritor()
    {

     
            Informacio.text = "Nivel:" + persona.nivel + "\nExperiencia:\n" + Math.Round(persona.experiencia) + "/" + persona.contador + "\nDaño:" + persona.daño +
       "\nVida:" + persona.vida +
       "\nFuerza:" + persona.fuerza + "\nDefensa:" + persona.defensa + "\nVelocidad:" + persona.velocidad;

        

    }



    public void recuento()
    {
        int redefensa = 0;
        int redaño = 0;
        int refuerza = 0;
        int revelocidad = 0;
        int revida = 0;

        Text amplidaño = GameObject.Find("Amplidaño").GetComponent<Text>();
        Text Amplivida = GameObject.Find("Amplivida").GetComponent<Text>();
        Text Amplifuerza = GameObject.Find("Amplifuerza").GetComponent<Text>();
        Text Amplidefensa = GameObject.Find("Amplidefensa").GetComponent<Text>();
        Text Amplivelocidad = GameObject.Find("Amplivelocidad").GetComponent<Text>();

        if (amplidaño != null) { 
        for (int i = 0; i < itemlist.Count; i++)
        {

            redefensa += itemlist[i].defensa;
            redaño += itemlist[i].daño;
            refuerza += itemlist[i].fuerza;
            revelocidad += itemlist[i].velocidad;
            revida += itemlist[i].vida;
        }

        if (redefensa > 0)
        {
            cuentodefensa = redefensa;
            Amplidefensa.text = "+" + cuentodefensa;
        }
        else
        {
            cuentodefensa = 0;
            Amplidefensa.text = "  ";
        }

        if (redaño > 0)
        {
            cuentodaño = redaño;
            amplidaño.text = "+" + cuentodaño;
        }
        else
        {
            cuentodaño = 0;
            amplidaño.text = "  ";
        }

        if (refuerza > 0)
        {
            cuentofuerza = refuerza;
            Amplifuerza.text = "+" + cuentofuerza;
        }
        else
        {
            cuentofuerza = 0;
            Amplifuerza.text = "  ";
        }
        if (revelocidad > 0)
        {
            cuentovelocidad = revelocidad;
            Amplivelocidad.text = "+" + cuentovelocidad;
        }
        else
        {
            cuentovelocidad = 0;
            Amplivelocidad.text = "  ";
        }
        if (revida > 0)
        {
            cuentovida = revida;
            Amplivida.text = "+" + cuentovida;
        }
        else
        {
            cuentovida = 0;
            Amplivida.text = "   ";
        }

    }
    }

    public void generador_casillas()
    {
        

            posicionpanel = GameObject.Find("CuadroPadre");
            if (posicionpanel != null)
            {
                posicionslot = posicionpanel.transform.FindChild("Marco").gameObject;





                for (int i = 0; i < numceldas; i++)
                {

                    itemlist.Add(new Item());
                    slotlist.Add(Instantiate(Panelslot));

                    //Guarda en la lista slotlist la posicion local de cada slot
                    slotlist[i].transform.SetParent(posicionslot.transform);
                    slotlist[i].name = "Slot" + i;
                    
                }
            }
        
        }





    public void BorraItem(pulsacion slot)
    {
        if (slot != null)
        {
          Debug.Log("borro el ultimo");


         Destroy(slot.gameObject);
             switch (slot.objeto.identificador)
              {
            case 0:
                espadaca.SetActive(false);
                break;
            case 1:

                break;
            case 2:
                casco(false);
                break;
            case 3:
                armoer(false);
                break;
            case 4:
                guanteper(false);
                break;
            case 5:
                bote(false);
                    botasfuego.SetActive(false);
                break;

                }
        itemlist[slot.slot] = new Item();
      }
    }




    //AddItem
    public void Itempantalla(int id)
    {
    
        Item añadido = datos.Consigue(id);


        for (int i = 0; i < itemlist.Count; i++)
        {
            //comprueba q el inventario visual tenga slot libres , y si lo tiene inserta
            //lo comprueba ya que en start se rellena el inventario visual de item vacios 
            //con identificador -1
            if (itemlist[i].identificador == -1)
            {

                //inventario interno
                itemlist[i] = añadido;
                GameObject posicion_obj = Instantiate(Panelitem);
                posicion_obj.GetComponent<pulsacion>().objeto = añadido;

                posicion_obj.GetComponent<pulsacion>().slot = i;
                posicion_obj.transform.SetParent(slotlist[i].transform);
                posicion_obj.transform.transform.localPosition = Vector2.zero;

                posicion_obj.GetComponent<Image>().sprite = añadido.Imagen;
                posicion_obj.name = añadido.Nombre;



                break;
            }



        }
        switch (añadido.identificador)
        {
            case 0:
                espadaca.SetActive(true);


                break;
            case 1:

                break;
            case 2:
                casco(true);
                break;
            case 3:
                armoer(true);
                break;
            case 4:
                guanteper(true);
                break;
            case 5:
                bote(true);
                botasfuego.SetActive(true);
                break;

        }
    
    }


    public bool Usado(DatosItem obje)
    {
     
        for (int i = 0; i < itemlist.Count; i++)
        {
            if (itemlist[i].identificador == obje.objeto.identificador)
            {
                return false;

            }
        }
        return true;

    
   }
  


    public void casco(bool act)
    {
       
        if(act) cascoper.SetActive(true);
      else cascoper.SetActive(false);


    }

    public void armoer(bool act)
    {
        
        
            armorchest.SetActive(act);
            armorchest1.SetActive(act);
            armorchest2.SetActive(act);
            armorchest3.SetActive(act);
            armorchest4.SetActive(act);
            armorchest5.SetActive(act);
            armorchest6.SetActive(act);
        
      
    }

    public void guanteper(bool act)
    {

        guante.SetActive(act);
        guante1.SetActive(act);
        guante2.SetActive(act);
        guante3.SetActive(act);


    }

    public void bote(bool act)
    {

        botes.SetActive(act);
        botes1.SetActive(act);
        botes2.SetActive(act);
        botes3.SetActive(act);
        botes4.SetActive(act);
        botes5.SetActive(act);
        botes6.SetActive(act);
        botes7.SetActive(act);
    }

    public void IniciandoGameObject()
    {
        cascoper = GameObject.Find("Helm");
        armorchest = GameObject.Find("chest");
        armorchest1 = GameObject.Find("Hip");
        armorchest2 = GameObject.Find("Object12");
        armorchest3 = GameObject.Find("Object09");
        armorchest4 = GameObject.Find("Object14");
        armorchest5 = GameObject.Find("Object02");
        armorchest6 = GameObject.Find("Object08");
        guante = GameObject.Find("ForeArm");
        guante1 = GameObject.Find("ForeArm01");
        guante2 = GameObject.Find("Object15");
        guante3 = GameObject.Find("Object11");
        botes = GameObject.Find("Object07");
        botes1 = GameObject.Find("Object17");
        botes2 = GameObject.Find("Object01");
        botes3 = GameObject.Find("Object16");
        botes4 = GameObject.Find("Shoe");
        botes5 = GameObject.Find("Shoe01");
        botes6 = GameObject.Find("Thigh");
        botes7 = GameObject.Find("Thigh01");
        espadaca = GameObject.Find("Object03");
    }
}
