using UnityEngine;

public class AudioMng : MonoBehaviour
{
    public static AudioMng Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public AudioSource audioVFX; //Variavel para emitir os audios dos VFX
    public AudioSource audioMusica;//Variavel para emitir os audios das musicas
    public AudioClip clipGame;
    public AudioClip clipMenu;
    public AudioClip clipClick;
    public AudioClip clipFruta;
    public AudioClip[] clipsDano;
    public AudioClip clipPular;
    public AudioClip clipCorrer;
    public AudioClip clipChave;
    public AudioClip clipChefe;
    public AudioClip clipSurgir;
    public AudioClip clipProjetil;
    public AudioClip clipDanoInimigo;
    public AudioClip clipItemFinal;
    public AudioClip clipMortePlayer;
    public AudioClip clipPortao;
    public AudioClip clipMorteChefe;

    /// <summary>
    /// Método para alterar o volume dos audios
    /// </summary>
    public void MudarVolume(Volume volume)
    {
        //Mudar os valores de volumes do audio source
        audioVFX.volume = volume.vfx;
        audioMusica.volume = volume.musica;
    }

    public void PlayAudioMenu()
    {
        //Verificar se a musica atual é diferente da do menu
        if(audioMusica.clip != clipMenu)
        {
            //Parar o audio
            audioMusica.Stop();

            //Trocar a "Fita"
            audioMusica.clip = clipMenu;

            //Tocar o audio
            audioMusica.Play();
        }
    }

    public void PlayAudioLevel()
    {
        //Verificar se a musica atual é diferente da do menu
        if (audioMusica.clip != clipGame)
        {
            //Parar o audio
            audioMusica.Stop();

            //Trocar a "Fita"
            audioMusica.clip = clipGame;

            //Tocar o audio
            audioMusica.Play();
        }
    }

    public void PlayAudioDanos()
    {
        //Sortear o audio de dano
        var audioSorteado = new System.Random().Next(0,clipsDano.Length);

        //Emitir o audio sorteado
        audioVFX.PlayOneShot(clipsDano[audioSorteado]);
    }

    public void PlayAudioClick()
    {
        audioVFX.PlayOneShot(clipClick);
    }
    public void PlayAudioFruta()
    {
        audioVFX.PlayOneShot(clipFruta);
    }
    public void PlayAudioPular()
    {
        audioVFX.PlayOneShot(clipPular);
    }
    public void PlayAudioCorrer()
    {
        audioVFX.PlayOneShot(clipCorrer);
    }
    public void PlayAudioSurgir()
    {
        audioVFX.PlayOneShot(clipSurgir);
    }
    public void PlayAudioChave()
    {
        audioVFX.PlayOneShot(clipChave);
    }
    public void PlayAudioChefe()
    {
        audioVFX.PlayOneShot(clipChefe);
    }
    public void PlayAudioProjetil()
    {
        audioVFX.PlayOneShot(clipProjetil);
    }
    public void PlayAudioDanoInimigo()
    {
        audioVFX.PlayOneShot(clipDanoInimigo);
    }
    public void PlayAudioItemFinal()
    {
        audioVFX.PlayOneShot(clipItemFinal);
    }
    public void PlayAudioMortePlayer()
    {
        audioVFX.PlayOneShot(clipMortePlayer);
    }
    public void PlayAudioPortao()
    {
        audioVFX.PlayOneShot(clipPortao);
    }
    public void PlayAudioMorteChefe()
    {
        audioVFX.PlayOneShot(clipMorteChefe);
    }
}
