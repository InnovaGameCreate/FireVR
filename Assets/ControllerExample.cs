using UnityEngine;

public class ControllerExample : MonoBehaviour
{
    public GameObject controller;
    ParticleSystem smoke;           //煙パーティクルコンポーネント
    private bool issmoking;         //煙出してるかどうか
    private void Start()
    {
        smoke = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        SteamVR_TrackedObject trackedObject = controller.GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("トリガーを浅く引いた");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("トリガーを深く引いた");
            if (!issmoking)
                smoke.Play();
            issmoking = true;
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("トリガーを離した");
            smoke.Stop();
            issmoking = false;
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("タッチパッドをクリックした");
        }
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("タッチパッドをクリックしている");
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("タッチパッドをクリックして離した");
        }
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("タッチパッドに触った");
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("タッチパッドを離した");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            Debug.Log("メニューボタンをクリックした");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log("グリップボタンをクリックした");
        }

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("トリガーを浅く引いている");
        }
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("トリガーを深く引いている");
        }
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Debug.Log("タッチパッドに触っている");
        }
    }
}