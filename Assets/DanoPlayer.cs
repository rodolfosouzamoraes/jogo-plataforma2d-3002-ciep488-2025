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
    }
}
