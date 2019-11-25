using UnityEngine;
using System.Collections;

public class Player : Entity
{
    private float Score;
    private int CurrentHP = 5;

    private GameGUI gui;

    void Start()
    {
        gui = GameObject.FindGameObjectWithTag("GUI").GetComponent<GameGUI>();
    }

    public void addPlayerHP(int DemagedHP)
    {
        CurrentHP -= DemagedHP;
        gui.setPlayerHPCount(CurrentHP);
        if (CurrentHP <= 0)
            gui.lose();
        Debug.Log("HP: " + CurrentHP);
    }

    public void addExperience(float exp)
    {
        Score += exp;

        gui.setPlayerScore(Score);
        Debug.Log("Score: " + Score);
    }
}
