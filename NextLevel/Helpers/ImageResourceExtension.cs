using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextLevel.Helpers
{
	[ContentProperty("Source")]
	public class ImageResourceExtension : IMarkupExtension<ImageSource>
	{
		public string Source { set; get; }
		public ImageSource ProvideValue(IServiceProvider serviceProvider)
		{
			throw new NotImplementedException();
		}

		object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
		{
			throw new NotImplementedException();
		}
	}
}
