using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00003F3D File Offset: 0x0000213D
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
