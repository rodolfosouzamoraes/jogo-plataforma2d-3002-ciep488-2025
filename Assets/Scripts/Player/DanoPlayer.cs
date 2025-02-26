using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public MovimentarPlayer movimentarPlayer;
    public AnimacaoPlayer animacaoPlayer;
    public void EfetuarDano()
    {
        //Ativa animação de dano
        animacaoPlayer.PlayDano();

        //Resetar a fisica do jogador
        movimentarPlayer.ResetarFisicaDeMovimentacao();

        //Arremessar o jogador
        movimentarPlayer.ArremessarPlayer();

        //Decrementar a vida do jogador
        CanvasGameMng.Instance.DecrementarVidaJogador();
    }

    /// <summary>
    /// Desalibita as moviventações e as fisicas do player ao morrer
    /// </summary>
    public void MatarJogador()
    {
        //Remover a gravidade do player
        movimentarPlayer.RemoverGravidade();

        //Remover a as forças direcionais do player
        movimentarPlayer.ResetarFisicaDeMovimentacao();

        //Ativar animação de morte
        animacaoPlayer.PlayMorte();
    }
}
