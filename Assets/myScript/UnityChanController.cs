using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour {
	//アニメーションするためのコンポーネント
	Animator animator;
	//Unityちゃんを移動させるためのコンポーネント
	Rigidbody2D rigid2D;

	//地面の位置
	private float groundLevel = -3.0f;

	//ジャンプの高さの減衰
	private float dump = 0.8f;

	//ジャンプの速度
	float jumpVelocity = 20;

	// Use this for initialization
	void Start () {
		//アニメーターのコンポーネントを取得
		this.animator = GetComponent<Animator> ();
		//Rigidbody2Dのコンポーネントを取得
		this.rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//走るアニメーションを再生する為に、Animatorのパラメータを調整する
		this.animator.SetFloat("Horizontal",1);

		//着地しているかどうかを調べる
		bool isGround = (transform.position.y >this.groundLevel) ? false : true;
		this.animator.SetBool ("isGround", isGround);

		//着地状態でクリックされた場合
		if (Input.GetMouseButton (0) && isGround) {
			//上方向に力をかける
			this.rigid2D.velocity = new Vector2(0,this.jumpVelocity);
		}

		//クリックをやめたら上方向への速度を減速する
		if (Input.GetMouseButton (0) == false) {
			if (this.rigid2D.velocity.y > 0) {
				this.rigid2D.velocity *= this.dump;
			}
		}
	}
}
