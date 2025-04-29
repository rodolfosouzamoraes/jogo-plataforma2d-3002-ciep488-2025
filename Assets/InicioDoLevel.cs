using UnityEngine;

public class InicioDoLevel : MonoBehaviour
{
    private GameObject player;
    public GameObject posicaoPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<MovimentarPlayer>().gameObject;
        player.transform.position = posicaoPlayer.transform.position;

        //Tocar audio de surgimento
        AudioMng.Instance.PlayAudioSurgir();
    }
}
