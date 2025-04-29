using UnityEngine;

public class FimDoLevel : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se o player colidiu
        if(colisao.gameObject.tag == "Player")
        {
            //Tocar audio fim do level
            AudioMng.Instance.PlayAudioItemFinal();

            //Ativo a animação do fim do level
            animator.SetBool("FimDoLevel", true);

            //Finalizo o level
            CanvasGameMng.Instance.CompletouLevel();
        }
    }
}
