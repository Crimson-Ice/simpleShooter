using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClicker : MonoBehaviour
{
    public Animator animator;
    public bool appuyer = false;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        Ennemie_Health Ennemie = collider.gameObject.GetComponent<Ennemie_Health>();
        Tir_Stat Tir = collider.gameObject.GetComponent<Tir_Stat>();
     
        if (Ennemie == null) //verifie si l'object n'est pas un ennemie(erreur sinon)
        {
            if (Tir == null) //verifie si l'object n'est pas un tir(erreur sinon)
            {
                appuyer = true;
                animator.SetBool("appuyer", appuyer);
            }
        
        }
    }
}