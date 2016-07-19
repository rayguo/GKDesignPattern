using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;


namespace Sudoku
{
	/// <summary>
	/// Summary description for BoardDescription.
	/// </summary>
	/// 
	[XmlRoot("Sudoku", Namespace=BoardDescription.NAMESPACE ,
		 IsNullable = false)]

	public class BoardDescription
	{
		public const string		NAMESPACE="uri://beaconsoft.co.uk/sudoku";

		public 	const string	VERSION = "1.00";

		public class Cell
		{
			public int			x;
			public int			y;
			public int			val;
			public bool			constant;
		}

		public BoardDescription()
		{
			version = VERSION;
            layout = new List<Cell>();

		}

		[XmlElement( "Version") ]
		public string				version;

		[XmlElement( "Width")]
		public int				    boxWidth;

		[XmlElement( "Height")]
		public int					boxHeight;

		[XmlArray("Cells")]
		public List<Cell>			layout;

		
	}
}
