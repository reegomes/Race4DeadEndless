using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Pause : MonoBehaviour
{
    public static bool derrota;
    public GameObject pauseMenu, back;
    public TextMeshProUGUI pontua, texto;
    // Botões
    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }
    public void Shop()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    //
    private void Update()
    {
        // Pontuação
        if (derrota == true)
        {
            texto.text = "Você perdeu, talvez seja melhor comprar melhorias na loja.";
            pontua.text = "Seus Pontos: " + ShopStats.points.ToString();
            back.SetActive(false);
        }
        else
        {
            back.SetActive(true);
            texto.text = "Ué? Não vai dar? Volta pro jogo!";
            pontua.text = "Seus Pontos: " + ShopStats.points.ToString();
        }
        //
    }
}
