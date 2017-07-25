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
        public VRTK_InteractUse sc_rightcontroller;       //スクリプト用右コントローラ
        public VRTK_InteractUse sc_leftcontroller;       //左コントローラ
        private int rightorleft;                //1なら右　２なら左コントローラ
        //使用開始　トリガーを押した
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            issmoking = true;
            base.StartUsing(usingObject);
            if (usingObject == sc_rightcontroller)
                rightorleft = 1;
            else if(usingObject == sc_leftcontroller)
                rightorleft = 2;
            else
                rightorleft = 0;
            smoke.GetComponent<ParticleSystem>(). Play();
            StartCoroutine(Sample());
        }
        //使用終了　トリガーを引いた
        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            issmoking = false;
            base.StopUsing(usingObject);
            smoke.GetComponent<ParticleSystem>().Stop();
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

    }
}