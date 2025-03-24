using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPlanta : MonoBehaviour
{
    public GameObject projetil;
    public float tempoDeTiro;
    private SpriteRenderer corpoPlanta;
    private Animator animator;    
    private float tempoDeEspera;
    private bool estaMorto;
    
    // Start is called before the first frame update
    void Start()
    {
        corpoPlanta = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        AtualizaTempoDeEspera();
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se pode atirar
        if(Time.time > tempoDeEspera){
            //Atualizar o tempo
            AtualizaTempoDeEspera();

            //Ativar a animação de ataque
            animator.SetTrigger("Ataque");
        }
    }

    private void AtualizaTempoDeEspera(){
        tempoDeEspera = Time.time + tempoDeTiro;
    }

    /// <summary>
    /// Método para instanciar o projetil através da animação de ataque da planta
    /// </summary>
    public void AtirarProjetil(){
        //Instanciar o projetil
        GameObject novoProjetil = Instantiate(projetil);

        //Verificar para onde a plata está olhando para poder lançar o projetil para aquela direção
        if(corpoPlanta.flipX == true){
            //Posiciona o projetil
            PosicionarProjetil(novoProjetil, 0.7f, Vector3.right);
        }
        else{
            //Posiciona o projetil
            PosicionarProjetil(novoProjetil, -0.5f, Vector3.left);
        }
    }

    /// <summary>
    /// Método para posicionar o projetil em frente a planta
    /// </summary>
    private void PosicionarProjetil(GameObject novoProjetil, float diferencaX, Vector3 direcao){
        //Posicionar o projetil no lado direito da planta
            novoProjetil.transform.position = new Vector3(
                transform.position.x + diferencaX, 
                transform.position.y +0.14f,
                0);
            
        //Definir a direção de movimentação do projetil
        novoProjetil.GetComponent<ProjetilPlanta>().MudarDirecao(direcao);
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player" && estaMorto == false){
            //Diz que a planta morreu
            estaMorto = true;

            //Efetuo o dano no player
            colisao.GetComponent<PlayerControlador>().DanoPlayer.EfetuarDano();

            //Ativo a animação de morte
            animator.SetTrigger("Morte");
            animator.SetBool("EstaMorto", true);
        }
    }

    private void DestruirPlanta(){
        Destroy(gameObject);
    }
}
