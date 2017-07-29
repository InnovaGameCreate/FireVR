namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;
    using VRTK.GrabAttachMechanics;
    using VRTK.SecondaryControllerGrabActions;

    public class OpeHose : VRTK_InteractableObject
    {
        private VRTK_ControllerEvents controllerEvents;
        public int section;
        private Transform localtra;
        Animation anim ;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {          
            controllerEvents = usingObject.GetComponent<VRTK_ControllerEvents>();
          
        }
        //使用終了　トリガーを引いた
        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            controllerEvents = null;
            Destroy(GetComponent<Rigidbody>());
        }
        protected override void Awake()
        {
            base.Awake();
            anim = gameObject.GetComponent<Animation>();
        }
        protected override void Update()
        {
        
            base.Update();
           
            if (transform.localPosition.y > -2 &&section ==0 )
            { 
                Destroy(this.GetComponent<VRTK_SwapControllerGrabAction>());
                Destroy(this.GetComponent<ConfigurableJoint>());
                Destroy(this.GetComponent<VRTK_SpringJointGrabAttach>());
                Destroy(this.GetComponent<SpringJoint>());
                section = 1;
              
                anim.Play();          
            }
   
         

            GetComponent<OpeHose>().isGrabbable = true;
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