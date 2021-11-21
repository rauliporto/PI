using GOAP;
using UnityEngine;

namespace Patient
{
    public class GoToHospital : GAction {
        
        private GameObject resource;

        public override bool PostPerform() {
            resource = GWorld.Instance.RemoveReception();
            if (resource != null) {
                inventory.AddItem(resource);
            } else {
                GWorld.Instance.GetWorld().ModifyState("FreeReception", 0);
            }
        
            //GWorld.Instance.GetWorld().ModifyState("FreeReception", -1);
            
            return true;
        }

        public override bool PrePerform() {
            return true;
        }
    }
}
