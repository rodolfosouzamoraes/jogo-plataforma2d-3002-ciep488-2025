using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeEspinhos : MonoBehaviour
{
    public float velocidade = 100;
    public bool rotacaoConstante; //Diz se quer que o objeto rotacione constantemente ou não

    // Update is called once per frame
    void Update()
    {
        //Rotacionar o objeto
        transform.eulerAngles += Vector3.back * velocidade * Time.deltaTime;

        //Verificar se a rotação será constante ou não
        if(rotacaoConstante == false){
            //Verificar os limites para rotacionar
            if(transform.eulerAngles.z >= 90 && transform.eulerAngles.z <=270){
                //Inverter a velocidade
                velocidade *=-1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player"){
            CanvasGameMng.Instance.FimDeJogo();
        }
    }
}
