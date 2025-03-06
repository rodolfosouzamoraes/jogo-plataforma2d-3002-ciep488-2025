using UnityEngine;

public class InimigoPassaroAzul : MonoBehaviour
{
    public GameObject passaroAzul; //Variável com o gameobject pai
    public float velocidade; //Velocidade de movimentação do passaro
    public Vector3 posicaoFinal; //Posição final para onde o passáro deve ir
    private SpriteRenderer corpoPassaroAzul; //Variável para manipular o sprite do passaro azul
    private Vector3 posicaoInicial; //Posição ao iniciar o jogo
    private Vector3 posicaoAlvo; //Posição para onde o passaro deve ir
    private bool estaMorto; //Variável que diz se o passaro morreu
    private Animator animator; //Controla a animação do passaro

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Configura a posição inicial do passaro
        posicaoInicial = passaroAzul.transform.position;

        //Diz para onde o passaro deve ir
        posicaoAlvo = posicaoFinal;

        //Configura o animator
        animator = GetComponent<Animator>();

        //Configura o SpriteRenderer
        corpoPassaroAzul = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Chamar a movimentação do passaro
        MovimentarPassaro();

        //Calcular a distancia entre o passaro e o alvo
        CalcularDistanciaAlvo();
    }

    /// <summary>
    /// Método para movimentar o passaro
    /// </summary>
    private void MovimentarPassaro()
    {
        //Movimentar o passaro para uma posicao alvo
        passaroAzul.transform.position = Vector3.MoveTowards(
            passaroAzul.transform.position,
            posicaoAlvo,
            velocidade * Time.deltaTime
        );
    }

    /// <summary>
    /// Calcular a distancia entre o passaro e o alvo para onde ele deve ir.
    /// Inverter o corpo quando chegar na posição
    /// </summary>
    private void CalcularDistanciaAlvo()
    {
        //Verificar a distancia do passaro em relação ao alvo
        if(Vector3.Distance(passaroAzul.transform.position, posicaoAlvo) < 0.001f)
        {
            //Verificar o flip do sprite para saber a nova direção do passaro
            if(corpoPassaroAzul.flipX == false)
            {
                //Alterar a posição alvo para a posição inicial
                posicaoAlvo = posicaoInicial;
            }
            else
            {
                //Alterar a posição do alvo para a posição final
                posicaoAlvo = posicaoFinal;
            }

            //Inverter o flip do sprite para olhar em direção onde deve ir
            corpoPassaroAzul.flipX = !corpoPassaroAzul.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se o player colidiu com a cabeca do passaro
        if(colisao.gameObject.tag == "Player" && estaMorto == false)
        {
            //Dizer que morreu o passaro
            estaMorto = true;

            //Arremessar o player
            colisao.GetComponent<PlayerControlador>().MovimentarPlayer.ArremessarPlayer();

            //Ativar a animação de morte
            animator.SetTrigger("Morte");
        }
    }

    public void DestruirPassaro()
    {
        Destroy(passaroAzul);
    }
}
