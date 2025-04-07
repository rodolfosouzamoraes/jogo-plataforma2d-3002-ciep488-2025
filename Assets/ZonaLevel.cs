using UnityEngine;

public class ZonaLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            //Finalizar o jogo
            CanvasGameMng.Instance.FimDeJogo();
        }
    }
}
