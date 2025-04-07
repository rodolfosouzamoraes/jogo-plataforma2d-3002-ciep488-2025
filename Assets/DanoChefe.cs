using UnityEngine;

public class DanoChefe : MonoBehaviour
{
    private ChefeControlador chefeControlador;
    private bool houveColisao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chefeControlador = GetComponentInParent<ChefeControlador>();
    }

    /// <summary>
    /// Reabilitar a colisão com o player
    /// </summary>
    private void PermitirColisao()
    {
        houveColisao = false;
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player" && houveColisao == false)
        {
            //Definir que houve a colisão
            houveColisao = true;

            //Arremessar o player
            colisao.GetComponent<PlayerControlador>().MovimentarPlayer.ArremessarPlayer();

            //Decrementar a vida do chefe
            chefeControlador.DecrementarVidaChefe();

            //Rehabilitar a colisão com o chefe
            Invoke("PermitirColisao", 0.3f);
        }
    }
}
