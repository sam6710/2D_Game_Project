using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlInfo : MonoBehaviour
{
    public string lvlName;
    // Start is called before the first frame update
    void Start()
    {
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        lvlName = SceneManager.GetSceneByBuildIndex(indiceEscenaActual).name;
        Debug.Log("NAME:" + lvlName);
        PlayerPrefs.SetString("PreviousLvL", lvlName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
