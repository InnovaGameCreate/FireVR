namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;
    using VRTK.GrabAttachMechanics;
    using VRTK.SecondaryControllerGrabActions;

    public class OpeHose : VRTK_InteractableObject
    {
        private Vector3 pos,changepos;
        private VRTK_ControllerEvents controllerEvents;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
                     controllerEvents = usingObject.GetComponent<VRTK_ControllerEvents>();
                    pos = transform.localPosition;
        }
        //使用終了　トリガーを引いた
        public override void StopUsing(VRTK_InteractUse usingObject)
        {
       
            controllerEvents = null;
        }

        protected override void Update()
        {

            base.Update();
            if (transform.localPosition.y > -2)
            { 
                Destroy(this.GetComponent<VRTK_SwapControllerGrabAction>());
                Destroy(this.GetComponent<ConfigurableJoint>());
                Destroy(this.GetComponent<VRTK_SpringJointGrabAttach>());
                Destroy(this.GetComponent<SpringJoint>());
                Destroy(this.GetComponent<VRTK_FixedJointGrabAttach>());
                GetComponent<OpeHose>().isGrabbable = true;
            }
            if (controllerEvents)
            {
    
            }
            else
            {
                if (this.GetComponent<ConfigurableJoint>() == null)
                {
                  

                }
            }
        }
    }

}