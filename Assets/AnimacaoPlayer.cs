using UnityEngine;

public class AnimacaoPlayer : MonoBehaviour
{
    public Animator animator;

    /// <summary>
    /// Ativa a animação de Parado do personagem
    /// </summary>
    public void PlayParado()
    {
        animator.SetBool("Parado", true);
        animator.SetBool("Correndo", false);
        animator.SetBool("Caindo", false);
        animator.SetBool("Pulando", false);
        animator.SetBool("DeslizarParede", false);
    }

    /// <summary>
    /// Ativa a animação de Correndo do personagem
    /// </summary>
    public void PlayCorrendo()
    {
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", true);
        animator.SetBool("Caindo", false);
        animator.SetBool("Pulando", false);
        animator.SetBool("DeslizarParede", false);
    }

    /// <summary>
    /// Ativa a animação de Caindo do personagem
    /// </summary>
    public void PlayCaindo()
    {
        animator.SetBool("Caindo",true);
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
        animator.SetBool("Pulando", false);
        animator.SetBool("DeslizarParede", false);
    }

    /// <summary>
    /// Ativa a animação de Pulando do personagem
    /// </summary>
    public void PlayPulando()
    {
        animator.SetBool("Pulando", true);
        animator.SetBool("Caindo", false);
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
        animator.SetBool("DeslizarParede", false);
    }

    /// <summary>
    /// Ativa a animação de pulo duplo
    /// </summary>
    public void PlayPuloDuplo()
    {
        animator.SetBool("Pulando", false);
        animator.SetBool("Caindo", false);
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
        animator.SetBool("DeslizarParede", false);
        animator.SetTrigger("PuloDuplo");
    }

    /// <summary>
    /// Ativa animação de deslizar da parede
    /// </summary>
    public void PlayDeslizarParede()
    {
        animator.SetBool("DeslizarParede", true);
        animator.SetBool("Pulando", false);
        animator.SetBool("Caindo", false);
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
    }

    /// <summary>
    /// Ativa a animação de dano ao jogador
    /// </summary>
    public void PlayDano()
    {
        animator.SetTrigger("Dano");
    }
}
