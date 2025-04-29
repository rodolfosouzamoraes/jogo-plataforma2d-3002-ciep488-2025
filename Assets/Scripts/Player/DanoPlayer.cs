using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public MovimentarPlayer movimentarPlayer;
    public AnimacaoPlayer animacaoPlayer;
    public void EfetuarDano()
    {
        //Verificar se o jogo acabou
        if (CanvasGameMng.Instance.fimDeJogo == true) return;
        
        //Tocar audio do dano player
        AudioMng.Instance.PlayAudioDanos();

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
        //Tocar audio morte
        AudioMng.Instance.PlayAudioMortePlayer();

        //Remover a gravidade do player
        movimentarPlayer.RemoverGravidade();

        //Remover a as forças direcionais do player
        movimentarPlayer.ResetarFisicaDeMovimentacao();

        //Ativar animação de morte
        animacaoPlayer.PlayMorte();
    }
}
