using UnityEngine;

public class AbrirPortao : MonoBehaviour
{
    public ColetarChave chave; //A chave que vai abrir o portao
    public float velocidade; //Velocidade da rotacao do portao
    public GameObject cadeado; //Cadeado que está no portão
    private Quaternion rotacaoAlvo;//Angulo alvo para qual o portão irá rotacionar
    private bool abriuPortao;//Diz se o portão está aberto
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir o angulo da rotacao alvo
        rotacaoAlvo = Quaternion.Euler(new Vector3(0, 90, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o portão foi aberto
        if (abriuPortao == true) 
        {
            //Rotacionar o objeto para a rotacao alvo
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                rotacaoAlvo,
                velocidade * Time.deltaTime
            );
        }
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        //Verificar se o player colidiu e se tem a chave
        if(colisao.gameObject.tag == "Player" && chave.ColetouChave == true)
        {
            //definir que o portao deve ser aberto
            abriuPortao = true;

            //Desativar a cadeado
            cadeado.SetActive(false);

            //Desativar a colisao com o portão
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
