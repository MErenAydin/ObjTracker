using System;

namespace ObjTracker
{
	[Flags]
	enum Command : byte
	{
		None = 0x00,

		MoveForward = 0x01,
		MoveBackward = 0x02,
		MoveRight = 0x04,
		MoveLeft = 0x08,
		MoveAuto = 0x0F,

		CamUp = 0x10,
		CamDown = 0x20,
		CamRight = 0x40,
		CamLeft = 0x80,
		CamAuto = 0xF0,

		AutoPilot = 0xFF,
	}
}
