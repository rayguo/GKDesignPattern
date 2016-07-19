using System;
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Sudoku
{
	/// <summary>
	/// Summary description for BoardSerializer.
	/// </summary>
	public class BoardSerializer
	{
		
		private BoardSerializer()
		{
			// Static class
		}

	    public static Board DeSerialize( string filename)
		{
            BasicBoard board = null;

            using (Stream stream = File.Open(filename, FileMode.Open))
            {

                XmlSerializer reader = new XmlSerializer(typeof(BoardDescription));

                stream.Position = 0;

                BoardDescription boardDescription = (BoardDescription)reader.Deserialize(stream);

                board = new BasicBoard(boardDescription);
            }

			return board;
		}

	}
}
