using UnityEngine;
using UnityEngine.SceneManagement;

public class escMenu : MonoBehaviour
{
    public GameObject menuPause;
    void Start()
    {
        // Desactivar el men� de pausa al inicio
        menuPause.SetActive(false);
        Debug.Log("Me cago en tus muertos");
    }

    void Update()
    {
        // Verificar si se presiona la tecla "Escape"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alternar la visibilidad del men� de pausa
            ToggleMenuPause();
        }
    }

    void ToggleMenuPause()
    {
        // Cambiar el estado activo/desactivo del men� de pausa
        menuPause.SetActive(!menuPause.activeSelf);

        // Pausar o reanudar el tiempo en el juego seg�n el estado del men� de pausa
        Time.timeScale = (menuPause.activeSelf) ? 0 : 1;
    }

    public void Home() 
    {
        SceneManager.LoadScene("MenuScene");
        Debug.Log("HOME");
    }

    public void returnToLvL() 
    {
        Debug.Log("LVL");
        ToggleMenuPause();
    }
}
