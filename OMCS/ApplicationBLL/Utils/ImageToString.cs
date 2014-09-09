using System;
using System.Drawing;

namespace ApplicationBLL.Utils
{
	/// <summary>
	/// Converts an Image to a Base64-String and back
	/// </summary>
	public class ImageToString
	{
		/// <summary>
		/// Converts an Image to a Base64-String
		/// </summary>
		/// <param name="image">
		/// Image to convert
		/// </param>
		/// <returns>
		/// Base64 representation of the Image
		/// </returns>
		public static string GetStringFromImage(Image image)
		{
			if (image != null)
			{
				ImageConverter ic = new ImageConverter();
				byte[] buffer = (byte[])ic.ConvertTo(image, typeof(byte[]));
				return Convert.ToBase64String(
					buffer,
					Base64FormattingOptions.InsertLineBreaks);
			}
			else
				return null;
		}
		//---------------------------------------------------------------------
		/// <summary>
		/// Converts a Base64-String to an Image
		/// </summary>
		/// <param name="base64String">
		/// String to convert
		/// </param>
		/// <returns>
		/// Image created from the String
		/// </returns>
		public static Image GetImageFromString(string base64String)
		{
			byte[] buffer = Convert.FromBase64String(base64String);

			if (buffer != null)
			{
				ImageConverter ic = new ImageConverter();
				return ic.ConvertFrom(buffer) as Image;
			}
			else
				return null;
		}
	}
}
