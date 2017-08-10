using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {
	Material myMaterial;

	//Emissionの最小値
	private float minEminssion = 0.3f;
	//Emissionの強度
	private float magEmission = 2.0f;
	//角度
	private int degree = 0;
	//発行速度
	private int speed = 10;
	//ターゲットのデフォルトの色
	Color defaultColor = Color.white;


	// Use this for initialization
	void Start () {
		if(tag == "SmalltarTag"){
			this.defaultColor = Color.white;
		}else if(tag == "LargeStarTag"){
			this.defaultColor = Color.yellow;
		}else if(tag == "SmallCloudTag" || tag == "LargeCloudTag"){
			this.defaultColor = Color.blue;
		}
		//オブジェクトにアタッチしているMaterialを取得
		this.myMaterial =GetComponent<Renderer>().material;

		//オブジェクトの最初の色を設定
		myMaterial.SetColor("_EmissionColor",this.defaultColor*minEminssion);


	}

	// Update is called once per frame
	void Update () {
		if(this.degree >= 0){
			//光らせる強度計算する
			Color emissionColor = this.defaultColor * (this.minEminssion + Mathf.Sin(this.degree * Mathf.Deg2Rad) * magEmission);

			//Emissionに色を設定する
			myMaterial.SetColor("_EmissionColor", emissionColor);

			//現在の角度を小さくする
			this.degree -= this.speed;
		}


	}
	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other){
		//角度を180に設定
		this.degree = 180;
	}
}
