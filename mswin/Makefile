all: pinvoke_managed.exe pinvoke_native.dll

clean:
	DEL pinvoke_managed.exe
	DEL pinvoke_native.dll pinvoke_native.obj pinvoke_native.lib pinvoke_native.exp

pinvoke_managed.exe: pinvoke_managed.cs
	csc /nologo pinvoke_managed.cs

pinvoke_native.dll: pinvoke_native.cc
	cl /nologo /W4 /LDd /EHsc /TP pinvoke_native.cc
