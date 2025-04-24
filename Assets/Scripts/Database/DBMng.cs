using UnityEngine;

public static class DBMng
{
    private const string LEVEL_DATA = "level-data-";
    private const string HABILITA_LEVEL = "habilita-level-";
    private const string MEDALHA_LEVEL = "medalha-level-";

    /// <summary>
    /// Buscar na memória a quantidade de itens coletados no level
    /// </summary>
    public static int BuscarColetaveisLevel(int idLevel)
    {
        return PlayerPrefs.GetInt(LEVEL_DATA + idLevel);
    }

    public static void SalvarDadosLevel(int idLevel, int totalColetados, int idMedalha)
    {
        //Buscar a quantidade de itens coletados do level na memória
        int coletadosSalvos = BuscarColetaveisLevel(idLevel);

        //Verificar se o total atual é maior que o que já foi salvo
        if (totalColetados > coletadosSalvos) { 
            //Salvar a quantidade de itens coletados
            PlayerPrefs.SetInt(LEVEL_DATA+idLevel, totalColetados);

            //Salvar o id da medalha
            PlayerPrefs.SetInt(MEDALHA_LEVEL+idLevel, idMedalha);
        }

        //Habilitar o próximo level para jogar
        PlayerPrefs.SetInt(HABILITA_LEVEL + (idLevel + 1), 1);
    }

    public static int BuscarLevelHabilitado(int idLevel)
    {
        return PlayerPrefs.GetInt(HABILITA_LEVEL+idLevel);
    }

    public static int BuscarMedalhaLevel(int idLevel)
    {
        return PlayerPrefs.GetInt(MEDALHA_LEVEL + idLevel);
    }
}
