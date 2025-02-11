using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    public FlipCorpoPlayer flipCorpo;
    public float velocidade; //Velocidade de movimenta��o
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
    }

    /// <summary>
    /// L�gica de movimenta��o do personagem
    /// </summary>
    private void Movimentar()
    {
        //Pegar a entrada do usu�rio para fazer a movimenta��o
        float eixoX = Input.GetAxis("Horizontal");

        //Olhar para o lado onde o jogador est� movendo
        if (eixoX > 0) {
            flipCorpo.OlharDireita();
        }
        else if (eixoX < 0)
        {
            flipCorpo.OlharEsquerda();
        }

        //Dire��o da movimenta��o
        Vector3 direcaoMovimento = new Vector3(eixoX,0,0);

        //Movimentar o personagem no sentido da dire��o
        transform.position += direcaoMovimento * velocidade * Time.deltaTime;
    }
}
