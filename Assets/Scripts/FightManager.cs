using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class FightManager : MonoBehaviour {

    public static FightManager instance;
    [Header("Game Settings")]
    public ClockTimer clockTimer;


    public PlayerBase player;
    public EnemyBase enemy;

    public Materia materia;
    public string matToImport;
    public bool canAnswer = true;
    private Questions currentQ;
    private int rightAnswer = 2;

    private Attacks curAttack;

    public Animator FightAnimator;

    [Header("Events")]
    public UnityEvent PlayerWin;
    public UnityEvent PlayerLoss;

    [Header("UI Assing"), Space]
    public TextMeshProUGUI QuestionText;
    public List<TextMeshProUGUI> ButtonsAnswerText = new List<TextMeshProUGUI>();
    
    public HeartContainer PlayerHeartContainer;
    public HeartContainer EnemyHeartContainer;

    public TextMeshProUGUI AttackPower;

    // Use this for initialization
    void Awake () {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        //PrepareBattle();

        matToImport = PlayerPrefs.GetString("MAT");

        GameObject t = Instantiate(Resources.Load("Materia/" + matToImport)) as GameObject;
        materia = t.GetComponent<Materia>();


    }

    
    IEnumerator WaitSecondsForNextAction(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        SetNextQuestion();

    }

    Questions GetQuestion()
    {
      return materia.questions[Random.Range(0, materia.questions.Count)];
    }

    void SetNextQuestion()
    {
        
        canAnswer = true;
        Questions n = GetQuestion();

        SetAnswers(n);
        QuestionText.text = n.Question;
        n.resetTaken();

        GetEnemyAttack();
        clockTimer.resetTimer();
    }


    void SetAnswers(Questions n)
    {
        int RA = Random.Range(0, 4);

        ButtonsAnswerText[RA].text = n.Answer;
        rightAnswer = RA;
        for (int i = 0; i < 4; i++)
        {
            if(i == RA)
            {
                continue;
            }

            ButtonsAnswerText[i].text = n.GetWrongAnswer();

        }

    }

    public void Answer(int D = 1)
    {
        if (canAnswer)
        {
            clockTimer.stopTimer();

            if (D == rightAnswer)
            {

                FightAnimator.SetTrigger("Enemy Hit");
                EnemyHeartContainer.UnParentHeart(curAttack.Damage);
                enemy.curHealth -= curAttack.Damage;
            }
            else
            {
                FightAnimator.SetTrigger("Player Hit");
                PlayerHeartContainer.UnParentHeart(curAttack.Damage);
                player.curHealth -= curAttack.Damage;
            }

            if (player.curHealth <= 0 || enemy.curHealth <= 0)
            {
                // End Fight
                if(player.curHealth <= 0)
                {
                    PlayerLoss.Invoke();
                }
                else
                {
                    PlayerWin.Invoke();
                }

            }
            else
            {
                StartCoroutine(WaitSecondsForNextAction(1));
            }
        }
        canAnswer = false;
        

    }


    public void PrepareBattle()
    {
        PlayerHeartContainer.ClearHearts();
        EnemyHeartContainer.ClearHearts();

        PlayerHeartContainer.GainHearts(player.curHealth);
        EnemyHeartContainer.GainHearts(enemy.curHealth);

        SetNextQuestion();

    }

    public void RegainPlayerHealth()
    {
        int HeartsInContainer = PlayerHeartContainer.Hearts.Count;

        for (int i = HeartsInContainer; i < player.Health; i++)
        {
            PlayerHeartContainer.AddHeart();
        }
    }

    public void RegainPlayerHealth(int gainHearts = 1)
    {
        int HeartsInContainer = PlayerHeartContainer.Hearts.Count;

        for (int i = 0; i < gainHearts; i++)
        {
            if(PlayerHeartContainer.Hearts.Count == player.Health)
            {
                break;
            }
            PlayerHeartContainer.AddHeart();
        }
        
    }

    public void GetEnemyAttack()
    {
        curAttack = enemy.GetAttacks();

        SetAttackUI();
    }

    void SetAttackUI()
    {
        AttackPower.text = curAttack.Damage.ToString();
    }
}
