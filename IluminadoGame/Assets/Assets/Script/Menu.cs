using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string proximaFase;
    //public GameObject[] itensMenu;
    //public GameObject[] itensConfig;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    public void StarGame()
    {
        SceneManager.LoadScene(proximaFase);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void QuitGame()
    {
        //Mensagem no Unity de saida do jogo

        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
    
}
