namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;
    public class OpeHose : VRTK_InteractableObject
    {
        private Transform pos;
        private VRTK_ControllerEvents controllerEvents;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
                     controllerEvents = usingObject.GetComponent<VRTK_ControllerEvents>();
         
        }
        //使用終了　トリガーを引いた
        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            controllerEvents = null;
        }

        protected override void Update()
        {
            base.Update();
            if (controllerEvents)
            {
                Debug.Log(base.trackPoint);
            }
            else
            {
               
            }
        }
    }

}