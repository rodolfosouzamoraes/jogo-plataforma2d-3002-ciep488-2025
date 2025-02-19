using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGameMng : MonoBehaviour
{
    //Criar uma variável para instanciar o objeto
    public static CanvasGameMng Instance;

    private void Awake()
    {
        //Criar a instancia estática
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        //Destroi o gameobject caso já exista uma instancia da classe
        Destroy(gameObject);
    }

    public Image imgVida;//Imagem da vida
    public Sprite[] sptsVida;//Os sprites que vão aparecer na img da vida
    private int totalVidas;//Quantidade de vidas do player

    public bool fimDeJogo;//Diz se o jogo acabou

    private DanoPlayer danoPlayer;//Códigos para desabilitar o jogador

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Adicionar o total de vidas que o player tem ao iniciar o jogo
        totalVidas = sptsVida.Length - 1;

        //Pegar a referencia do dano player na cena
        danoPlayer = FindFirstObjectByType<DanoPlayer>(); //Antigo FindObjectOfType
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecrementarVidaJogador()
    {
        //Decrementar a vida do jogador
        totalVidas--;

        //Verificar se o jogador tem vidas para continuar o jogo
        if (totalVidas < 1)
        {
            //Finaliza o jogo
            FimDeJogo();            
        }
        else
        {
            //Atualiza a imagem da vida para o sprite correspondente
            imgVida.sprite = sptsVida[totalVidas];
        }
    }

    /// <summary>
    /// Método para finalizar o jogo
    /// </summary>
    public void FimDeJogo()
    {
        //Dizer que o jogador morreu
        fimDeJogo = true;

        //Zerar as vidas do jogador
        totalVidas = 0;

        //Colocar o sprite de vida zerada na imagem
        imgVida.sprite = sptsVida[totalVidas];

        //Desabilitar Funções do jogador
        danoPlayer.MatarJogador();

        //Contar o tempo para reiniciar a cena
        StartCoroutine(ReiniciarLevel());
    }

    /// <summary>
    /// Tempo para poder resetar o level
    /// </summary>
    /// <returns></returns>
    IEnumerator ReiniciarLevel()
    {
        //Aguardar 3 segundos para resetar o level
        yield return new WaitForSeconds(3f);

        //Reiniciar o level atual
        ResetarLevelAtual();
    }

    /// <summary>
    /// Reinicia a cena atual
    /// </summary>
    public void ResetarLevelAtual()
    {
        //Reiniciar a cena do jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
