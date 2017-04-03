using System;
using System.Runtime.InteropServices;

namespace ShellLinkApi.Structures
{
    public struct StringData
    {
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Marshalers.StringDataMarshaler))]
        public string Value;
    }

    namespace Marshalers
    {
        internal class StringDataMarshaler : ICustomMarshaler
        {
            private string _cookie;
            private int _nativeDataSize;

            private StringDataMarshaler(string cookie)
            {
                _cookie = cookie;
            }

            public static ICustomMarshaler GetInstance(string cookie)
            {
                return new StringDataMarshaler(cookie);
            }

            public void CleanUpManagedData(object ManagedObj)
            {
            }

            public void CleanUpNativeData(IntPtr pNativeData)
            {
                Marshal.FreeCoTaskMem(pNativeData);
            }

            public int GetNativeDataSize()
            {
                return _nativeDataSize;
            }

            public IntPtr MarshalManagedToNative(object ManagedObj)
            {
                var managedString = ManagedObj as string;
                if  (managedString == null)
                {
                    return IntPtr.Zero;
                }

                if (managedString.Length > ushort.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(ManagedObj),
                        managedString.Length, $"Length must be less that 0x{ushort.MaxValue.ToString("X4")}");
                }

                var nativeStringData = Marshal.AllocCoTaskMem(sizeof(ushort) + managedString.Length * sizeof(char));

                Marshal.WriteInt16(nativeStringData, (short)managedString.Length);
                nativeStringData += sizeof(short);

                foreach (var character in managedString)
                {
                    Marshal.WriteInt16(nativeStringData, character);
                    nativeStringData += sizeof(char);
                }

                return nativeStringData;
            }

            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
                var size = (ushort)Marshal.ReadInt16(pNativeData);
                _nativeDataSize = sizeof(ushort) + size * sizeof(char);
                return Marshal.PtrToStringUni(pNativeData + sizeof(ushort), size);
            }
        }
    }
}
