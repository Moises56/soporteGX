/*
				   File: type_SdtK2BPersistedMenuOutput
			Description: K2BPersistedMenuOutput
				 Author: Nemo 🐠 for C# version 18.0.5.175581
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="K2BPersistedMenuOutput")]
	[XmlType(TypeName="K2BPersistedMenuOutput" , Namespace="test" )]
	[Serializable]
	public class SdtK2BPersistedMenuOutput : GxUserType
	{
		public SdtK2BPersistedMenuOutput( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BPersistedMenuOutput_Menucode = "";

		}

		public SdtK2BPersistedMenuOutput(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("MenuCode", gxTpr_Menucode, false);

			if (gxTv_SdtK2BPersistedMenuOutput_Persistedmenu != null)
			{
				AddObjectProperty("PersistedMenu", gxTv_SdtK2BPersistedMenuOutput_Persistedmenu, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MenuCode")]
		[XmlElement(ElementName="MenuCode")]
		public string gxTpr_Menucode
		{
			get {
				return gxTv_SdtK2BPersistedMenuOutput_Menucode; 
			}
			set {
				gxTv_SdtK2BPersistedMenuOutput_Menucode = value;
				SetDirty("Menucode");
			}
		}




		[SoapElement(ElementName="PersistedMenu" )]
		[XmlArray(ElementName="PersistedMenu"  )]
		[XmlArrayItemAttribute(ElementName="K2BMultiLevelPersistedMenuItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> gxTpr_Persistedmenu_GXBaseCollection
		{
			get {
				if ( gxTv_SdtK2BPersistedMenuOutput_Persistedmenu == null )
				{
					gxTv_SdtK2BPersistedMenuOutput_Persistedmenu = new GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem>( context, "K2BMultiLevelPersistedMenu", "");
				}
				return gxTv_SdtK2BPersistedMenuOutput_Persistedmenu;
			}
			set {
				gxTv_SdtK2BPersistedMenuOutput_Persistedmenu_N = false;
				gxTv_SdtK2BPersistedMenuOutput_Persistedmenu = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> gxTpr_Persistedmenu
		{
			get {
				if ( gxTv_SdtK2BPersistedMenuOutput_Persistedmenu == null )
				{
					gxTv_SdtK2BPersistedMenuOutput_Persistedmenu = new GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem>( context, "K2BMultiLevelPersistedMenu", "");
				}
				gxTv_SdtK2BPersistedMenuOutput_Persistedmenu_N = false;
				return gxTv_SdtK2BPersistedMenuOutput_Persistedmenu ;
			}
			set {
				gxTv_SdtK2BPersistedMenuOutput_Persistedmenu_N = false;
				gxTv_SdtK2BPersistedMenuOutput_Persistedmenu = value;
				SetDirty("Persistedmenu");
			}
		}

		public void gxTv_SdtK2BPersistedMenuOutput_Persistedmenu_SetNull()
		{
			gxTv_SdtK2BPersistedMenuOutput_Persistedmenu_N = true;
			gxTv_SdtK2BPersistedMenuOutput_Persistedmenu = null;
		}

		public bool gxTv_SdtK2BPersistedMenuOutput_Persistedmenu_IsNull()
		{
			return gxTv_SdtK2BPersistedMenuOutput_Persistedmenu == null;
		}
		public bool ShouldSerializegxTpr_Persistedmenu_GXBaseCollection_Json()
		{
			return gxTv_SdtK2BPersistedMenuOutput_Persistedmenu != null && gxTv_SdtK2BPersistedMenuOutput_Persistedmenu.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BPersistedMenuOutput_Menucode = "";

			gxTv_SdtK2BPersistedMenuOutput_Persistedmenu_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BPersistedMenuOutput_Menucode;
		 
		protected bool gxTv_SdtK2BPersistedMenuOutput_Persistedmenu_N;
		protected GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> gxTv_SdtK2BPersistedMenuOutput_Persistedmenu = null;  


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"K2BPersistedMenuOutput", Namespace="test")]
	public class SdtK2BPersistedMenuOutput_RESTInterface : GxGenericCollectionItem<SdtK2BPersistedMenuOutput>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BPersistedMenuOutput_RESTInterface( ) : base()
		{	
		}

		public SdtK2BPersistedMenuOutput_RESTInterface( SdtK2BPersistedMenuOutput psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MenuCode", Order=0)]
		public  string gxTpr_Menucode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Menucode);

			}
			set { 
				 sdt.gxTpr_Menucode = value;
			}
		}

		[DataMember(Name="PersistedMenu", Order=1, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_RESTInterface> gxTpr_Persistedmenu
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Persistedmenu_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_RESTInterface>(sdt.gxTpr_Persistedmenu);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Persistedmenu);
			}
		}


		#endregion

		public SdtK2BPersistedMenuOutput sdt
		{
			get { 
				return (SdtK2BPersistedMenuOutput)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtK2BPersistedMenuOutput() ;
			}
		}
	}
	#endregion
}