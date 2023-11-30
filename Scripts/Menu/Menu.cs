using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuNiveles;
    // Start is called before the first frame update
    void Start()
    {
        MenuNiveles.SetActive(false);
    }

    // Update is called once per frame
    public void Jugar()
    {
        SceneManager.LoadScene("Lvl1Scene");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Lvl2()
    {
        SceneManager.LoadScene("Lvl2Scene");
    }

    public void Lvl3()
    {
        SceneManager.LoadScene("Lvl3Scene");
    }
}
