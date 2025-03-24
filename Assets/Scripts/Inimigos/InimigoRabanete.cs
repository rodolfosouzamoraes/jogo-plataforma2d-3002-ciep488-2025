using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoRabanete : MonoBehaviour
{
    public float velocidade;
    private SpriteRenderer corpoRabanete;
    private Animator animator;
    private bool estaParado; //Diz se o rabanete está parado
    private bool houveColisao;
    private string animacaoAtual; //Nome da animação que estava antes de tomar um dano
    private float tempoDeEspera = 3f;
    private float tempoAguardando; //Tempo para aguardar a voltar a correr

    // Start is called before the first frame update
    void Start()
    {
        corpoRabanete = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animacaoAtual = "Correndo";
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se está parado
        if(estaParado == true){
            //Verificar o tempo para poder virar o rabanete
            if(Time.time > tempoAguardando){
                //Viramos o rabanete
                VirarRabanete();
            }
            return;
        }
        //Movimentar o rabanete para a direção correta
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }

    void OnTriggerExit2D(Collider2D colisao)
    {
        //Verificar se o rabanete deixou de colidir com o chão
        if(colisao.gameObject.layer == 6){
            //Ativar a animação de parado
            animator.SetTrigger("Parado");

            //Salvar o nome da animação atual
            animacaoAtual = "Parado";

            //Definir o proximo tempo para liberar o rabanete para andar
            tempoAguardando = Time.time + tempoDeEspera;

            //Diz que o rabanete está parado
            estaParado = true;
        }
    }

    /// <summary>
    /// Método para poder virar o rabanete
    /// </summary>
    private void VirarRabanete(){
        //Inverter a velocidade para poder se mover no sentido contrário
        velocidade *= -1;

        //Inverter o corpo
        corpoRabanete.flipX = !corpoRabanete.flipX;

        //Diz que o rabanete não está mais parado
        estaParado = false;

        //Ativa a animação do corrida
        animator.SetTrigger("Correndo");

        //Salva a animação atual
        animacaoAtual = "Correndo";

        //Habilita novas colisoes
        houveColisao = false;
    }

    /// <summary>
    /// Efetua um dano ao rabanete
    /// </summary>
    private void DanoRabanete(){
        //Efetuar dano ao player
        FindFirstObjectByType<PlayerControlador>().DanoPlayer.EfetuarDano();

        //Ativar animação de dano
        animator.SetTrigger("Dano");

        //Diz que houve colisão
        houveColisao = true;
    }

    /// <summary>
    /// Método ativado após o fim da animação de dano
    /// </summary>
    public void AtivaAnimacaoPosDano(){
        //Ativa a animação anterior ao Dano
        animator.SetTrigger(animacaoAtual);

        //Permitir novas colisoes
        houveColisao = false;
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se o jogo acabou
        if(CanvasGameMng.Instance.fimDeJogo == true) return;

        if(colisao.gameObject.layer == 7 && houveColisao == false){
            //Efetuar dano ao rabenete
            DanoRabanete();
        }
    }
}
