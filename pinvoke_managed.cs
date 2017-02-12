// 参考:
// Interop with Native Libraries | Mono
// http://www.mono-project.com/docs/advanced/pinvoke/

using System;
using System.Runtime.InteropServices;

class Program
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct S
	{
		public int n;
		public byte b;
	}
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class C
	{
		public int n;
		public byte b;
	}

	[DllImport("pinvoke_native")]
	static extern void Func0();
	[DllImport("pinvoke_native")]
	static extern void Func1(int n);
	[DllImport("pinvoke_native")]
	static extern void Func2(ref int n);
	[DllImport("pinvoke_native")]
	static extern void Func3(out int n);
	[DllImport("pinvoke_native")]
	static extern void Func4([Out] int n);
	[DllImport("pinvoke_native")]
	static extern void Func5(IntPtr n);
	[DllImport("pinvoke_native")]
	static extern void Func6(S s);
	[DllImport("pinvoke_native")]
	static extern void Func7(ref S s);
	[DllImport("pinvoke_native")]
	static extern void Func8(out S s);
	[DllImport("pinvoke_native")]
	static extern void Func9([Out] S s);
	[DllImport("pinvoke_native")]
	static extern void Func10(IntPtr ptr);

	static void Main(string[] args)
	{
		Func0();

		{
			int n = 123;
			Func1(n);
			Console.WriteLine("Managed: n = " + n);
		}

		{
			int n = 123;
			Func2(ref n);
			Console.WriteLine("Managed: n = " + n);
		}

		{
			int n = 123;
			Func3(out n);
			Console.WriteLine("Managed: n = " + n);
		}

		{
			int n = 123;
			Func4(n);
			Console.WriteLine("Managed: n = " + n);
		}

		{
			var n = 123;
			var ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(n));
			Marshal.WriteInt32(ptr, n);
			Func5(ptr);
			n = Marshal.ReadInt32(ptr);
			Marshal.FreeCoTaskMem(ptr);
			Console.WriteLine("Managed: n = " + n);
		}

		{
			var s = new S { n = 123 };
			Func6(s);
			Console.WriteLine("Managed: s.n = " + s.n);
		}

		{
			var s = new S { n = 123 };
			Func7(ref s);
			Console.WriteLine("Managed: s.n = " + s.n);
		}

		{
			var s = new S { n = 123 };
			Func8(out s);
			Console.WriteLine("Managed: s.n = " + s.n);
		}

		{
			var s = new S { n = 123 };
			Func9(s);
			Console.WriteLine("Managed: s.n = " + s.n);
		}

		{
			var s = new S { n = 123, b = 45 };
			var ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(s));
			Marshal.StructureToPtr(s, ptr, false);
			Func10(ptr);
			s = (S)Marshal.PtrToStructure(ptr, typeof(S));
			Marshal.FreeCoTaskMem(ptr);
			Console.WriteLine("Managed: s.n = " + s.n + ", s.b = " + s.b);
		}

		{
			var s = new S { n = 123, b = 45 };
			var ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(s));
			var ofs = 0;
			Marshal.WriteInt32(ptr, ofs, s.n);
			ofs += 4;
			Marshal.WriteByte(ptr, ofs, s.b);
			ofs += 1;
			Func10(ptr);
			ofs = 0;
			s.n = Marshal.ReadInt32(ptr, ofs);
			ofs += 4;
			s.b = Marshal.ReadByte(ptr, ofs);
			ofs += 1;
			Marshal.FreeCoTaskMem(ptr);
			Console.WriteLine("Managed: s.n = " + s.n + ", s.b = " + s.b);
		}
	}
}

// Local variables:
// mode: csharp
// coding: utf-8-with-signature
// indent-tabs-mode: t
// tab-width: 4
// End:
