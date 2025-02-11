using UnityEngine;

public class FlipCorpoPlayer : MonoBehaviour
{
    public SpriteRenderer spriteCorpo;

    /// <summary>
    /// Fazer o corpo virar para a Direita
    /// </summary>
    public void OlharDireita()
    {
        spriteCorpo.flipX = false;
    }

    /// <summary>
    /// Fazer o corpo virar para a esquerda
    /// </summary>
    public void OlharEsquerda()
    {
        spriteCorpo.flipX = true;
    }
}
