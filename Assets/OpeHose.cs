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
        Animator anim ;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
      
            controllerEvents = usingObject.GetComponent<VRTK_ControllerEvents>();
          
        }
        //使用終了　トリガーを引いた
        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            controllerEvents = null;
            Destroy(this.GetComponent<Rigidbody>());
        }
        protected override void Awake()
        {
            base.Awake();
            anim = gameObject.GetComponent<Animator>();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Destroy(this.GetComponent<Rigidbody>());
            if (section == 2)
            {
                transform.localPosition = GetComponent<StopPosition>().localtra;
                transform.localRotation = GetComponent<StopPosition>().localrad;
            }
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
                anim.SetTrigger("Hose");
                section = 1;                
            }
            if (section == 2)
                GetComponent<Animator>().enabled = false;
         

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