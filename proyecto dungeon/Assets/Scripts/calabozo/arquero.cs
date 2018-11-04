using UnityEngine;
using System.Collections;
using System;

public class arquero : MonoBehaviour {
    public Animation animo;
    public AnimationClip[] animaciones;
    int i = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      //  animo.Play("EyeBlink");
       //  animo.Play("BowGetArrowFromBack");
        animo.Play("BowCombatReady");
        // gameObject.animation.Play(GetComponent(animaciones).animList[0]);
        //animo.Play(GetComponent(AnimationClip[]).animaciones[0]);



    
    }


    void muevete() //you could call this by adding an animation event at the end of all of your animations
    {
        i++;
        if (i== animaciones.Length) return; //avoid out of scope exception
        

        animo.clip = animaciones[i];
        animo.Play();
    }





       string ClipIndexToName(int index)
       {
           AnimationClip clip = GetClipByIndex(index);
           if (clip == null)
               return null;
           return clip.name;
       }

       private AnimationClip GetClipByIndex(int index)
       {

           foreach (AnimationState animationState in animo)
           {
               if (i == index)
                   return animationState.clip;
               i++;
           }
           return null;
       }

}
