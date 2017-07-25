using UnityEngine;
using VRTK;

public class ControllerExample : MonoBehaviour
{
    public GameObject controller;       //コントローラ
    ParticleSystem smoke;           //煙パーティクルコンポーネント
    private bool issmoking;         //煙出してるかどうか

    private void OnEnable()
    {
     
        if (controller.GetComponent<VRTK_ControllerEvents>() == null)
            return;
        // イベントハンドラの登録
        controller.GetComponent<VRTK_ControllerEvents>().TriggerPressed += TriggerPressedHandler;
        controller.GetComponent<VRTK_ControllerEvents>().TriggerReleased += TriggerReleasedHandler;
    }

    private void OnDisable()
    {
        if (controller.GetComponent<VRTK_ControllerEvents>() == null)
            return;
        // イベントハンドラの解除
        controller.GetComponent<VRTK_ControllerEvents>().TriggerPressed -= TriggerPressedHandler;
        controller.GetComponent<VRTK_ControllerEvents>().TriggerReleased -= TriggerReleasedHandler;
    }

    private void TriggerPressedHandler(object sender, ControllerInteractionEventArgs e)
    {
        if (!issmoking)
            smoke.Play();
        issmoking = true;
     
    }

    private void TriggerReleasedHandler(object sender, ControllerInteractionEventArgs e)
    {
        smoke.Stop();
        issmoking = false;

    }

    private void Start()
    {
        smoke = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        
    }
}