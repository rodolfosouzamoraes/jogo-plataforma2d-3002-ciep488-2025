using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenuMng : MonoBehaviour
{
    public GameObject[] paineis; //Todos os paineis do menu
    public GameObject[] cadeadosLevel;
    public GameObject[] qtdsColetaveis;
    public GameObject[] medalhasLevel;
    public Sprite[] sptsMedalhas;
    public TextMeshProUGUI[] txtsColetaveisPorLevel;
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

    private void ConfigurarPainelNiveis()
    {
        //Exibir a quantidade de itens de cada level
        for (int i = 1; i < txtsColetaveisPorLevel.Length; i++) {
            //Buscar os dados dos itens coletados de cada nivel
            int totalColetaveis = DBMng.BuscarColetaveisLevel(i);

            //Atualizar os textos
            txtsColetaveisPorLevel[i].text = $"x{totalColetaveis}";
        }

        //Habilitar ou desabilitar os leveis
        for (int i = 2; i < cadeadosLevel.Length; i++) { 
            //Verificar se o level atual está habilitado
            bool estaHabilitado = DBMng.BuscarLevelHabilitado(i) == 1 ? true : false;

            //Exibir ou não o cadeado
            cadeadosLevel[i].SetActive(!estaHabilitado);

            //Exibir ou não os itens do level
            qtdsColetaveis[i].SetActive(estaHabilitado);
        }

        //Definir as medalhas de cada level
        for (int i = 1; i < medalhasLevel.Length; i++) {
            //Verificar o id da medalha
            int medalhaLevel = DBMng.BuscarMedalhaLevel(i);

            //Verificar se há alguma medalha para o level
            if (medalhaLevel == 0) {
                //Desativar a imagem da medalha
                medalhasLevel[i].SetActive(false);
            }
            else
            {
                //Aterar a imagem para a medalha correspondente
                medalhasLevel[i].
                    GetComponent<Image>().sprite = sptsMedalhas[medalhaLevel];
            }
        }
    }

    public void IniciarLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void IniciarLevel(int idLevel)
    {
        //Verificar se o cadeado está desabilitado
        if (cadeadosLevel[idLevel].activeSelf == false) {
            SceneManager.LoadScene(idLevel);
        }
    }
}
