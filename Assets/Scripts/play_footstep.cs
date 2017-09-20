using UnityEngine;
using System.Collections;

public class play_footstep : MonoBehaviour {

	private CriAtomSource sound_manager;

	// Use this for initialization
	void Start () {
		// SoundManagerにアクセスできるようにする。
		sound_manager = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<CriAtomSource>();

		// 初期状態をrunに。
		sound_manager.player.SetSelectorLabel ("state","run");
	}
	
	// 接地したら
	void OnTriggerEnter (Collider col){
		// 触れたオブジェのマテリアルを取得(tagで検出も実装しても良いと思う)
		string change_material = col.gameObject.GetComponent<Renderer> ().sharedMaterial.name;
		Debug.Log (change_material);
		// 地面のタイプを変更し、再生
		sound_manager.player.SetSelectorLabel ("ground_type",change_material);
		sound_manager.Play();
	}
}
