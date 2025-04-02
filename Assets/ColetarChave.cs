using UnityEngine;

public class ColetarChave : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool coletouChave = false;

    public bool ColetouChave
    {
        get { return coletouChave; }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player" && coletouChave == false)
        {
            //Dizer que coletou a chave
            coletouChave=true;

            //Ocultar a imagem da chave
            spriteRenderer.enabled = false;
        }
    }
}
