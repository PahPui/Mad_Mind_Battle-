using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct RoundChallenge
{
    public EnemyBase enemy;
    public Texture2D texture;
}

public class RoundManager : MonoBehaviour {

    public Transform PPosition;
    public Transform EPosition;

    public PlayerBase player;
    public EnemyBase enemy;

    public bool ViewingChallengers;
    public List<RoundChallenge> roundChallenges = new List<RoundChallenge>();
    public int RoundNumber = 0;

    public NextBattleUIOrganizar uIOrganizar;
    public Animator nextBattleAnimator;

	// Use this for initialization
	void Start () {
        
        Invoke("SetUpBattle",3);
    }


    void SetUpBattle()
    {
        nextBattleAnimator.SetBool("Show", false);
        uIOrganizar.NextSelection();

        enemy = Instantiate(roundChallenges[RoundNumber].enemy);
        enemy.transform.parent = EPosition;
        enemy.transform.localPosition = Vector3.zero;

        FightManager.instance.enemy = enemy;
        FightManager.instance.player = player;

        FightManager.instance.Invoke("PrepareBattle",.25f);
    }

    public void RoundEnd()
    {
        nextBattleAnimator.SetBool("Show",true);
        uIOrganizar.Deselect();
        RoundNumber++;
        uIOrganizar.FightNum++;
        Destroy(enemy.gameObject, 1f);
        enemy = null;

        player.RegainHealth(2);

        if (RoundNumber > roundChallenges.Count - 1)
        {
            GameEnd();
        }
        else
        {
            uIOrganizar.NextSelection();
            Invoke("SetUpBattle", 2f);
        }
    }

    public void GameEnd()
    {
        Invoke("LoadMainMenuLevel", 5f);
    }

    void LoadMainMenuLevel()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
