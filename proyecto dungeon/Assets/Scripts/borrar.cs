using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;


public class borrar : MonoBehaviour, IDropHandler , IPointerEnterHandler,IPointerExitHandler
{

    public Animator animacion;
    public Item objeto;
    public Tienda tienda;
    public Resume Scripresume;
    private InventarioManager inven;

    void Start()
    {
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();
        inven = GameObject.Find("Inventariomanager").GetComponent<InventarioManager>();
        tienda = GameObject.Find("Tienda").GetComponent<Tienda>();
    }




public void salgo()
{
    Debug.Log("saliendo");
    animacion.SetBool("Activado", false);
}

    public void OnDrop(PointerEventData eventData)
    {
       
        
        DatosItem basu = eventData.pointerDrag.GetComponent<DatosItem>();


        Scripresume.dinero += basu.objeto.precio;
        inven.BorraItem(basu);
        //inven.actualizar = true;
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("dentro");
        animacion.SetBool("Activado", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("saliendo");
        animacion.SetBool("Activado", false);
    }

    public void casco(){
       inven.Itempantalla(2);

    }

    public void espada()
    {
        inven.Itempantalla(0);

    }

    public void hacha()
    {
        inven.Itempantalla(3);

    }


    public void guantes()
    {
        inven.Itempantalla(4);

    }

    public void botes()
    {
        inven.Itempantalla(5);

    }

}
