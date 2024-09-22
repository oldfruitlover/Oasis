using Oasis.LayoutEditor.Tools;
using Oasis.MAME;
using Oasis.UI;
using Oasis.UI.Fields;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Oasis.LayoutEditor.Panels
{
    public abstract class PanelInspector : PanelBase
    {
        public EditorComponent EditorComponent
        {
            get;
            set;
        }

        public Layout.Component Component
        {
            get
            {
                return EditorComponent.Component;
            }
        }


        // suspect there will be some generic inspector stuff that can go in here, equivalent 
        // to Unity's gameObject name, tag, layer etc
    }
}
