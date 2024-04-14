using TMPro;
using UnityEngine;

public class ScoreState : MonoBehaviour
{
    public TextMeshProUGUI TextMeshPro; 
    public int score;
    
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        TextMeshPro.text = "" + score;
    }
}
