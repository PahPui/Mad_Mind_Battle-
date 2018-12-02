using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextBattleUIBanner : MonoBehaviour {

    public GameObject Challenge;
    public GameObject Select;
    public Image image;
    public GameObject HandSelection;

    Coroutine coroutine;

    private void Reset()
    {
        Challenge = this.gameObject;
        Select = transform.GetChild(0).gameObject;
        image = transform.GetChild(1).GetComponent<Image>();
        HandSelection = transform.GetChild(2).gameObject;
    }


    // Use this for initialization
    void Start () {
        Select.gameObject.SetActive(false);
        image.color = Color.black;
        HandSelection.gameObject.SetActive(false);
    }
	
    public void ActiveSelect()
    {
        Select.gameObject.SetActive(true);
        HandSelection.gameObject.SetActive(true);
        image.color = Color.white;
        //coroutine = StartCoroutine(UpdateColor(Color.white));
    }

    public void Deselect()
    {
        Select.gameObject.SetActive(false);
        HandSelection.gameObject.SetActive(false);
        
    }


}
