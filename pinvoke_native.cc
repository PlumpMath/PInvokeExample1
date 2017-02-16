#include <cstdint>
#include <iostream>

#if defined(_MSC_VER)
#define DLL_EXPORT extern "C" _declspec(dllexport)
#else
#define DLL_EXPORT extern "C"
#endif

struct S {
	int32_t n;
	uint8_t b;
	uint8_t reserved[3];
};
struct C {
	int32_t n;
	uint8_t b;
	uint8_t reserved[3];
};
struct C2 {
	C c;
	int32_t n;
	uint8_t b;
	uint8_t reserved[3];
};

DLL_EXPORT void Func0()
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
}

DLL_EXPORT void Func1(int n)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  n = " << n << std::endl;
	n = 456;
	std::cout << "    => " << n << std::endl;
}

DLL_EXPORT void Func2(int *p)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	std::cout << "  *p = " << *p << std::endl;
	if (p != nullptr) {
		*p = 456;
		std::cout << "    => " << *p << std::endl;
	}
}

DLL_EXPORT void Func3(int *p)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	std::cout << "  *p = " << *p << std::endl;
	if (p != nullptr) {
		*p = 456;
		std::cout << "    => " << *p << std::endl;
	}
}

DLL_EXPORT void Func4(int n)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  n = " << n << std::endl;
	n = 456;
	std::cout << "    => " << n << std::endl;
}

DLL_EXPORT void Func5(int *p)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	std::cout << "  *p = " << *p << std::endl;
	if (p != nullptr) {
		*p = 456;
		std::cout << "    => " << *p << std::endl;
	}
}

DLL_EXPORT void Func6(S s)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  s.n = " << s.n << std::endl;
	s.n = 456;
	std::cout << "    => " << s.n << std::endl;
}

DLL_EXPORT void Func7(S *p)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	if (p != nullptr) {
		std::cout << "  p->n = " << p->n << std::endl;
		p->n = 456;
		std::cout << "    => " << p->n << std::endl;
	}
}

DLL_EXPORT void Func8(S *p)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	if (p != nullptr) {
		std::cout << "  p->n = " << p->n << std::endl;
		p->n = 456;
		std::cout << "    => " << p->n << std::endl;
	}
}

DLL_EXPORT void Func9(S s)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  s.n = " << s.n << std::endl;
	s.n = 456;
	std::cout << "    => " << s.n << std::endl;
}

DLL_EXPORT void Func10(S *p)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	if (p != nullptr) {
		std::cout << "  p->n = " << p->n << std::endl;
		p->n = 678;
		std::cout << "    => " << p->n << std::endl;
		std::cout << "  p->b = " << (int)p->b << std::endl;
		p->b = 90;
		std::cout << "    => " << (int)p->b << std::endl;
	}
}

DLL_EXPORT void Func11(C *p)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	if (p != nullptr) {
		std::cout << "  p->n = " << p->n << std::endl;
		p->n = 678;
		std::cout << "    => " << p->n << std::endl;
		std::cout << "  p->b = " << (int)p->b << std::endl;
		p->b = 90;
		std::cout << "    => " << (int)p->b << std::endl;
	}
}

DLL_EXPORT void Func12(C **pp)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	std::cout << "  pp = " << pp << std::endl;
	if (pp != nullptr) {
		C *p = *pp;
		std::cout << "  p = " << p << std::endl;
		if (p != nullptr) {
			std::cout << "  p->n = " << p->n << std::endl;
			p->n = 678;
			std::cout << "    => " << p->n << std::endl;
			std::cout << "  p->b = " << (int)p->b << std::endl;
			p->b = 90;
			std::cout << "    => " << (int)p->b << std::endl;
		}
	}
}

void Func100_(C2 *c2)
{
	std::cout << "  c2 = " << c2 << std::endl;
	if (c2 != nullptr) {
		std::cout << "  c2->c.n = " << c2->c.n << std::endl;
		c2->c.n = 678;
		std::cout << "    => " << c2->c.n << std::endl;
		std::cout << "  c2->c.b = " << (int)c2->c.b << std::endl;
		c2->c.b = 90;
		std::cout << "    => " << (int)c2->c.b << std::endl;
		std::cout << "  c2->n = " << c2->n << std::endl;
		c2->n = 987;
		std::cout << "    => " << c2->n << std::endl;
		std::cout << "  c2->b = " << (int)c2->b << std::endl;
		c2->b = 65;
		std::cout << "    => " << (int)c2->b << std::endl;
	}
}

DLL_EXPORT void Func100(C2 *c2)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	Func100_(c2);
}

DLL_EXPORT void Func101(C2 *c2)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	Func100_(c2);
}

DLL_EXPORT void Func102(C2 *c2)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	Func100_(c2);
}

DLL_EXPORT void Func103(C2 *c2)
{
	std::cout << "Native: " << __FUNCTION__ << std::endl;
	Func100_(c2);
}

// Local variables:
// mode: c++
// coding: utf-8-with-signature
// c-file-style: "bsd"
// c-basic-offset: 4
// c-file-offsets: ((inextern-lang . 0)(innamespace . 0))
// indent-tabs-mode: t
// tab-width: 4
// End:
