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
    public class PanelProjectSettings : PanelBase
    {
        public FieldString MameRomName;
        public UI.Fields.FieldEnum FruitMachinePlatform;

        protected override void Awake()
        {
            base.Awake();

            AddListeners();
        }

        protected void Start()
        {
            Initialise();
            Populate();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        // JP TODO note this is all just initial testing code of how we will make our own 'BoundInputField'
        // generic processing behaviour:
        private void AddListeners()
        {
            MameRomName.Input.OnValueChanged += OnMameRomNameValueChanged;
            MameRomName.Input.OnValueSubmitted += OnMameRomNameEndEdit;

            FruitMachinePlatform.Dropdown.onValueChanged.AddListener(OnFruitMachinePlatformValueChanged);
        }

        private void RemoveListeners()
        {
            MameRomName.Input.OnValueChanged -= OnMameRomNameValueChanged;
            MameRomName.Input.OnValueSubmitted -= OnMameRomNameEndEdit;

            FruitMachinePlatform.Dropdown.onValueChanged.RemoveListener(OnFruitMachinePlatformValueChanged);
        }

        private void Initialise()
        {
            InitialiseFruitMachinePlatformDropdown();
        }

        private void InitialiseFruitMachinePlatformDropdown()
        {
            FruitMachinePlatform.Setup(typeof(MameController.PlatformType));
        }

        private void Populate()
        {
            MameRomName.Input.Text = Editor.Instance.Project.Settings.Mame.RomName;

            FruitMachinePlatform.Dropdown.value =
                (int)Editor.Instance.Project.Settings.FruitMachine.Platform;
        }

        // TODO temp - will be doing an equivalent of the 'BoundInputField' approach used
        // by the Inspector was using for UI prototyping
        private bool OnMameRomNameValueChanged(BoundInputField source, string value)
        {
            Editor.Instance.Project.Settings.Mame.RomName = value;

            return true;
        }

        private bool OnMameRomNameEndEdit(BoundInputField source, string value)
        {
            Editor.Instance.Project.Settings.Mame.RomName = value;

            return true;
        }

        private void OnFruitMachinePlatformValueChanged(int value)
        {
            Editor.Instance.Project.Settings.FruitMachine.Platform =
                (MameController.PlatformType)value;
        }

    }

}
