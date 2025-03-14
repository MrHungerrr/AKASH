﻿using Vkimow.Serializators.XML;
using System;
using System.Collections.Generic;

namespace GOAP
{
    public interface IGOAPStateStorage : IGOAPStateReadOnlyStorage, IXMLSerializable
    {
        void Clear();
        void Set(string key, object value);
        void Set(string key, GOAPState state);
        void Set(KeyValuePair<string, GOAPState> state);
    }
}
