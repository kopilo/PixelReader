using System;
using System.IO;
using System.Drawing;

namespace blackpixlesToList
{
	public class main
	{
		public static void Main (string[] args)
		{
			if (args.Length < 2) {
				Console.WriteLine ("Usage: imagefile filename");
				return;
			}

			Image iin = Image.FromFile (args [0]);
			string sout = readPixels (iin);
			Console.WriteLine (sout + "\n press any key to continue...");
			Console.ReadKey ();
		}

		static public void fileOut(string sout,string filename)
		{
			FileStream fs = new FileStream (filename, FileMode.Create);
			try {
				StreamWriter SW = new StreamWriter(fs);
				try{
				SW.Write(sout);
				}
				finally {
				SW.Close();
				}
			}
			finally{
				fs.Close();
			}
		}
		static public string readPixels(Image img) {
			string cout ="";
			Bitmap pixs = new Bitmap(img);
			for(int i = 0; i < img.Width; i++){
				for(int j = 0; j < img.Height; j++){
					//convert to 2bit pixels.
					Color colour = pixs.GetPixel(i,j);
					//check is not trasnparent
					if(colour.A > 128) {
						//add pixel position to array
						cout += i + "," + j + ":";
						//append colour
						if(colour.R >= 128 && colour.G >= 128 && colour.B >= 128) {
							cout += "white";
						}
						else if(colour.R < 128 && colour.G < 128 && colour.B < 128) {
							cout +="black";
						}
						else if(colour.R >= 128 && colour.G < 128 && colour.B < 128) {
							cout += "red";
						}
						else if(colour.R < 128 && colour.G >= 128 && colour.B < 128) {
							cout += "green";
						}
						else if(colour.R < 128 && colour.G < 128 && colour.B >= 128) {
							cout += "blue";
						}
						else if(colour.R >= 128 && colour.G >= 128 && colour.B < 128) {
							cout += "yellow";
						}
						else if(colour.R >= 128 && colour.G < 128 && colour.B >= 128) {
							cout += "purple";
						}
						else if (colour.R < 128 && colour.G >= 128 && colour.B >= 128) {
							cout += "cyan";
						}
						cout += '\n';
					}
				}
			}
			return cout;
		}
	}
}

