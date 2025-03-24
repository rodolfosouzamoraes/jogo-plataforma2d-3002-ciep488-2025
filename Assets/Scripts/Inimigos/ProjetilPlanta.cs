using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilPlanta : MonoBehaviour
{
    public float velocidade;
    private Vector3 direcao; //Direção para movimentar o objeto
    private bool houveColisao;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentar o projetil em relação a direção para onde ele deve ir
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
    
    /// <summary>
    /// Mudar a direção para onde o projetil deve ir
    /// </summary>
    public void MudarDirecao(Vector3 novaDirecao){
        direcao = novaDirecao;
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verifica se colidiu com a layer 7 que corresponde ao player
        if(colisao.gameObject.layer == 7 && houveColisao == false){
            //Diz que houve a colisao
            houveColisao = true;
            //Dar dano ao player
            FindFirstObjectByType<PlayerControlador>().DanoPlayer.EfetuarDano();
        }
        Destroy(gameObject);
    }
}
