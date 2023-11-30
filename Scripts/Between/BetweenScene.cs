using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenScene : MonoBehaviour
{
    //private int gems;
    private string previousLvl;
	//private LvlData lvlData;
	private LvlInfo lvlInfo;
	//public TextMeshProUGUI obtenidas;

    // Start is called before the first frame update
    void Start()
    {
		//lvlData = new LvlData();
		//gems = lvlData.gems;
		//previousLvl = lvlInfo.lvlName;

		//obtenidas.text = "" + gems + "/3";

		previousLvl = PlayerPrefs.GetString("PreviousLvL");
		Debug.Log("Between" + previousLvl);
	}

	// Update is called once per frame
	void Update()
    {

    }

    public void Home()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void NextLvL()
    {
        if (previousLvl == "Lvl1Scene")
        {
            SceneManager.LoadScene("Lvl2Scene");
        }
        else if (previousLvl == "Lvl2Scene")
        {
            SceneManager.LoadScene("Lvl3Scene");
        }
        if (previousLvl == "Lvl3Scene")
        {
            SceneManager.LoadScene("Lvl1Scene");
        }
    }
}
