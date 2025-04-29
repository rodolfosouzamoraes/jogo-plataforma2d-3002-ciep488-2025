using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    public Animator animator;

    private bool coletouItem; //Vari�vel para saber se o item foi coletado

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se foi o player que colidiu com o item e se j� houve colisao
        if(coletouItem == false && colisao.gameObject.tag == "Player")
        {
            //Tocar audio da fruta
            AudioMng.Instance.PlayAudioFruta();

            //Diz que j� coletou o item
            coletouItem = true;

            //Ativa a anima��o de coleta do item
            animator.SetTrigger("Coletar");

            //Incrementar a coleta do item
            CanvasGameMng.Instance.IncrementarItemColetavel();
        }
    }

    /// <summary>
    /// M�todo para poder destruir o item ap�s o fim da anima��o de coleta
    /// </summary>
    public void DestruirItem()
    {
        Destroy(gameObject);
    }
}
