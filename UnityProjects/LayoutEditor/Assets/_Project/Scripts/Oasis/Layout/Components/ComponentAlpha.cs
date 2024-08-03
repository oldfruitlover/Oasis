using System.Collections.Generic;

namespace Oasis.Layout
{
    public class ComponentAlpha : Component, SerializableDictionary 
    {
        private bool _reversed = false;
        public bool Reversed
        {
            get => _reversed;
            set { _reversed = value; base.OnValueSetInvoke(); }
        }

        public override void SetRepresentation(Dictionary<string, object> representation) 
        {
            base.SetRepresentation(representation);

            if ((string)representation["type"] != GetType().Name) 
            {
                return;
            }
        }

        public override Dictionary<string, object> GetRepresentation() 
        {
            Dictionary<string, object> representation = base.GetRepresentation();

            representation["type"] = GetType().Name;
            representation["is_reversed"] = _reversed ? "true" : "false";

            return representation;
        }
    }
}
