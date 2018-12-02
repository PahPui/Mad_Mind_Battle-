using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBattleUIOrganizar : MonoBehaviour {

    public int FightNum = 0;
    public List<NextBattleUIBanner> nextBattleUIBanners = new List<NextBattleUIBanner>();
   


	// Use this for initialization
	void Start () {
        NextBattleUIBanner[] Children = this.GetComponentsInChildren<NextBattleUIBanner>();
        foreach (NextBattleUIBanner child in Children)
        {
            if (child.name.StartsWith("C"))
                nextBattleUIBanners.Add(child);
        }

        NextSelection();
    }
	
    public void NextSelection()
    {
        nextBattleUIBanners[FightNum].ActiveSelect();
    }

    public void Deselect()
    {
        nextBattleUIBanners[FightNum].Deselect();
    }
}
