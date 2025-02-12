using System.Collections;
using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    public FlipCorpoPlayer flipCorpo;
    public LimitePlayer limiteDireita;
    public LimitePlayer limiteEsquerda;
    public LimitePlayer limiteCabeca;
    public LimitePlayer limitePe;
    public Rigidbody2D rigidbody2d;

    public float velocidade; //Velocidade de movimenta��o

    public float forcaPuloY; //For�a do pulo no eixo Y
    private bool estaPulando; //Diz se o player est� em modo de pulo
    private bool habilitaPulo; //Permite o personagem de pular ou n�o
    private bool puloDuplo; //Perminte o personagem efetuar um pulo duplo
    private Coroutine coroutinePulo; //Contador de tempo para poder limitar o pulo do player 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
        Pular();
    }

    /// <summary>
    /// L�gica de movimenta��o do personagem
    /// </summary>
    private void Movimentar()
    {
        //Pegar a entrada do usu�rio para fazer a movimenta��o
        float eixoX = Input.GetAxis("Horizontal");

        //Verificar se chegou nos limites da esquerda e direita
        if (eixoX > 0 && limiteDireita.estaNoLimite == true) { eixoX = 0; }
        else if (eixoX < 0 && limiteEsquerda.estaNoLimite == true) { eixoX = 0; }


        //Olhar para o lado onde o jogador est� movendo
        if (eixoX > 0) {
            flipCorpo.OlharDireita();
        }
        else if (eixoX < 0)
        {
            flipCorpo.OlharEsquerda();
        }

        //Dire��o da movimenta��o
        Vector3 direcaoMovimento = new Vector3(eixoX,0,0);

        //Movimentar o personagem no sentido da dire��o
        transform.position += direcaoMovimento * velocidade * Time.deltaTime;
    }

    private void Pular()
    {
        //Obter a entrada do usu�rio para poder efetuar o pulo
        if (Input.GetButtonDown("Jump"))
        {
            //Verificar se o pulo est� habilitado
            if (limitePe.estaNoLimite == true && estaPulando == false)
            {
                //Habilitar o est� pulando
                estaPulando = true;

                //Habilitar o pulo duplo
                puloDuplo = true;

                //Ativar o tempo do pulo
                AtivarTempoPulo();
            }
        }

        //Verificar se o player pode subir
        if (estaPulando == true)
        {
            //Zerar as for�as do rigibody
            rigidbody2d.linearVelocity = Vector3.zero;

            //Alterar as propriedades do rigidbody para fazer o player subir
            rigidbody2d.gravityScale = 0;

            //Direcionar o pulo do player
            Vector3 direcaoPulo = new Vector3(0,forcaPuloY,0);

            //Mover o player para cima, simbolizando o pulo
            transform.position += direcaoPulo * velocidade * Time.deltaTime;
        }
        else
        {
            rigidbody2d.gravityScale = 4;
        }
    }

    private void AtivarTempoPulo()
    {
        //Verificar se j� existe um tempo a ser contado
        if(coroutinePulo != null)
        {
            StopCoroutine(coroutinePulo);
        }

        //Iniciar um novo contador de tempo
        StartCoroutine(TempoPulo());
    }

    private IEnumerator TempoPulo()
    {
        //Permite 0.3 segundo o player subindo
        yield return new WaitForSeconds(0.3f);

        //Desabilita a variavel que permite o player subir
        estaPulando = false;
    }
}
