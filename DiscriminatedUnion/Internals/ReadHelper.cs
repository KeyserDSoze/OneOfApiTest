﻿using System.Text.Json;

namespace System
{
    internal abstract class ReadHelper
    {
        public abstract object Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options);
    }
}
