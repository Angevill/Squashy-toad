using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour {

    public void LoadGame()
    {
        Debug.Log("Load Request:");
        SceneManager.LoadScene("Main");
    }
}
