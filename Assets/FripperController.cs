using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float frickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネントを取得
		this.myHingeJoint = GetComponent<HingeJoint>();
		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);

	}

	// Update is called once per frame
	void Update () {
		float width  = Screen.width / 2f;
		//float widthX = width /2f;
		for (int i = 0; i < Input.touchCount; i++)
	        {
	            // var id = Input.touches[i].fingerId;
	            var pos = Input.touches[i].position;
				foreach(Touch t in Input.touches){
			// var ida = t.fingerId;
			switch(t.phase)
			{
				case TouchPhase.Began:
						if(pos.x > width && tag == "RightFripperTag"){
								SetAngle(this.frickAngle);
								break;
							}
						else if(pos.x < width && tag == "LeftFripperTag"){
								SetAngle(this.frickAngle);
							}
							break;
				case TouchPhase.Moved:
				case TouchPhase.Stationary:
				if(pos.x > width && tag == "RightFripperTag"){
						SetAngle(this.frickAngle);
						break;
					}
				else if(pos.x < width && tag == "LeftFripperTag"){
						SetAngle(this.frickAngle);
					}
					break;

				case TouchPhase.Ended:
				case TouchPhase.Canceled:
				if(pos.x > width && tag == "RightFripperTag"){
									SetAngle(this.defaultAngle);
									break;
							}
				else if(pos.x < width && tag == "LeftFripperTag"){
									SetAngle(this.defaultAngle);
							}
							break;

			}
		}
	}
		//左矢印キーを押した時左フリッパーを動かす
		if(Input.GetKeyDown(KeyCode.LeftArrow) && tag =="LeftFripperTag"){
			SetAngle(this.frickAngle);
			}
			//右矢印キーを押した時左フリッパーを動かす
			if(Input.GetKeyDown(KeyCode.RightArrow) && tag =="RightFripperTag"){
				SetAngle(this.frickAngle);
			}

			//矢印キーが離された時フリッパーを元に戻す
			if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
				SetAngle(this.defaultAngle);
			}
			if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag"){
				SetAngle(this.defaultAngle);
			}

}
			//フリッパーの傾きを設定
			public void SetAngle(float angle){
				JointSpring JointSpr = this.myHingeJoint.spring;
				JointSpr.targetPosition = angle;
				this.myHingeJoint.spring = JointSpr;
			}

}
