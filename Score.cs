using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    [SerializeField]private TextMeshProUGUI text;

    private void Update()
    {
        text.text = "Score: "+score;
    }

}
