using UnityEngine;

public class CanvasMenuMng : MonoBehaviour
{
    public GameObject[] paineis; //Todos os paineis do menu

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Exibir a tela de menu ao iniciar o jogo
        ExibirPainel(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Método para exibir o painel solicitado
    /// </summary>
    public void ExibirPainel(int id)
    {
        //Ocultando todos os painéis
        foreach(var painel in paineis)
        {
            painel.SetActive(false);
        }

        //Exibir o painel solicitado
        paineis[id].SetActive(true);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
