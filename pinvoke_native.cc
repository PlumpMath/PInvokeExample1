#include <iostream>

#define DLL_EXPORT extern "C"

struct S {
	int n;
	uint8_t b;
};
class C {
	int n;
	uint8_t b;
};

DLL_EXPORT void Func0()
{
	std::cout << "Native: " << __PRETTY_FUNCTION__ << std::endl;
}

DLL_EXPORT void Func1(int n)
{
	std::cout << "Native: " << __PRETTY_FUNCTION__ << std::endl;
	std::cout << "  n = " << n << std::endl;
	n = 456;
	std::cout << "    => " << n << std::endl;
}

DLL_EXPORT void Func2(int *p)
{
	std::cout << "Native: " << __PRETTY_FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	std::cout << "  *p = " << *p << std::endl;
	if (p != nullptr) {
		*p = 456;
		std::cout << "    => " << *p << std::endl;
	}
}

DLL_EXPORT void Func3(int *p)
{
	std::cout << "Native: " << __PRETTY_FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	std::cout << "  *p = " << *p << std::endl;
	if (p != nullptr) {
		*p = 456;
		std::cout << "    => " << *p << std::endl;
	}
}

DLL_EXPORT void Func4(int n)
{
	std::cout << "Native: " << __PRETTY_FUNCTION__ << std::endl;
	std::cout << "  n = " << n << std::endl;
	n = 456;
	std::cout << "    => " << n << std::endl;
}

DLL_EXPORT void Func5(int *p)
{
	std::cout << "Native: " << __PRETTY_FUNCTION__ << std::endl;
	std::cout << "  p = " << p << std::endl;
	std::cout << "  *p = " << *p << std::endl;
	if (p != nullptr) {
		*p = 456;
		std::cout << "    => " << *p << std::endl;
	}
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
