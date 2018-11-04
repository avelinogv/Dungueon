using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class arrastra : MonoBehaviour, IDropHandler
{
    private InventarioManager inven;
    private InventarioEquipado inequipo;
    void Start()
    {
        inven = GameObject.Find("Inventariomanager").GetComponent<InventarioManager>();
        inequipo = GameObject.Find("Personaje").GetComponent<InventarioEquipado>();
    }




    public void OnDrop(PointerEventData eventData)
    {
        DatosItem basu = eventData.pointerDrag.GetComponent<DatosItem>();

        if (basu != null)
        {



            if (inequipo.Usado(basu))
            {
               inequipo.Itempantalla(basu.objeto.identificador);
                inven.BorraItem(basu);
            }
        }

    }

}
