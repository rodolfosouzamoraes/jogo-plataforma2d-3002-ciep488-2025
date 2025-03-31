using System.Security.Cryptography;
using UnityEngine;

public class ArmadilhaLamina : MonoBehaviour
{
    public Vector3[] destinos; //Todos os destinos que a lamina deve fazer
    public float velocidade;
    public float tempoProximoDestino;//Tempo que vai aguardar para ir para o próximo destino
    private int idProximoDestino; //Identificar o proximo destino que a lamina deve ir
    private bool chegouAoDestino;// Diz se a lamina chegou ao destino definido
    private float tempoEspera; //Tempo de espera para mudar o destino
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Mandar a lamina para a posicao inicial, que é o destino 0 do vetor
        transform.position = destinos[0];

        //Definir o proximo destino que a lamina deve ir
        idProximoDestino = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLamina();
    }

    private void MovimentarLamina()
    {
        //Verificar se lamina chegou ao destino definido
        if(chegouAoDestino == true)
        {
            //Verificar se a laminha deve aguardar para definir o proximo destino
            if (Time.time > tempoEspera)
            {
                //Mudar o destino da lamina
                idProximoDestino++;

                //Verificar se passou do ultimo destino do vetor
                if(idProximoDestino == destinos.Length)
                {
                    //Definir o destino para o inicial
                    idProximoDestino = 0;
                }

                //Denir que a lamina não chegou ao destino atual
                chegouAoDestino = false;
            }
        }
        //Movimentar a laminha para o destino
        else
        {
            //Calcular a movimentação da lamina
            float velocidadeMovimento = velocidade * Time.deltaTime;

            //Mover a lamina até o ponto do destino
            transform.position = Vector3.MoveTowards(
                transform.position,
                destinos[idProximoDestino],
                velocidadeMovimento
            );

            //Verificar se chegou ao destino final
            if(Vector3.Distance(transform.position, destinos[idProximoDestino]) < 0.001f)
            {
                //Altera o tempo de espera
                tempoEspera = Time.time + tempoProximoDestino;

                //Define que chegou ao destino
                chegouAoDestino= true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            //Matar o jogador
            CanvasGameMng.Instance.FimDeJogo();
        }
    }
}
