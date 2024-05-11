using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Level Scene");

    }
    public void QuitGame()
        {
            Application.Quit();
        }
    public void EndScene()
    {
        SceneManager.LoadScene("End");

    }
}
