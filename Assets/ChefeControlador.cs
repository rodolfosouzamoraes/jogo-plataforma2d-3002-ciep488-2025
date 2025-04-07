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

    /// <summary>
    /// Havilita o item final após o fim da animação de morte do chefe
    /// </summary>
    public void AtivarItemFinal()
    {
        //Habilitar o item final
        itemFinal.SetActive(true);

        //Destruir o chefe
        Destroy(gameObject);
    }

    /// <summary>
    /// Habilita a movimentação quando o player entra na zona do chefe
    /// </summary>
    public void HabilitarMovimentacao()
    {
        //Habilitar movimentação
        estaMovendo = true;

        //Ativar animação de corrida
        animator.SetBool("Correndo", true);
    }

    public void DecrementarVidaChefe() { 
        //Decrementar a vida do chefe
        vidaChefe--;

        //Verificar se a vida do chefe acabou
        if (vidaChefe == 0)
        {
            //Desabilitar a movimentacao
            estaMovendo = false;

            //Destruir os colisores
            foreach (var colisor in colisores)
            {
                Destroy(colisor);
            }

            //Ativa a animação de morte do chefe
            animator.SetTrigger("Morte");
        }
        else
        {
            //Ativar animação de dano
            animator.SetTrigger("Dano");
        }   
    }
}
