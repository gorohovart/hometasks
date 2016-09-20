#include "stdafx.h"
#include "Medved.h"

int main(array<System::String ^> ^args)
{
	Medved^ medved = gcnew Medved();
	medved->MeetMedved();
	return 0;
}