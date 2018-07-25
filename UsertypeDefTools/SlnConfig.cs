using Dev;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UsertypeDefTools
{
	[Serializable]
	public class SlnConfig : Singleton<SlnConfig>
	{
		[XmlAttribute]
		public string AliasPath;

		[XmlAttribute]
		public string EntityDefDir;

		[XmlAttribute]
		public string EntitiesPath;

		public static bool Initialize(string dir)
		{
			if( !Directory.Exists( dir ) )
			{
				MessageBox.Show( string.Format( "Directory '{0}' is not exist", dir ) );
				return false;
			}

			var configFile = Path.Combine( dir, "ToolsConfig.xml" );

			if( File.Exists( configFile ) )
			{
				//var content = File.ReadAllText( configFile );
				//s_config = new ConfigParser<SlnConfig>( content ).Config;

				FileStream f = new FileStream( configFile, FileMode.OpenOrCreate );
				XmlSerializer x = new XmlSerializer( typeof( SlnConfig ) );
				Instance = (SlnConfig)x.Deserialize( f );
				f.Close();
				return true;
			}

			Instance = new SlnConfig();

			Instance.AliasPath = Path.Combine( dir, @"scripts\entity_defs\types.xml" );
			Instance.EntityDefDir = Path.Combine( dir, @"scripts\entity_defs" );
			Instance.EntitiesPath = Path.Combine( dir, @"scripts\entities.xml" );

			if( !Instance.Validate() )
			{
				MessageBox.Show("Please select the Ouro asset directory");
				return false;
			}

			XmlSerializer xml = new XmlSerializer( typeof( SlnConfig ) );
			FileStream fileStream = new FileStream( configFile, FileMode.OpenOrCreate );
			xml.Serialize( fileStream, Instance );
			fileStream.Close();
			return true;
		}

		private bool Validate()
		{
			return File.Exists( AliasPath ) &&
				   Directory.Exists( EntityDefDir ) &&
				   File.Exists( EntitiesPath );
		}

		protected override void Init()
		{
		}

		public string DefaultPath
		{
			get
			{
				string path = Path.Combine( Environment.GetEnvironmentVariable( "OURO_ROOT" ), "assets" );
				Log.Debug( "path {0}", path );
				return path;
			}
		}
	}
}
