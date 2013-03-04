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
			Console.WriteLine (sout);
			FileStream fs = new FileStream (args[1], FileMode.Create);
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

			Console.ReadKey ();
			
		}

		static public string readPixels(Image img) {
			string cout ="";
			Bitmap pixs = new Bitmap(img);
			for(int i = 0; i < img.Width; i++){
				for(int j = 0; j < img.Height; j++){
					//Console.WriteLine(i +","+ j + "::" + pixs.GetPixel (i,j));
					// 20 is an arbitrary value and subject to your opinion and need.
					if(pixs.GetPixel(i,j) == Color.FromArgb(255,0,0,0)) {
						cout += i + "," + j + '\n';
					}
				}
			}
			return cout;
		}
	}
}

