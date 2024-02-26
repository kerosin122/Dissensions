using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using UnityEngine;



    
     
     
     [CreateAssetMenu(menuName = "itmes")]
     public class AssetItem : ScriptableObject,Items
     { public string Name => _name;
     public Sprite UIIcon => _uiIcon;
     [SerializeField] private string _name;
     [SerializeField] private   Sprite _uiIcon;

     }
    
   
