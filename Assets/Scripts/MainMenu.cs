using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public GameObject StartUI;
    public GameObject PlayUI;
    public GameObject OptionsUI;

	// Use this for initialization
	void Start () {
        StartUI.SetActive(true);
        PlayUI.SetActive(false);
        OptionsUI.SetActive(false);
    }
	
    public void LoadPackLevel(string materia)
    {
        PlayerPrefs.SetString("MAT", materia);

        PlayerPrefs.Save();

        LoadNextLevel(1);
    }

    public void LoadNextLevel(int level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }


}
