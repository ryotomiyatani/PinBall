using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	//スコアの初期化
	private int score = 0;
	//点数を表示するテキスト
	public Text scoreText;

	public GameObject ball;


	// Use this for initialization
	void Start () {
		scoreText.text = "Score："+ score;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision other){
		if(tag == "SmallStarTag"){
					score += 1;
		}else if(tag =="LargeStarTag"){
			score += 10;
		}

	}
}
