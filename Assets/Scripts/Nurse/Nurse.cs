using GOAP;

namespace Nurse
{
    public class Nurse : GAgent
    {
        protected override void Start()
        {
            base.Start();
            SubGoal s1 = new SubGoal("sortPatient", 1, false);
            goals.Add(s1, 3);
        }
    }
}