using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materia : MonoBehaviour {

    public string Name = "Nombre de Materia";
    public List<Questions> questions = new List<Questions>();

    //public Questions Qprefab;

	// Use this for initialization
	void Start () {
		
	}
	
    public void CreateNewQuestion()
    {
        var n = Instantiate(Resources.Load("Question Prefab",typeof(Questions))) as Questions;
        n.transform.parent = this.transform;
        questions.Add(n);
    } 

}
