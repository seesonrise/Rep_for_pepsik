using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void Starting(int firstLevel)
    {
        SceneManager.LoadScene(firstLevel);
    }
}
