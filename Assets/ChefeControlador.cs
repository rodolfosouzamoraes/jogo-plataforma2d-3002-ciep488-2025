using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChefeControlador : MonoBehaviour
{
    private Animator animator;
    private List<BoxCollider2D> colisores; //Obter todos os colliders do chefe
    private int vidaChefe = 4;
    private bool estaMovendo; //Diz se o chefe pode mover ou não
    public GameObject itemFinal;//Libera o item final após a morte do chefe

    public bool EstaMovendo
    {
        get { return estaMovendo; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ocultar o item final
        itemFinal.SetActive(false);

        //Referenciar o animator
        animator = GetComponent<Animator>();

        //Referenciar os colisores internos
        colisores = GetComponentsInChildren<BoxCollider2D>().ToList();

        //Adicionar o colisor do objeto 
        colisores.Add(GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
