using ConsoleTables;
using System.Runtime.InteropServices;

namespace SpartaDungeon
{
	class Program
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

		static void Init()
		{
			IntPtr consoleWindow = GetConsoleWindow();
			// 윈도우 11부터는 변환이 안되서 하위버전 호환용으로 120, 30으로 고정합니다
			MoveWindow(consoleWindow, 100, 100, 120, 30, true);
		}
		static void Main()
		{
			Init();
			SceneManager sceneManager = new SceneManager();
			sceneManager.Init();

			State state = State.Main;
			while (state != State.None)
			{
				sceneManager.ProcessScene(state);
				state = sceneManager.Update();
			}
		}
	}
}