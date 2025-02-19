using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public MovimentarPlayer movimentarPlayer;
    public AnimacaoPlayer animacaoPlayer;
    public void EfetuarDano()
    {
        //Ativa anima��o de dano
        animacaoPlayer.PlayDano();

        //Resetar a fisica do jogador
        movimentarPlayer.ResetarFisicaDeMovimentacao();

        //Arremessar o jogador
        movimentarPlayer.ArremessarPlayer();

        //Decrementar a vida do jogador
        CanvasGameMng.Instance.DecrementarVidaJogador();
    }

    /// <summary>
    /// Desalibita as moviventa��es e as fisicas do player ao morrer
    /// </summary>
    public void MatarJogador()
    {
        //Remover a fisica do player
        Destroy(movimentarPlayer.rigidbody2d);

        //Remover a movimenta��o do player
        Destroy(movimentarPlayer);

        //Ativar anima��o de morte
        animacaoPlayer.PlayMorte();
    }
}
