using UnityEngine;

namespace Towny
{
    public class Warrior : MonoBehaviour
    {
        public void RecruitWarriorOnClick()
        {            
            Recruitment.Instance._squad.Add("Warrior");
        }
    }
}
