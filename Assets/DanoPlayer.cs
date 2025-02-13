using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public MovimentarPlayer movimentarPlayer;
    public void EfetuarDano()
    {
        //Resetar a fisica do jogador
        movimentarPlayer.ResetarFisicaDeMovimentacao();

        //Arremessar o jogador
        movimentarPlayer.ArremessarPlayer();
    }
}
