namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;
    using VRTK.GrabAttachMechanics;
    using VRTK.SecondaryControllerGrabActions;

    public class OpeHose : VRTK_InteractableObject
    {
        private VRTK_ControllerEvents controllerEvents;
        public int section;                  // section = 0)未開放  1)解放アニメーション中　　2)解放完了
        Animator anim ;                 //アニメーターコンポーネント
        public GameObject prehose;      //ホース解放し終わったときに消す　接続部

        //初期化
        protected override void Awake()
        {
            base.Awake();
            anim = gameObject.GetComponent<Animator>();  
        }
        //使用開始　トリガーをひいた
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
        
            controllerEvents = usingObject.GetComponent<VRTK_ControllerEvents>();

        }
        //使用終了　トリガーを放した
        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            controllerEvents = null;
            Destroy(this.GetComponent<Rigidbody>());
            base.StopUsing(usingObject);
        }
        //非アクティブ化時の処理
        protected override void OnDisable()
        {
            base.OnDisable();
            Destroy(this.GetComponent<Rigidbody>());
            if (section == 2)
            {
                //ホースが抜けているとき　掴んで話したとき位置を中央前方に初期化
                transform.localPosition = GetComponent<StopPosition>().localtra;
                transform.localRotation = GetComponent<StopPosition>().localrad;
            }
        }

        protected override void Update()
        {
        
            base.Update();
      //ホースが抜けていないとき　ローカルy座標が一定値を超えると　ホースが抜けるアニメーション開始
            if (transform.localPosition.y > -0.1f &&section ==0 )
            {
            
                prehose.SetActive(false);   //つながっている部分を消す     
                //joint削除等によるy性質変化　
                Destroy(this.GetComponent<VRTK_SwapControllerGrabAction>());
                Destroy(this.GetComponent<ConfigurableJoint>());
                Destroy(this.GetComponent<VRTK_SpringJointGrabAttach>());
                Destroy(this.GetComponent<SpringJoint>());
                anim.SetTrigger("Hose");
                section = 1;             
            }
            if (section == 2)   
                GetComponent<Animator>().enabled = false;       //アニメーター無効無効
         

            GetComponent<OpeHose>().isGrabbable = true;         //ホース解放機能の中では常にgrabbableを回さないとなぜか掴めないため
          
        }
    }

}