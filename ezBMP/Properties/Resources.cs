using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ezBitmapConverter.Properties
{
	// Token: 0x02000003 RID: 3
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class Resources
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00003E8F File Offset: 0x0000208F
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00003E9C File Offset: 0x0000209C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("ezBitmapConverter.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00003EE8 File Offset: 0x000020E8
		// (set) Token: 0x06000011 RID: 17 RVA: 0x00003EFF File Offset: 0x000020FF
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400001A RID: 26
		private static ResourceManager resourceMan;

		// Token: 0x0400001B RID: 27
		private static CultureInfo resourceCulture;
	}
}
