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
			var ptr = new IntPtr();
			var sz = Marshal.SizeOf(typeof(int));
			ptr = Marshal.AllocCoTaskMem(sz);
			Marshal.WriteInt32(ptr, n);
			Func5(ptr);
			n = Marshal.ReadInt32(ptr);
			Console.WriteLine("Managed: n = " + n);
		}
	}
}

// Local variables:
// mode: csharp
// coding: utf-8-with-signature
// indent-tabs-mode: t
// tab-width: 4
// End:
