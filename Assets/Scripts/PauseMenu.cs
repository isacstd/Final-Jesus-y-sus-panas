using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PanelPausa;
    public GameObject PanelSettings;

    public void Pausar()
    {
        PanelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        PanelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void AbrirSettings()
    {
        PanelPausa.SetActive(false);
        PanelSettings.SetActive(true);
    }

    public void CerrarSettings()
    {
        PanelSettings.SetActive(false);
        PanelPausa.SetActive(true);
    }
}
