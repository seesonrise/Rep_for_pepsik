using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void Starting(string firstLevel)
    {
        SceneManager.LoadScene(firstLevel);
    }
}
