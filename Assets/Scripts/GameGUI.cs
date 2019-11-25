using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameGUI : MonoBehaviour 
{
    public TextMesh HP;
    public TextMesh Score;
    public TextMesh Hint;
    public TextMesh gameOver;

    public void setPlayerHPCount(int playerHP)
    {
        HP.text = "HP : " + playerHP;
    }
    
    public void setPlayerScore(float playerScore)
    {
        
        Score.text = "Score: " + playerScore;
    }

    public void lose()
    {
        Hint.text = "press[enter] or [Shoot]";
        gameOver.text = "To Game Over Screen";
    }
}
