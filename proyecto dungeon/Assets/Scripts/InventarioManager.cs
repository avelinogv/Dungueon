using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventarioManager : MonoBehaviour {

    public GameObject Panelslot;
    public GameObject Panelitem;
  

    GameObject posicionpanel;
    GameObject posicionslot;
    int numceldas;
    public List<Item> itemlist = new List<Item>();
    public List<GameObject> slotlist = new List<GameObject>();
    public int numerodeobjetos=0;
    public Base_datos_items datos;
    public bool carga = false;
    public Resume resu;

    // Use this for initialization

    void Awake()
    {
       
    }

    void Start() {

        numceldas = 16;
        datos = new Base_datos_items();
       
            generador_casillas();
        resu = GameObject.Find("Manageguardado").GetComponent<Resume>();
    for(int i = 0; i < resu.listainventario.Count; i++)
        {
            Itempantalla(resu.listainventario[i].identificador);
        }

        resu.listainventario.Clear();
    }


    // Update is called once per frame
    void Update()
    {


    }




    public void generador_casillas()
    {

        
        posicionpanel = GameObject.Find("tablon");
        posicionslot = posicionpanel.transform.FindChild("pergamino").gameObject;


        for (int i = 0; i < numceldas; i++)
        { 
        
                //if(itemlist[i].Nombre!=null)   Debug.Log(itemlist[i].Nombre);
                //Debug.Log(itemlist[i].Nombre);
                //crea las casillas del pergamino
                itemlist.Add(new Item());
                slotlist.Add(Instantiate(Panelslot));
                slotlist[i].GetComponent<Slot>().mi = i;
                //Guarda en la lista slotlist la posicion local de cada slot
                slotlist[i].transform.SetParent(posicionslot.transform);
                slotlist[i].name = "Slot" + i;
        
        }



    }





    public void BorraItem(DatosItem slot)
    {
        


            slot.contador--;
            Debug.Log("jooooooooooooooo  entra2: " + slot.contador);


            if (slot.contador < 0)
            {
                Debug.Log("borro el ultimo");

               // Transform t = slotlist[pos].transform.GetChild(0);
                Destroy(slot.gameObject);

                itemlist[slot.slot] = new Item();
            }
            else
            {

                if (slot.contador == 0)
                {
                    slot.transform.GetComponentInChildren<Text>().text = "";
                    Debug.Log("borro el numero");
                }
                else
                {
                    slot.transform.GetComponentInChildren<Text>().text = slot.contador.ToString();
                    Debug.Log("actualizo el numero");

                }
            }


      
    }
    
  public  int comprobandoItem(Item obj)
    {
        for (int i = 0; i < itemlist.Count; i++)
        {
            if (itemlist[i].identificador == obj.identificador)
                return i;
        }
        return -1;
    }




    //AddItem
  public  void Itempantalla(int id)
    {

        Item añadido = datos.Consigue(id);
        if (añadido != null)
        {
            if (usado(añadido))
            {
                numerodeobjetos++;
                for (int i = 0; i < itemlist.Count; i++)
                {
                    if (itemlist[i].identificador == id)
                    {
                        DatosItem Slot = slotlist[i].transform.GetChild(0).GetComponent<DatosItem>();
                        Slot.contador++;
                        Slot.transform.GetChild(0).GetComponent<Text>().text = Slot.contador.ToString();
                        break;
                    }


                }

            }
            else
            {

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
                        posicion_obj.GetComponent<DatosItem>().objeto = añadido;

                        posicion_obj.GetComponent<DatosItem>().slot = i;
                        posicion_obj.transform.SetParent(slotlist[i].transform);
                        posicion_obj.transform.transform.localPosition = Vector2.zero;

                        posicion_obj.GetComponent<Image>().sprite = añadido.Imagen;
                        posicion_obj.name = añadido.Nombre;


                        break;
                    }



                }
            }
        }
     }


    bool usado(Item item)
    {
        for(int i = 0; i <itemlist.Count; i++)
        {
            if (itemlist[i].identificador == item.identificador) return true;
        }
        return false;
    }


}
