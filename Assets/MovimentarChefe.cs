using UnityEngine;

public class MovimentarChefe : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; //Controlar o sprite do objeto
    private ChefeControlador chefeControlador;
    public float velocidade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referenciar o SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        chefeControlador = GetComponent<ChefeControlador>();
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se pode se mover
        if (chefeControlador.EstaMovendo == false) return;

        Movimentar();
    }

    private void Movimentar()
    {
        //Verificar para onde o chefe está virado
        if(spriteRenderer.flipX == false)
        {
            //Mover para a esquerda
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
        }
        else
        {
            //Mover para a direita
            transform.Translate(Vector3.right *  velocidade * Time.deltaTime);
        }
    }

    public void FlipCorpo()
    {
        //Inverter o flip do sprite
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
