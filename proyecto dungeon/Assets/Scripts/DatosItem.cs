using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DatosItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerEnterHandler,IPointerExitHandler {

public Item  objeto;
    public int contador;
    public int slot;
    private Vector2 offset;
    private InventarioManager inven;
   
    public Papel papel;

    //funciones de las galerias using System;using UnityEngine.EventSystems; que permiten mover los item
    // en la cuadricula del pergamino ya que lleva el componente grid Layout group
    //en el prefab item que va este scripts se le incorpora el layaout element script para ignorar
    //el layout grid del pergamino y asi moverse libremente

    void Start()
    {
        inven = GameObject.Find("Inventariomanager").GetComponent<InventarioManager>();
      
        papel =  GameObject.Find("Inventario global").GetComponent<Papel>();
    }



    public void OnBeginDrag(PointerEventData evento)
    {
        
            offset = evento.position - new Vector2(this.transform.position.x,this.transform.position.y);
        
            //posicion local de tablon que contiene el grid layout
            this.transform.SetParent(this.transform.parent.parent);
            //asigna la posicion ala posicion del raton donde este
            this.transform.position = evento.position-offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
     
    }

    public void OnDrag(PointerEventData evento)
    {
        this.transform.position = evento.position-offset;
    }

    public void OnEndDrag(PointerEventData evento)
    {
        if (inven.slotlist[slot] != null)
        {
            //al finalizar el evento de arrastrar mueve el item asu posicion
            this.transform.SetParent(inven.slotlist[slot].transform);
            this.transform.position = inven.slotlist[slot].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
         }





    }

    public void OnPointerEnter(PointerEventData evento)
    {
        
        papel.Activado(objeto);
    }

    public void OnPointerExit(PointerEventData evento)
    {
        papel.Desactivado();
    }
}
