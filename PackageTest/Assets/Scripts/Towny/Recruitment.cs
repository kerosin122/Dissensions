using UnityEngine;
using System.Collections.Generic;

namespace Towny
{
    public class Recruitment : MonoBehaviour
    {
        [SerializeField] private GameObject _townPanelUI;
        [SerializeField] private GameObject _militaryPanelUI;

        public static Recruitment Instance;
        public List<string> _squad = new();

        private void Awake() => Instance = GetComponent<Recruitment>();

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
                _townPanelUI.SetActive(true);
        }

        public void OpenWarriorPanelOnClick() => _militaryPanelUI.SetActive(true);

        public void ExitTownOnClick() => _townPanelUI.SetActive(false);
        public void ExitWarriorOnClick() => _militaryPanelUI.SetActive(false);
    }
}