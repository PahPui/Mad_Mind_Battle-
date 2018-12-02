using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : MonoBehaviour {

    public GameObject Heart;
    public List<Transform> Hearts = new List<Transform>();

    // Use this for initialization
    void Awake () {
        Transform[] Children = this.GetComponentsInChildren<Transform>();
        foreach (Transform child in Children)
        {
            if (child.name.StartsWith("H"))
                Hearts.Add(child);
        }
    }
	
    public void AddHeart()
    {
        GameObject newHeart = Instantiate(Heart);
        newHeart.transform.SetParent(transform);
        Hearts.Add(newHeart.transform);
    }
    

    public void UnParentHeart(int num)
    {
        //  Hearts[0].transform.SetParent(transform.parent.transform.parent);
        if (num == 1)
        {
            if (Hearts.Count != 0)
            {
                Hurt(Hearts[0].gameObject);
                Hearts.RemoveAt(0);
            }
        }
        else
        {
            for (int i = 0; i < num; i++)
            {

                if (Hearts.Count != 0)
                {
                    Hurt(Hearts[0].gameObject);
                    Hearts.RemoveAt(0);
                }
            }
        }
    }

    public void GainHearts(int nh = 1)
    {
        for (int i = 0; i < nh; i++) {
            AddHeart();
        }
    }

    public void ClearHearts()
    {
        foreach(Transform h in Hearts)
        {
            Destroy(h.gameObject);
        }
        Hearts.Clear();
    }

    void Hurt(GameObject Heart)
    {
        Heart.GetComponent<Animator>().SetTrigger("Hurt");
        Heart.gameObject.AddComponent<DestroyAfterTime>();
        Heart.gameObject.GetComponent<DestroyAfterTime>().SetTime(1);

    }

}
