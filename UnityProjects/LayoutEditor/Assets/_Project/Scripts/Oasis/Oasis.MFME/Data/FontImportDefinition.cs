using Oasis.Data;
using UnityEngine;

namespace Oasis.MFME.Data
{
    [CreateAssetMenu(fileName = "FontImportDefinition", menuName = "Oasis/Data/FontImportDefinition")]
    public class FontImportDefinition : DefinitionBase
    {
        public float OasisCharacterSpacing;
        public float OasisLineSpacing;

        // TODO check if need paragraph spacing?
    }
}
