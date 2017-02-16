using System;
using System.Runtime.InteropServices;

class Program
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct S
	{
		public int n;
		public byte b;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		byte[] reserved;
	}
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class C
	{
		public int n;
		public byte b;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		byte[] reserved;
	}
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class C2
	{
		public C c;
		public int n;
		public byte b;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		byte[] reserved;
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
	[DllImport("pinvoke_native")]
	static extern void Func11(C c);
	[DllImport("pinvoke_native")]
	static extern void Func12(ref C c);
	[DllImport("pinvoke_native")]
	static extern void Func100(C2 c2);
	[DllImport("pinvoke_native")]
	static extern void Func101([In] C2 c2);
	[DllImport("pinvoke_native")]
	static extern void Func102([Out] C2 c2);
	[DllImport("pinvoke_native")]
	static extern void Func103([In, Out] C2 c2);

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

		{
			var c = new C { n = 123, b = 45 };
			Func11(c);
			Console.WriteLine("Managed: c.n = " + c.n + ", c.b = " + c.b);
		}

		{
			var c = new C { n = 123, b = 45 };
			Func12(ref c);
			Console.WriteLine("Managed: c.n = " + c.n + ", c.b = " + c.b);
		}

		{
			var c2 = new C2 { c = new C { n = 123, b = 45 }, n = 678, b = 90 };
			Func100(c2);
			Console.WriteLine("Managed: c2.c.n = " + c2.c.n + ", c2.c.b = " + c2.c.b + ", c2.n = " + c2.n + ", c2.b = " + c2.b);
		}

		{
			var c2 = new C2 { c = new C { n = 123, b = 45 }, n = 678, b = 90 };
			Func101(c2);
			Console.WriteLine("Managed: c2.c.n = " + c2.c.n + ", c2.c.b = " + c2.c.b + ", c2.n = " + c2.n + ", c2.b = " + c2.b);
		}

		{
			var c2 = new C2 { c = new C { n = 123, b = 45 }, n = 678, b = 90 };
			Func102(c2);
			Console.WriteLine("Managed: c2.c.n = " + c2.c.n + ", c2.c.b = " + c2.c.b + ", c2.n = " + c2.n + ", c2.b = " + c2.b);
		}

		{
			var c2 = new C2 { c = new C { n = 123, b = 45 }, n = 678, b = 90 };
			Func103(c2);
			Console.WriteLine("Managed: c2.c.n = " + c2.c.n + ", c2.c.b = " + c2.c.b + ", c2.n = " + c2.n + ", c2.b = " + c2.b);
		}
	}
}

// Local variables:
// mode: csharp
// coding: utf-8-with-signature
// indent-tabs-mode: t
// tab-width: 4
// End:
