using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageTools
{
	public class ImageResizer
	{
		/// <summary>
		/// Adapted from https://www.hanselman.com/blog/how-do-you-use-systemdrawing-in-net-core
		/// </summary>
		/// <param name="filePath">Original file path.</param>
		/// <param name="width">Resize to width in pixels.</param>
		/// <param name="height">Resize to height in pixels.</param>
		/// <returns>Resized file path.</returns>
		// [Breaking change]: System.Drawing.Common no longer supported on non-Windows OSs. See https://github.com/dotnet/docs/issues/25257
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
		public string Resize(string filePath, int width, int height)
		{
			using var pngStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			using var image = new Bitmap(pngStream);
			var resized = new Bitmap(width, height);
			using var graphics = Graphics.FromImage(resized);
			graphics.CompositingQuality = CompositingQuality.HighSpeed;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.CompositingMode = CompositingMode.SourceCopy;
			graphics.DrawImage(image, 0, 0, width, height);

			string newFilePath = $"{filePath}.resized.png";
			resized.Save(newFilePath, ImageFormat.Png);
			return newFilePath;
		}
	}
}