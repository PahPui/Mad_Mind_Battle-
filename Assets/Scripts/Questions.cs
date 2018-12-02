using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour {


    public string Question = "";

    public string Answer = "";

    public List<string> WrongAnswers = new List<string>();

    private List<string> TakenWrongAnswers = new List<string>();

    public string GetQuestion()
    {
        return Question;
    }
	
	public string GetAnswer()
    {
        return Answer;
    }

    public string GetWrongAnswer()
    {
        bool repeat = true;
        int r = 0;

        while (repeat == true) {
            r = Random.Range(0, WrongAnswers.Count);
            repeat = CheckIfTaken(r.ToString());
        }

        TakenWrongAnswers.Add(r.ToString());

        return WrongAnswers[r];
    }

    public string GetWrongAnswer(int i = 0)
    {
        return WrongAnswers[i];
    }

    public List<string> GetWrongAnswerList()
    {
        return WrongAnswers;
    }

    public bool CheckIfTaken(string i)
    {
       return TakenWrongAnswers.Contains(i);
    }

    public void resetTaken()
    {
        TakenWrongAnswers.Clear();
    }
}
