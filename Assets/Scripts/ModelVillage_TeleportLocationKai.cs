namespace VRTK.Examples
{
    using UnityEngine;
    public class ModelVillage_TeleportLocationKai : ModelVillage_TeleportLocation
    {

        public VRTK_HeightAdjustTeleport heightadjust;
        private bool lastUsePressedState = false;


        private void OnTriggerStay(Collider collider)
        {
            VRTK_ControllerEvents controller = (collider.GetComponent<VRTK_ControllerEvents>() ? collider.GetComponent<VRTK_ControllerEvents>() : collider.GetComponentInParent<VRTK_ControllerEvents>());
            if (controller != null)
            {
                heightadjust.enabled = true;
                if (lastUsePressedState == true && !controller.triggerPressed)
                {
                   
                    float distance = Vector3.Distance(transform.position, destination.position);
                    VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(controller.gameObject);
                    OnDestinationMarkerSet(SetDestinationMarkerEvent(distance, destination, new RaycastHit(), destination.position, controllerReference));
               
                }
                lastUsePressedState = controller.triggerPressed;
                heightadjust.enabled = false;
            }

        }


    }
}
