using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	//スクロール速度
	private float scrollSpeed = -0.03f;
	//背景終了位置(背景ズレが起こるため独自設定）
	private float deadLine = -19;
	//背景開始位置(背景ズレが起こるため独自設定）
	private float startLine = 19.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//背景をスクロールさせる制御
		transform.Translate(this.scrollSpeed,0,0);

		//画面外に出たら背景を移動する
		if (transform.position.x < this.deadLine) {
			transform.position = new Vector2 (this.startLine, 0);
		}
	}
}
