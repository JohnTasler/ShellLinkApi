using System;

namespace ShellLinkApi.Structures
{
    public static partial class Constants
    {
        public const uint LinkHeaderSize = 0x0000004C;
        public static readonly Guid LinkHeaderCLSID = new Guid("00021401-0000-0000-C000-000000000046");

        public enum DataBlockSignature : uint
        {
            Console             = 0xA0000002,
            ConsoleFE           = 0xA0000004,
            Darwin              = 0xA0000006,
            EnvironmentVariable = 0xA0000001,
            IconEnvironment     = 0xA0000007,
            KnownFolder         = 0xA000000B,
            PropertyStore       = 0xA0000009,
            Shim                = 0xA0000008,
            SpecialFolder       = 0xA0000005,
            Tracker             = 0xA0000003,
            VistaAndAboveIDList = 0xA000000C,
        }

        public enum DataBlockSize : uint
        {
            Console                    = 0x000000CC,
            ConsoleFE                  = 0x0000000C,
            Darwin                     = 0x00000314,
            EnvironmentVariable        = 0x00000314,
            IconEnvironment            = 0x00000314,
            KnownFolder                = 0x0000001C,
            PropertyStoreMinimum       = 0x0000000C,
            ShimDataMinimum            = 0x00000088,
            SpecialFolder              = 0x00000010,
            Tracker                    = 0x00000060,
            VistaAndAboveIDListMinimum = 0x0000000A,
        }

        /// <summary>
        /// The expected window state of an application launched by the link.
        /// </summary>
        public enum ShowCommand : uint
        {
            Normal = 1,
            Maximized = 3,
            Minimized = 7,
        }

        /// <summary>
        /// Specifies a virtual key code that corresponds to a key on the keyboard.
        /// </summary>
        public enum HotKeys : byte
        {
            Number0 = 0x30, Number1 = 0x31, Number2 = 0x32, Number3 = 0x33, Number4 = 0x34,
            Number5 = 0x35, Number6 = 0x36, Number7 = 0x37, Number8 = 0x38, Number9 = 0x39,
            A = 0x41, B = 0x42, C = 0x43, D = 0x44, E = 0x45, F = 0x46,
            G = 0x47, H = 0x48, I = 0x49, J = 0x4A, K = 0x4B, L = 0x4C, M = 0x4D,
            N = 0x4E, O = 0x4F, P = 0x50, Q = 0x51, R = 0x52, S = 0x53,
            T = 0x54, U = 0x55, V = 0x56, W = 0x57, X = 0x58, Y = 0x59, Z = 0x5A,
            F1 = 0x70, F2 = 0x71, F3 = 0x72, F4 = 0x73, F5 = 0x74, F6 = 0x75,
            F7 = 0x76, F8 = 0x77, F9 = 0x78, F10 = 0x79, F11 = 0x7A, F12 = 0x7B,
            F13 = 0x7C, F14 = 0x7D, F15 = 0x7E, F16 = 0x7F, F17 = 0x80, F18 = 0x81,
            F19 = 0x82, F20 = 0x83, F21 = 0x84, F22 = 0x85, F23 = 0x86, F24 = 0x87,
            NumLock = 0x90, ScrollLock = 0x91,
        }

        /// <summary>
        /// Modifier keys on the keyboard.
        /// </summary>
        [Flags]
        public enum HotKeyModifiers : byte
        {
            None = 0x0,
            Shift = 0x1,
            Ctrl = 0x2,
            Alt = 0x4,
        }
    }
}
