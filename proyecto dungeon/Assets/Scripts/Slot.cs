using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler
{
    public int mi;
    private InventarioManager inven;

    void Start()
    {
        
        inven = GameObject.Find("Inventariomanager").GetComponent<InventarioManager>();
    }

    
    //suelte por encima
    public void OnDrop(PointerEventData evento)
    {

        DatosItem sueltaItem = evento.pointerDrag.GetComponent<DatosItem>();
        if (sueltaItem != null)
        {
            if (inven.itemlist[mi].identificador == -1)
            {
                inven.itemlist[sueltaItem.slot] = new Item();
                inven.itemlist[mi] = sueltaItem.objeto;
                sueltaItem.slot = mi;

            }
            else if (sueltaItem.slot != mi)
            {
              
                  //  Debug.LogWarning("Este objeto " + this.name + " tiene " + transform.GetChildCount() + " hijos.");
                    Transform item = this.transform.GetChild(0);
                    item.GetComponent<DatosItem>().slot = sueltaItem.slot;
                    item.transform.SetParent(inven.slotlist[sueltaItem.slot].transform);
                    item.transform.position = inven.slotlist[sueltaItem.slot].transform.position;

                    sueltaItem.slot = mi;
                    sueltaItem.transform.SetParent(this.transform);
                    sueltaItem.transform.position = this.transform.position;

                    inven.itemlist[sueltaItem.slot] = item.GetComponent<DatosItem>().objeto;
                    inven.itemlist[mi] = sueltaItem.objeto;
                
            }

        }
    }
}
