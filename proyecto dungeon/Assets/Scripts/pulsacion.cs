using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class pulsacion : MonoBehaviour , IPointerClickHandler
{
    public Item objeto;
    public int slot;

    private InventarioManager inven;
    private InventarioEquipado invenEqui;

    void Start()
    {
        inven = GameObject.Find("Inventariomanager").GetComponent<InventarioManager>();
        invenEqui= GameObject.Find("Personaje").GetComponent<InventarioEquipado>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
      
        Debug.Log("He pulsado " +objeto.Descripcion);
        invenEqui.BorraItem(this);
        inven.Itempantalla(objeto.identificador);


    }

    // Use this for initialization
   
}
