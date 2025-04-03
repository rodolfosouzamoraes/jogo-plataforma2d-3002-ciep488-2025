using UnityEngine;

public class ColisaoChefeComParede : MonoBehaviour
{
    private MovimentarChefe movimentarChefe; //Acessar os códigos do movimentar 
    private bool houveColisao; //Dizer que colidiu

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movimentarChefe = GetComponentInParent<MovimentarChefe>();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se chegou no limite da parede
        if(colisao.gameObject.layer == 6 && houveColisao == false)
        {
            //Defino que houve a colisao
            houveColisao = true;

            //Mudar o flip do chefe
            movimentarChefe.FlipCorpo();
        }
    }

    private void OnTriggerExit2D(Collider2D colisao)
    {
        //Verifico se ele deixou de colidir para permitir novas colisoes
        if(colisao.gameObject.layer == 6)
        {
            //Reabilito a colisao
            houveColisao = false;
        }
    }
}
