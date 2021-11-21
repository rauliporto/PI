using GOAP;

namespace Patient {
    
    public class GoToReception : GAction {
        
        public override bool PrePerform() {
            target = inventory.FindItemWithTag("Reception");
            if (target == null)
                return false;
            return true;
        }

        public override bool PostPerform() {
            GWorld.Instance.AddReception(target);
            inventory.RemoveItem(target);
            GWorld.Instance.GetWorld().ModifyState("FreeReception", 1);
            return true;
        }
    }
}
