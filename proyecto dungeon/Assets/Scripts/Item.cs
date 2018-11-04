using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]

public  class Item {

    public string Nombre;
    public string Descripcion;
    public int precio;
    public int identificador;
    public bool usado;
    public int daño;
    public int fuerza;
    public int vida;
    public int defensa;
    public int velocidad;

    [System.NonSerialized]
    public Sprite Imagen;

    public Item()
    {
        Nombre = "item";
        Descripcion = "Sin descripcion";
        precio = 0;
        identificador = -1;
        
    }







public Item(string _nombre, string _descripcion, int _precio, int _daño, int _fuerza,int _vida,int _velocidad, int _defensa,int _ident)

{
    Nombre = _nombre;
    Descripcion = _descripcion;
    precio = _precio;
    daño = _daño;
    fuerza = _fuerza;
        vida = _vida;
        velocidad = _velocidad;
        defensa = _defensa;
    identificador = _ident;
}

}




