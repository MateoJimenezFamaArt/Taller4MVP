using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Public variable to hold the name of the next scene
    public int SceneNumber;

    // Function to load the next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
