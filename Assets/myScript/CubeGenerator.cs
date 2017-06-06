using UnityEngine;
using System.Collections;

public class CubeGenerator : MonoBehaviour {
	//CubeのPrefab
	public GameObject cubePrefab;

	//時間計測用の変数
	private float delta = 0;

	//Cubeの生成間隔
	private float span = 1.0f;

	//Cubeの生成位置
	private float genPosX = 12;

	//Cubeの生成位置オフセット
	private float offsetY = 0.3f;

	//Cubeの縦方向の間隔
	private float spaceY = 6.9f;

	//Cubeの生成位置オフセット
	private float offsetX = 0.5f;

	//Cubeの縦方向の間隔
	private float spaceX = 0.4f;

	//Cubeの生成個数の上限
	private int maxBlockNum = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//前回フレームと今フレームの時間の秒数をdelta変数へ格納
		this.delta += Time.deltaTime;

		//span以上の時間が経過したか調べる
		if (this.delta > this.span) {
			this.delta = 0;
			//生成するCubeの個数をランダムに決める
			int n = Random.Range (1, this.maxBlockNum + 1);

			//指定した数だけCubeを生成する
			for (int i = 0; i < n; i++) {
				//Cubeの生成
				GameObject go = Instantiate (cubePrefab) as GameObject;
				go.transform.position = new Vector2 (this.genPosX, this.offsetY + i * this.spaceY);
			}
			//次のCubeまでの生成時間を決める
			this.span = this.offsetX + this.spaceX * n;
		}
			
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "CubeTag") {
			Debug.Log ("PL");
		}
	}
}
