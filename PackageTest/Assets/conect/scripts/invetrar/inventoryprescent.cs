
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

    public class inventoryprescent : MonoBehaviour, IDragHandler,IEndDragHandler,IBeginDragHandler
{   [SerializeField] private Text _nameFeild;
    [SerializeField] private Image _iconFeild;
    private Transform _draggingParent;
    private Transform _originalParent;
    public void Render (Items item)
    { _nameFeild.text =item.Name;
     _iconFeild.sprite =item.UIIcon;

    }
    public void Init (Transform draggingParent)
    { _draggingParent = draggingParent; 
      _originalParent = draggingParent;

    }
    public void OnBeginDrag(PointerEventData eventData)
    { transform.parent=_draggingParent;

    }
    public void OnDrag(PointerEventData eventData)
    { transform.position=Input.mousePosition;

    }
    public void OnEndDrag(PointerEventData eventData)
    { int Closesindex=0;
      for(int i = 0; i<_originalParent.transform.childCount; i++) 
      {if(Vector3.Distance(transform.position,_originalParent.GetChild(i).position)
       <Vector3.Distance(transform.position,_originalParent.GetChild(Closesindex).position))
       {Closesindex=i;

       }
        
      }
      transform.parent=_originalParent;
      transform.SetSiblingIndex(Closesindex);

    }

}

    


        

    

    
