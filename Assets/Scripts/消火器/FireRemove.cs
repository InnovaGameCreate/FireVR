namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;

    public class FireRemove : VRTK_InteractableObject
    {
        public GameObject smoke; //煙オブジェクト
        private bool issmoking;         //煙出してるかどうか
        public GameObject rightcontroller;       //右コントローラ
        public GameObject leftcontroller;       //左コントローラ
        public GameObject sc_rightcontroller;       //スクリプト用右コントローラ
        public GameObject sc_leftcontroller;       //左コントローラ
        private int rightorleft;                //1なら右　２なら左コントローラ
        private OpeHose ope;
        private bool pulled;
        private GameObject hose;         //hoseオブジェ
        private bool pushtouch;     //タッチボタンを押したかどうか

        //使用開始　トリガーを押した
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            if (ope.section == 2&&pulled)
            {
                issmoking = true;
                base.StartUsing(usingObject);
                smoke.GetComponent<ParticleSystem>().Play();
                StartCoroutine(Sample());
            }
         
        }
        //使用終了　トリガーを引いた
        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            if (issmoking)
            {
                issmoking = false;
                base.StopUsing(usingObject);
                smoke.GetComponent<ParticleSystem>().Stop();
            }
          
        }

        public override void Grabbed(VRTK_InteractGrab currentGrabbingObject)
        {
            if (currentGrabbingObject == sc_rightcontroller.GetComponent< VRTK_InteractGrab>())
                rightorleft = 1;
            else if (currentGrabbingObject == sc_leftcontroller.GetComponent<VRTK_InteractGrab>())
                rightorleft = 2;
            else
                rightorleft = 0;

            if (rightorleft != 0)
                // イベントハンドラの登録
                (rightorleft == 1 ? sc_rightcontroller : sc_leftcontroller).GetComponent<VRTK_ControllerEvents>().TouchpadAxisChanged += PushButton;
            (rightorleft == 1 ? sc_rightcontroller : sc_leftcontroller).GetComponent<VRTK_ControllerEvents>().TouchpadPressed += PushTouchStart;
            (rightorleft == 1 ? sc_rightcontroller : sc_leftcontroller).GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += PushTouchEnd;
            GetComponent<BoxCollider>().enabled = false;
        }

        public override void Ungrabbed(VRTK_InteractGrab currentGrabbingObject)
        {
            if (rightorleft != 0)
                // イベントハンドラの登録
                (rightorleft == 1 ? sc_rightcontroller : sc_leftcontroller).GetComponent<VRTK_ControllerEvents>().TouchpadAxisChanged -= PushButton;
            (rightorleft == 1 ? sc_rightcontroller : sc_leftcontroller).GetComponent<VRTK_ControllerEvents>().TouchpadPressed -= PushTouchStart;
            (rightorleft == 1 ? sc_rightcontroller : sc_leftcontroller).GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd -= PushTouchEnd;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<ModifyPos>().set_firstpos();
        }
        protected override void Awake()
        {
            base.Awake();
            hose = transform.Find("Hose").gameObject;
            ope = hose.GetComponent<OpeHose>();
        }

        // 煙発生コルーチン  
        IEnumerator Sample()
        {
            while (issmoking)
            {
                if (rightorleft == 0)
                    break;
                SteamVR_TrackedObject trackedObject =(rightorleft == 1? rightcontroller: leftcontroller).GetComponent<SteamVR_TrackedObject>();
                var device = SteamVR_Controller.Input((int)trackedObject.index);
                device.TriggerHapticPulse(2000);
                yield return new WaitForSeconds(0.01f);
            }

        }

        // イベントハンドラ
        private void PushButton(object sender, ControllerInteractionEventArgs e)
        {
            GetComponent<Animator>().SetTrigger("PullPin");
            pulled = true;
        }

        // イベントハンドラ
        private void PushTouchStart(object sender, ControllerInteractionEventArgs e)
        {
            hose.SetActive(false);
            pushtouch = true;
        }

        // イベントハンドラ
        private void PushTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            if (pushtouch)
            {
                hose.SetActive(true);
                hose.transform.localPosition = new Vector3(0.11f, -1.25f, 0.93f);
                hose.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
                hose.GetComponent<ConfigurableJoint>().connectedAnchor = new Vector3(0.1100016f, -1.25f, 1.18f);
                pushtouch = false;
            }
        }
    }
}