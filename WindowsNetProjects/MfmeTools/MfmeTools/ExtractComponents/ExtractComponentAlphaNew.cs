﻿using MfmeTools.JsonDataStructures;
using MfmeTools.Mfme;
using System;
using System.Collections;
using System.Collections.Generic;
using static MfmeTools.Mfme.MFMEConstants;

namespace MfmeTools.ExtractComponents
{
    [Serializable]
    public class ExtractComponentAlphaNew : ExtractComponentBase
    {
        public int Number;
        public MFMECharacterSetType CharacterSet;
        public bool Reversed;
        public ColorJSON OnColor;
        public bool SixteenSegment;

        public ExtractComponentAlphaNew(MfmeExtractor.ComponentStandardData componentStandardData) : base(componentStandardData)
        {
        }
    }

}
