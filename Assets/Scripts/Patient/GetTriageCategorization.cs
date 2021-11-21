using UnityEngine;
using UnityEngine.AI;
namespace GOAP
{
    public class GetTriageCategorization : GAction
    {
        public override bool PrePerform()
        {
            target = inventory.FindItemWithTag("Cubicle");
            this.gameObject.GetComponent<NavMeshAgent>().updatePosition = true;
            if (target == null)
                return false;
            return true;
        }
        public override bool PostPerform()
        {
            GWorld.Instance.GetWorld().ModifyState("PrioritizePatient", -1);
            GWorld.Instance.GetWorld().ModifyState("HasPrioritization", 1);

            if (gameObject.transform.GetChild(0).childCount > 0)
            {
                for (var i = 0; i < gameObject.transform.GetChild(0).childCount; i++)
                {
                    gameObject.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                }
            }
            
            inventory.RemoveItem(target);
            return true;
        }
    }
}