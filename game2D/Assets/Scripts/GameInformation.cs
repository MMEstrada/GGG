using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameInformation : MonoBehaviour {

    private int grandmaChoice = 0;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ChooseGrandma(int i)
    {
        grandmaChoice = i;
        SceneManager.LoadScene("Traninglevel");
    }

    void SaveGame()
    {

    }

    void LoadGame()
    {

    }
}
