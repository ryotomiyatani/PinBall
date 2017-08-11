using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;
	//ゲームオーバーを表示するテキスト
	private GameObject gameoverText;
	//スコアの初期化
	private int score = 0;
	//点数を表示するテキスト
	public Text scoreText;


	// Use this for initialization
	void Start () {
		this.gameoverText = GameObject.Find("GameOverText");
		// scoreText.text = "Score："+ score;
	}

	// Update is called once per frame
	void Update () {
		//ボール画面外にでた場合
		if(this.transform.position.z < this.visiblePosZ){
			//GameOverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";


		}
		scoreText.text = "Score："+ score;
	}

	void OnCollisionEnter(Collision ob){
		if(ob.gameObject.tag == "SmallStarTag"){
			score = score + 10;
		}else if (ob.gameObject.tag == "LargeStarTag"){
			score += 20;
		}else if(ob.gameObject.tag == "SmallCloudTag"){
			score += 40;
		}else if(ob.gameObject.tag =="LargeCloudTag"){
			score += 50;
		}

}
}
