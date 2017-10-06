using UnityEngine;
using UnityEngine.Playables;

// PlayableTrackサンプル
public class TestPlayableBehaviour : PlayableBehaviour
{
    public GameObject sceneObj;
    public GameObject projectObj;

    GameObject obj;

    // タイムライン開始時実行
    public override void OnGraphStart(Playable playable)
    {
    }
    // タイムライン停止時実行
    public override void OnGraphStop(Playable playable)
    {
    }
    // PlayableTrack再生時実行
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        //if (Application.isPlaying && obj == null)
        //    obj = Object.Instantiate(projectObj) as GameObject;
        Object.Destroy(sceneObj);
    }
    // PlayableTrack停止時実行
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        //if (obj != null)
        //    Object.Destroy(obj);
      
    }
    // PlayableTrack再生時毎フレーム実行
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        if (sceneObj != null)
            sceneObj.transform.Translate(new Vector3(0.1f, 0));
    }
}





