using UnityEngine;

public class ZonaChefe : MonoBehaviour
{
    private ChefeControlador chefeControlador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chefeControlador = FindFirstObjectByType<ChefeControlador>();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            //Habilita a movimentação do chefe
            chefeControlador.HabilitarMovimentacao();

            //Destruir o objeto
            Destroy(gameObject);
        }
    }
}
