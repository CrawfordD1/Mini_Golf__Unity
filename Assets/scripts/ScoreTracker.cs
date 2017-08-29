using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreTracker : MonoBehaviour {

	public Text Hole1;
	public Text Hole2;
	public Text Hole3;
	public Text Hole4;
	public StrokeCounter strokeCounter;
	public ArrayList scores;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		this.strokeCounter = new StrokeCounter ();
		scores = new ArrayList();
		for (int i = 0; i < 19; i++) {
			scores.Add (0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Hole1.text = scores[0].ToString();
		Hole2.text = scores[1].ToString();
		Hole3.text = scores[2].ToString();
		Hole4.text = scores[3].ToString();
	}

	public void updateScore(int currentHole){
		scores [currentHole] = strokeCounter.getCurrentCount();

	}

	public void addStroketoCurrent(){
		strokeCounter.addStroke();
	}

	public int getStrokes(){
		return strokeCounter.getCurrentCount ();
	}

	public void resetStrokes(){
		strokeCounter.resetStrokes ();
	}




}
