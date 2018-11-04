using UnityEngine;
using System.Collections;
using System;

[System.Serializable]

public class Personaje {
    public string nombre;
    public bool genero;
    public int edad;
    private int _nivel;
    private float _experiencia;
    private int _vida;
    private int _daño;
    private int _fuerza;
    private int _defensa;
    private int _velocidad;
    private int _contador;

    public int raza;
    
    public Personaje()
    {
        nivel = 1;
        vida = 200;
        experiencia = 375;
        contador = 0;
    
    }


    public int daño
    {
        get
        {

            return _daño;
        }
        set
        {
            _daño = value;
        }
    }

    public int nivel
    {
        get
        {

            return _nivel;
        }
        set
        {
            _nivel = value;
        }
    }
    public int contador
    {
        get
        {
            return _contador;
        }
        set
        {
            _contador = value;
        }
    }

    public float experiencia
    {
        get
        {

            return _experiencia;
        }
        set
        {
            _experiencia = value;
        }

    }


    public int vida
    {
        get
        {

            return _vida;
        }
        set
        {
            _vida = value;
        }
    }

    public int fuerza
    {
        get
        {

            return _fuerza;
        }
        set
        {
            _fuerza = value;
        }
    }

    public int defensa
    {
        get
        {

            return _defensa;

        }
        set
        {
            _defensa = value;
        }
    }

    public int velocidad
    {
        get
        {

            return _velocidad;
        }
        set
        {
            _velocidad = value;
        }
    }


    public bool  cuenta()
    {
if (contador >= experiencia)
        {

            contador = 0;
             nivel++;
            return true;
        }
        return false;

    }


    public void SubirNivel(int po)
    {
     
    float exp = 375;
    int dan = 5;
    int fue = 5;
    int def = 5;
    int vel = 5;
    int vid = 200;

    
            for (int i = 1; i<po ;i++ )
            {
                nivel = po;
                exp= exp + (exp*0.2f);
            vid += 100;
            fue++;
            def++;
            vel++;
            dan++;
        }
        daño = dan;
        vida = vid;
        defensa = def;
        velocidad = vel;
        fuerza = fue;
        experiencia = exp;

    }

    public void SubirNivel(int po, int _daño,int _fue,int _def,int _vel, int _vid)
    {

        float exp = 375;
        int dan = 5;
        int fue = 5;
        int def = 5;
        int vel = 5;
        int vid = 200;


        for (int i = 1; i < po; i++)
        {
            nivel = po;
            exp = exp + (exp * 0.2f);
            vid += 100;
            fue++;
            def++;
            vel++;
            dan++;
        }
        vida = vid+_vid;
        daño = dan+_daño;
        defensa = def+_def;
        velocidad = vel+_vel;
        fuerza = fue+_fue;
        experiencia = exp;

    }




}
