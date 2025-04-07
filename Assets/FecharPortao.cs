using UnityEngine;

public class FecharPortao : MonoBehaviour
{
    public float velocidade; //velocidade de rotação do objeto
    public GameObject cadeado;
    public GameObject grade;
    private Quaternion rotacaoAlvo;
    private bool fechouPortao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir a rotação alvo
        rotacaoAlvo = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se deve fechar o portao
        if (fechouPortao == true) {
            //Rotacionar o objeto para a rotacao alvo
            grade.transform.rotation = Quaternion.RotateTowards(
                grade.transform.rotation,
                rotacaoAlvo,
                velocidade * Time.deltaTime
            );
        }
    }

    /// <summary>
    /// ativa o cadeado depois de um tempo
    /// </summary>
    private void AtivarCadeado()
    {
        cadeado.SetActive(true);
    }

    /// <summary>
    /// Mudar a layer do portão para o jogador identificar ela como parede
    /// </summary>
    private void MudarLayer()
    {
        transform.gameObject.layer = 6;
    }

    private void OnTriggerExit2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player" && fechouPortao == false)
        {
            //Habilitar o portão para fechar
            fechouPortao = true;

            //Mudar o boxCollider2D para corpo rigido
            GetComponent<BoxCollider2D>().isTrigger = false;

            //Ativar a Cadeado depois de um tempo
            Invoke("AtivarCadeado", 1f);

            //Mudar o layer depois de 1f
            Invoke("MudarLayer", 1f);
        }
    }

}
