using Oasis.Graphics;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Oasis.Layout
{
    // TODO: Why is a lamp a ComponentInput when ComponentSwitch and ComponentButton are not?
    public class ComponentLamp : ComponentInput, SerializableDictionary
    {
        private int? _number = null;
        public int? Number
        {
            get => _number;
            set { _number = value; base.OnValueSetInvoke(); }
        }

        private Color _onColor = Color.blue;
        public Color OnColor
        {
            get => _onColor;
            set { _onColor = value; base.OnValueSetInvoke(); }
        }

        private Color _offColor = Color.black;
        public Color OffColor
        {
            get => _offColor;
            set { _offColor = value; base.OnValueSetInvoke(); }
        }

        private Color _textColor = Color.white;
        public Color TextColor
        {
            get => _textColor;
            set { _textColor = value; base.OnValueSetInvoke(); }
        }

        public OasisImage OasisImage;

        private bool _outline = true;
        public bool Outline
        {
            get => _outline;
            set { _outline = value; base.OnValueSetInvoke(); }
        }

        public override void SetRepresentation(Dictionary<string, object> representation) 
        {
            base.SetRepresentation(representation);

            if ((string)representation["type"] != GetType().Name) 
            {
                return;
            }

            foreach (KeyValuePair<string, object> field in representation) 
            {
                switch(field.Key) 
                {
                    case "number":
                        int.TryParse((string)field.Value, out int number);
                        _number = number;
                        break;
                    case "onColor":
                        // TODO implement Color encode/decode text format
                        Debug.LogWarning("TODO implement Color encode/decode text format");
                        break;
                    case "offColor":
                        // TODO implement Color encode/decode text format
                        Debug.LogWarning("TODO implement Color encode/decode text format");
                        break;
                    case "textColor":
                        // TODO implement Color encode/decode text format
                        Debug.LogWarning("TODO implement Color encode/decode text format");
                        break;
                    case "outline":
                        _outline = (string)field.Value == "true";
                        break;
                }
            }
        }

        public override Dictionary<string, object> GetRepresentation() 
        {
            Dictionary<string, object> representation = base.GetRepresentation();
            representation["type"] = GetType().Name;
            representation["number"] = _number;
            representation["outline"] = _outline;
            representation["on_color"] = "#" + ColorUtility.ToHtmlStringRGB(OnColor);
            representation["off_color"] = "#" + ColorUtility.ToHtmlStringRGB(OffColor);
            representation["text_color"] = "#" + ColorUtility.ToHtmlStringRGB(TextColor);
            representation["file_path"] = null;
            if (OasisImage != null) {
                representation["file_path"] =  Component.GetComponentKey(representation) + ".png";
                ImageOperations.SaveToPNG(OasisImage, (string) representation["file_path"]);
            }
            return representation;
        }
    }

}
