using UnityEngine;

public static class DBMng
{
    private const string LEVEL_DATA = "level-data-";
    private const string HABILITA_LEVEL = "habilita-level-";
    private const string MEDALHA_LEVEL = "medalha-level-";
    private const string VOLUME = "volume";

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

    public static void SalvarVolume(float volumeVFX, float volumeMusica)
    {
        //Criar um objeto para armazenar os valores dos parametros
        Volume volume = new Volume();
        volume.vfx = volumeVFX;
        volume.musica = volumeMusica;

        //Converter a estrutura da classe em Json
        string json = JsonUtility.ToJson(volume);

        //Salvar na memória o objeto convertido em json
        PlayerPrefs.SetString(VOLUME, json);
    }

    public static Volume ObterVolume()
    {
        //Pegar a estrutura json salva na memoria
        string json = PlayerPrefs.GetString(VOLUME);

        //Converter a estrutura json para um objeto
        Volume volume = JsonUtility.FromJson<Volume>(json);

        //Verificar se o volume está nulo
        if(volume == null)
        {
            //Salvar um volume inicial
            SalvarVolume(0.5f, 0.5f);

            //Atualizar o variavel json
            json = PlayerPrefs.GetString(VOLUME);

            //Converter novamente o json no objeto
            volume = JsonUtility.FromJson<Volume>(json);
        }

        //Retornar o objeto
        return volume;
    }
}
