using UnityEngine;

public class PlayerControlador : MonoBehaviour
{
    private MovimentarPlayer movimentarPlayer;
    private AnimacaoPlayer animacaoPlayer;
    private DanoPlayer danoPlayer;

    //Definir as propriedades de acesso aos códigos do player
    public MovimentarPlayer MovimentarPlayer
    {
        get { return movimentarPlayer; }
    }
    public AnimacaoPlayer AnimacaoPlayer
    {
        get { return animacaoPlayer; }
    }
    public DanoPlayer DanoPlayer
    {
        get { return danoPlayer; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //Obter a referencia do movimentar player
        movimentarPlayer = GetComponent<MovimentarPlayer>();

        //Obter a referencia do animacaoPlayer
        animacaoPlayer = GetComponentInChildren<AnimacaoPlayer>();

        //Obter a refencia do danoPlayer
        danoPlayer = GetComponent<DanoPlayer>();
    }
}
