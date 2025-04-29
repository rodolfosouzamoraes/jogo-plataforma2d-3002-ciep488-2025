using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    public Animator animator;

    private bool coletouItem; //Variável para saber se o item foi coletado

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se foi o player que colidiu com o item e se já houve colisao
        if(coletouItem == false && colisao.gameObject.tag == "Player")
        {
            //Tocar audio da fruta
            AudioMng.Instance.PlayAudioFruta();

            //Diz que já coletou o item
            coletouItem = true;

            //Ativa a animação de coleta do item
            animator.SetTrigger("Coletar");

            //Incrementar a coleta do item
            CanvasGameMng.Instance.IncrementarItemColetavel();
        }
    }

    /// <summary>
    /// Método para poder destruir o item após o fim da animação de coleta
    /// </summary>
    public void DestruirItem()
    {
        Destroy(gameObject);
    }
}
