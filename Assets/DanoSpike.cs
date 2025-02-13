using System.Collections;
using UnityEngine;

public class DanoSpike : MonoBehaviour
{
    private bool houveColisao;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && houveColisao == false)
        {
            //Diz que houve colisão
            houveColisao = true;

            //Dano ao jogador
            collision.gameObject.GetComponent<DanoPlayer>().EfetuarDano();

            //Reabilitar o dano ao jogador
            StartCoroutine(ResetarColisao());
        }
    }

    private IEnumerator ResetarColisao()
    {
        //Espera 0.3 segundo para poder haver uma nova colisão com o player
        yield return new WaitForSeconds(0.3f);
        houveColisao = false;
    }
}
