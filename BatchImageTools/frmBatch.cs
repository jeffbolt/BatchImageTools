using Svg;

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BatchImageTools
{
	public partial class frmBatch : Form
	{
		public frmBatch()
		{
			InitializeComponent();

			// Enable drag & drop https://stackoverflow.com/questions/68598/how-do-i-drag-and-drop-files-into-an-application
			this.AllowDrop = true;
			this.DragEnter += new DragEventHandler(frmBatch_DragEnter);
			this.DragDrop += new DragEventHandler(frmBatch_DragDrop);
		}

		private void frmBatch_Load(object sender, EventArgs e)
		{
			// TODO: Resize column widths

			// Load convert to formats
			cmbFormat.Items.Clear();
			cmbFormat.Items.Add("PNG - Portable Network Graphics (*.png)");
			cmbFormat.SelectedIndex = 0;
			
			//cmbFormat.Items.Add(new ListViewItem
			//{
			//	Tag = "PNG",
			//	Text = "PNG - Portable Network Graphics (*.png)"
			//});
		}

		void frmBatch_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}

		private void frmBatch_DragDrop(object sender, DragEventArgs e)
		{
			// https://stackoverflow.com/questions/8550937/c-sharp-drag-and-drop-files-to-form
			// https://stackoverflow.com/questions/729090/c-how-to-add-subitems-in-listview
			// https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
			// https://www.c-sharpcorner.com/uploadfile/mahesh/understanding-message-box-in-windows-forms-using-C-Sharp/
			try
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
					foreach (string filePath in filePaths)
					{
						if (File.Exists(filePath))
						{
							var fi = new FileInfo(filePath);

							switch (fi.Extension.ToLower())
							{
								case ".svg":
									// https://stackoverflow.com/questions/58910/
									try
									{
										var svg = SvgDocument.Open(filePath);
										if (svg != null)
										{
											var item = new ListViewItem
											{
												Text = filePath
											};
											item.SubItems.Add(svg.Height.ToString() + " px");
											item.SubItems.Add(svg.Width.ToString() + " px");
											item.SubItems.Add(GetFileSizeSuffix(fi.Length));
											lvwImages.Items.Add(item);
										}
									}
									catch
									{
										string message = string.Format("Could not read SVG image information for {0}.", filePath);
										MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
									}
									break;
								default:
									try
									{
										var bmp = new Bitmap(filePath);
										if (bmp != null)
										{
											var item = new ListViewItem
											{
												Text = filePath
											};
											item.SubItems.Add(bmp.Height.ToString("N0") + " px");
											item.SubItems.Add(bmp.Width.ToString("N0") + " px");
											item.SubItems.Add(GetFileSizeSuffix(fi.Length));
											lvwImages.Items.Add(item);
										}
									}
									catch
									{
										string message = string.Format("Could not read bitmap image information for {0}.", filePath);
										MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
									}
									break;
							}
						}

						// Code to read the contents of the text file
						//if (File.Exists(fileLoc))
						//	using (TextReader tr = new StreamReader(fileLoc))
						//	{
						//		Console.WriteLine(tr.ReadToEnd());
						//	}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private string GetFileSizeSuffix(long value, int decimalPlaces = 1)
		{
			// https://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc#14488941
			string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

			if (decimalPlaces < 0) throw new ArgumentOutOfRangeException("decimalPlaces");

			if (value < 0) return "-" + GetFileSizeSuffix(-value, decimalPlaces);
			if (value == 0) return string.Format("{0:n" + decimalPlaces + "} bytes", 0);

			// mag is 0 for bytes, 1 for KB, 2, for MB, etc.
			int mag = (int)Math.Log(value, 1024);

			// 1L << (mag * 10) == 2 ^ (10 * mag) 
			// [i.e. the number of bytes in the unit corresponding to mag]
			decimal adjustedSize = (decimal)value / (1L << (mag * 10));

			// make adjustment when the value is large enough that
			// it would round up to 1000 or more
			if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
			{
				mag += 1;
				adjustedSize /= 1024;
			}

			return string.Format("{0:n" + decimalPlaces + "} {1}", adjustedSize, SizeSuffixes[mag]);
		}

		private bool SvgToPng(string inputPath)
		{
			// https://github.com/svg-net/SVG/blob/master/Samples/SVGViewer/SvgViewer.cs
			// https://stackoverflow.com/questions/58910/converting-svg-to-png-using-c-sharp#12884409
			try
			{
				SvgDocument svgDoc = SvgDocument.Open(inputPath);

				if (svgDoc != null)
				{
					var fi = new FileInfo(inputPath);
					string outputPath = string.Concat(inputPath.TrimEnd(fi.Extension.ToCharArray()), ".png");
					using (var bitmap = svgDoc.Draw())
					{
						// TOOD: Fix poor quality image with codecs
						var imageCodecs = ImageCodecInfo.GetImageEncoders();
						ImageCodecInfo codecInfo = imageCodecs.FirstOrDefault(x => x.FormatDescription == "PNG");
						var parameters = new EncoderParameters(1);
						/*
							ChrominanceTable	f2e455dc-09b3-4316-8260-676ada32481c
							ColorDepth			66087055-ad66-4c7c-9a18-38a2310b8337
							Compression			e09d739d-ccd4-44ee-8eba-3fbf8be4fc58
							LuminanceTable		edb33bce-0266-4a77-b904-27216099e717
							Quality				1d5be4b5-fa4a-452d-9cdd-5db35105e7eb
							RenderMethod		6d42c53a-229a-4825-8bb7-5c99e2b9a8b8
							SaveFlag			292266fc-ac40-47bf-8cfc-a85b89a655de
							ScanMethod			3a4e2661-3109-4e56-8536-42c156e7dcfa
							Transformation		8d0eb2d1-a58e-4ea8-aa14-108074b7b6f9
							Version				24d18c76-814a-41a4-bf53-1c219cccf797
						*/

						var compressionEncoder = new System.Drawing.Imaging.Encoder(new Guid("e09d739d-ccd4-44ee-8eba-3fbf8be4fc58"));
						parameters.Param[0] = new EncoderParameter(compressionEncoder, (long)10);  // set to 10% ?
						
						bitmap?.Save(outputPath, codecInfo, parameters);
					}
				}

				//string xml = svgDoc.GetXML();
				//var byteArray = Encoding.ASCII.GetBytes(svgDoc.Content.ToCharArray());
				//using (var stream = new MemoryStream(byteArray))
				//{
				//	var svgDocument = SvgDocument.Open(path);
				//	var bitmap = svgDocument.Draw();
				//	bitmap.Save(path, ImageFormat.Png);
				//}

				//var svgDoc = SvgDocument.Open(path);
				//var svgFileContents = svgDoc.ToString();
				//var byteArray = Encoding.ASCII.GetBytes(svgFileContents);
				//using (var stream = new MemoryStream(byteArray))
				//{
				//	var svgDocument = SvgDocument.Open(path);
				//	var bitmap = svgDocument.Draw();
				//	bitmap.Save(path, ImageFormat.Png);
				//}
				//var svgFileContents = svgDoc.ToString();
				//var byteArray = Encoding.ASCII.GetBytes(svgFileContents);
				//using (var stream = new MemoryStream(byteArray))
				//{
				//	var svgDocument = SvgDocument.Open(stream);
				//	var bitmap = svgDocument.Draw();
				//	bitmap.Save(path, ImageFormat.Png);
				//}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return false;
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (ListViewItem itm in lvwImages.SelectedItems)
				{
					string filePath = itm.Text;
					if (File.Exists(filePath))
					{
						var fi = new FileInfo(filePath);

						switch (fi.Extension)
						{
							case ".svg":
								switch (cmbFormat.SelectedItem.ToString().Substring(0, 3))
								{
									case "PNG":
										SvgToPng(filePath);
									break;
								}
								break;
						}

					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
