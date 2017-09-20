namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    public class FireRemove : VRTK_InteractableObject
    {
        public GameObject smoke; //煙オブジェクト
        private bool issmoking;         //煙出してるかどうか
        private GameObject rightcontroller;       //右コントローラ
        private GameObject leftcontroller;       //左コントローラ
        private GameObject sc_rightcontroller;       //スクリプト用右コントローラ
        private GameObject sc_leftcontroller;       //左コントローラ
        private int rightorleft;                //1なら右　２なら左コントローラ
        private OpeHose ope;            //OpeHoseコンポーネント格納
        private bool pulled;            //ピンを引いたかどうか
        private GameObject hose;         //hoseオブジェ
        private bool pushtouch;     //タッチボタンを押したかどうか
        public GameObject gui;      //煙残量UI（親）
        public GameObject insidegui;   //煙残量UI 内側の残量ゲージ
        public GameObject outsidegui;  //煙残量UI 外側の使用時回転オブジェ
        private AudioSource[] smokese;        //煙se     ループ間の途切れを目立たなくするために2つ用意
        private float smokepercent = 100;  //煙残量
        public UnityEngine.UI.Text guipervent;  //ui

        //使用開始　トリガーを押した
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            if (ope.section == 2 && pulled && smokepercent > 0)
            {
                base.StartUsing(usingObject);
                issmoking = true;             
                smoke.GetComponent<ParticleSystem>().Play();
                StartCoroutine(SmokeRelease());       //煙放出コールチン開始
                smokese[0].Play();          //煙効果音
                StartCoroutine(SmokeSe());          //煙効果音
                outsidegui.GetComponent<Animator>().SetTrigger("rot");
            }

        }
        //煙残量値取得
        public float get_smokepercent()
        {
            return smokepercent;
        }

        //使用終了　トリガーを引いた
        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            if (issmoking)
            {
                issmoking = false;
                base.StopUsing(usingObject);
                for (int i = 0; i < smokese.Length; i++)
                    smokese[i].Stop();
            }

        }
        //消火器をつかんだ
        public override void Grabbed(VRTK_InteractGrab currentGrabbingObject)
        {
            //掴んだコントローラが左手か右手かどうかを調べる
            if (currentGrabbingObject == sc_rightcontroller.GetComponent<VRTK_InteractGrab>())
                rightorleft = 1;
            else if (currentGrabbingObject == sc_leftcontroller.GetComponent<VRTK_InteractGrab>())
                rightorleft = 2;
            else
                rightorleft = 0;

            if (rightorleft != 0)
                // イベントハンドラの登録
                (rightorleft == 1 ? sc_rightcontroller : sc_leftcontroller).GetComponent<VRTK_ControllerEvents>().TouchpadAxisChanged += AxisChange;
            //対テレポートバグように左右のコントローラ登録
            sc_rightcontroller.GetComponent<VRTK_ControllerEvents>().TouchpadPressed += PushTouchStart;
            sc_rightcontroller.GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += PushTouchEnd;
            sc_leftcontroller.GetComponent<VRTK_ControllerEvents>().TouchpadPressed += PushTouchStart;
            sc_leftcontroller.GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += PushTouchEnd;

            GetComponent<BoxCollider>().enabled = false;        //消火器のあたり判定無効
            GetComponent<ModifyPos>().set_firstpos();           //地面貫通時に備えて位置保存
            gui.SetActive(true);
        }

        //消火器を放した
        public override void Ungrabbed(VRTK_InteractGrab currentGrabbingObject)
        {
            if (rightorleft != 0)
                // イベントハンドラの登録
                (rightorleft == 1 ? sc_rightcontroller : sc_leftcontroller).GetComponent<VRTK_ControllerEvents>().TouchpadAxisChanged -= AxisChange;

            sc_rightcontroller.GetComponent<VRTK_ControllerEvents>().TouchpadPressed -= PushTouchStart;
            sc_rightcontroller.GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd -= PushTouchEnd;
            sc_leftcontroller.GetComponent<VRTK_ControllerEvents>().TouchpadPressed -= PushTouchStart;
            sc_leftcontroller.GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd -= PushTouchEnd;
            GetComponent<BoxCollider>().enabled = true;     //消火器のあたり判定有効
            gui.SetActive(false);
            smoke.GetComponent<ParticleSystem>().Stop();
            outsidegui.GetComponent<Animator>().SetTrigger("stop");
            for(int i=0;i < smokese.Length;i++)
            smokese[i].Stop();

        }
        //初期化
        protected override void Awake()
        {
            base.Awake();
            hose = transform.Find("Hose").gameObject;
            ope = hose.GetComponent<OpeHose>();
            rightcontroller = GameObject.Find("/[VRTK_SDKManager] /SDKSetups/SteamVR/[CameraRig]/Controller (right)");
            leftcontroller = GameObject.Find("/[VRTK_SDKManager] /SDKSetups/SteamVR/[CameraRig]/Controller (left)");
            sc_rightcontroller = GameObject.Find("/[VRTK_Scripts] /RightController");
            sc_leftcontroller = GameObject.Find("/[VRTK_Scripts] /LeftController");
            smokese = GetComponents<AudioSource>();
     
        }


        // 煙発生コルーチン  
        IEnumerator SmokeSe()
        {

                yield return new WaitForSeconds(2);
            smokese[1].Play();
        }

        // 煙発生コルーチン  
        IEnumerator SmokeRelease()
        {
            while (issmoking && smokepercent > 0)
            {
                if (rightorleft == 0)
                    break;
                SteamVR_TrackedObject trackedObject = (rightorleft == 1 ? rightcontroller : leftcontroller).GetComponent<SteamVR_TrackedObject>();
                var device = SteamVR_Controller.Input((int)trackedObject.index);
                device.TriggerHapticPulse(2000);        //コントローラの振動
                smokepercent -= 0.1f;
                insidegui.GetComponent<Image>().fillAmount -= 0.001f;       //内側uiゲージ計算
                guipervent.color = new Color(1, smokepercent / 100, smokepercent / 100);    //残量が減ると赤くなる文字
                guipervent.text = "Smoke: " + ((int)smokepercent).ToString() + " %";    //文字

                yield return new WaitForSeconds(0.01f);
            }


            smoke.GetComponent<ParticleSystem>().Stop();
            outsidegui.GetComponent<Animator>().SetTrigger("stop");
        }

        protected override void Update()
        {
            base.Update();
            //ホース・ピンのセッティングが終わったらuiの文字を%残量表示に変更
            if (ope.section == 2)
                guipervent.text = "Smoke: " + ((int)smokepercent).ToString() + " %";
        }
        // タッチパネルのフリック　　消火器のピンを抜く
        private void AxisChange(object sender, ControllerInteractionEventArgs e)
        {
            GetComponent<Animator>().SetTrigger("PullPin");
            pulled = true;
        }

        // タッチパネルボタンを押す　　瞬間移動時にホースの configulable jointで消火器が吹っ飛ぶためホースを一時的に非アクティブ化
        private void PushTouchStart(object sender, ControllerInteractionEventArgs e)
        {
            hose.SetActive(false);
            pushtouch = true;
        }

        // タッチパネルと触れなくなった  ホースをアクティブ化　configulable jointの位置等初期化
        private void PushTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            if (pushtouch && ope.section != 2)
            {
                hose.SetActive(true);
                hose.transform.localPosition = new Vector3(0.11f, -1.25f, 0.93f);
                hose.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                hose.GetComponent<ConfigurableJoint>().connectedAnchor = new Vector3(0.1100016f, -1.25f, 1.18f);
                pushtouch = false;
            }
        }
    }
}