using UnityEngine;
using UnityEngine.UI;

namespace ScriptsInventory
{
    public class QuickSlotInventory : MonoBehaviour
    {
        public int CurrentQuickSlotID => _currentQuickSlotID;
        public Sprite ActivatedQuickSlot => _activatedQuickSlot;

        [SerializeField] private Transform _quickSlotParent;

        [SerializeField] private int _currentQuickSlotID = 0;

        [SerializeField] private Sprite _activatedQuickSlot;
        [SerializeField] private Sprite _deactivatedQuickSlot;

        private void Update()
        {
            MovingTheMouse();
            MovingTheNumbers();
        }

        private void MovingTheMouse()
        {
            float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");

            if (mouseScrollWheel > 0.1)
            {
                _quickSlotParent.GetChild(_currentQuickSlotID).GetComponent<Image>().sprite = _deactivatedQuickSlot;

                if (_currentQuickSlotID >= _quickSlotParent.childCount - 1)
                    _currentQuickSlotID = 0;

                else
                    _currentQuickSlotID++;

                _quickSlotParent.GetChild(_currentQuickSlotID).GetComponent<Image>().sprite = _activatedQuickSlot;
            }

            else if (mouseScrollWheel < -0.1)
            {
                _quickSlotParent.GetChild(_currentQuickSlotID).GetComponent<Image>().sprite = _deactivatedQuickSlot;

                if (_currentQuickSlotID <= 0)
                    _currentQuickSlotID = _quickSlotParent.childCount - 1;

                else
                    _currentQuickSlotID--;

                _quickSlotParent.GetChild(_currentQuickSlotID).GetComponent<Image>().sprite = _activatedQuickSlot;
            }
        }

        private void MovingTheNumbers()
        {
            for (int index = 0; index < _quickSlotParent.childCount; index++)
            {
                if (Input.GetKeyDown((index + 1).ToString()))
                {
                    if (_currentQuickSlotID == index)
                    {
                        if (_quickSlotParent.GetChild(_currentQuickSlotID).GetComponent<Image>().sprite == _deactivatedQuickSlot)
                            _quickSlotParent.GetChild(_currentQuickSlotID).GetComponent<Image>().sprite = _activatedQuickSlot;

                        else
                            _quickSlotParent.GetChild(_currentQuickSlotID).GetComponent<Image>().sprite = _deactivatedQuickSlot;
                    }

                    else
                    {
                        _quickSlotParent.GetChild(_currentQuickSlotID).GetComponent<Image>().sprite = _deactivatedQuickSlot;
                        _currentQuickSlotID = index;
                        _quickSlotParent.GetChild(_currentQuickSlotID).GetComponent<Image>().sprite = _activatedQuickSlot;
                    }
                }
            }
        }
    }
}