﻿using System;
using System.Runtime.InteropServices;

namespace ShellLinkApi.Structures
{
	public class SafeCoTaskMemHandle : SafeHandle
	{
		#region Construction
		public SafeCoTaskMemHandle()
			: base(IntPtr.Zero, true)
		{
		}
		#endregion Construction

		#region Overrides
		public override bool IsInvalid
		{
			get { return base.handle == IntPtr.Zero; }
		}

		protected override bool ReleaseHandle()
		{
			// QUESTION: Should we set the handle back to zero afterward?
			Marshal.FreeCoTaskMem(base.handle);
			return true;
		}
		#endregion Overrides
	}
}
