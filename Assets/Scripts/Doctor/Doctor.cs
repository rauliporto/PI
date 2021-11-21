
using GOAP;

namespace Doctor
{
    public class Doctor : GAgent
    {
        protected override void Start()
        {
            base.Start();
            SubGoal s1 = new SubGoal("treatPatient", 1, false);
            goals.Add(s1, 3);
        }
    }
}