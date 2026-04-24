using System;
using System.Collections.Generic;
using NetSerializer;

namespace Robust.Shared.Serialization
{
    /// <summary>
    ///     A wrapper for a list that serializes as an array.
    /// </summary>
    [Serializable, NetSerializable]
    public readonly struct NetListAsArray<T>
    {
        public readonly T[] Value;

        public int Count => Value?.Length ?? 0;

        public bool HasContents => Value != null && Value.Length > 0;

        public ReadOnlySpan<T> Span => new ReadOnlySpan<T>(Value);

        public NetListAsArray(T[] value)
        {
            Value = value;
        }

        public NetListAsArray(List<T> value)
        {
            Value = value.ToArray();
        }

        public static implicit operator NetListAsArray<T>(T[] value)
        {
            return new NetListAsArray<T>(value);
        }

        public static implicit operator NetListAsArray<T>(List<T> value)
        {
            return new NetListAsArray<T>(value);
        }

        public static implicit operator T[](NetListAsArray<T> wrapper)
        {
            return wrapper.Value;
        }
    }
}
