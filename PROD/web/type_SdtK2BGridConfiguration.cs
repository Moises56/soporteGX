/*
				   File: type_SdtK2BGridConfiguration
			Description: K2BGridConfiguration
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
	[XmlRoot(ElementName="K2BGridConfiguration")]
	[XmlType(TypeName="K2BGridConfiguration" , Namespace="test" )]
	[Serializable]
	public class SdtK2BGridConfiguration : GxUserType
	{
		public SdtK2BGridConfiguration( )
		{
			/* Constructor for serialization */
		}

		public SdtK2BGridConfiguration(IGxContext context)
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
			AddObjectProperty("FreezeColumnTitles", gxTpr_Freezecolumntitles, false);

			if (gxTv_SdtK2BGridConfiguration_Gridcolumns != null)
			{
				AddObjectProperty("GridColumns", gxTv_SdtK2BGridConfiguration_Gridcolumns, false);
			}
			if (gxTv_SdtK2BGridConfiguration_Gridcolumnsorder != null)
			{
				AddObjectProperty("GridColumnsOrder", gxTv_SdtK2BGridConfiguration_Gridcolumnsorder, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FreezeColumnTitles")]
		[XmlElement(ElementName="FreezeColumnTitles")]
		public bool gxTpr_Freezecolumntitles
		{
			get {
				return gxTv_SdtK2BGridConfiguration_Freezecolumntitles; 
			}
			set {
				gxTv_SdtK2BGridConfiguration_Freezecolumntitles = value;
				SetDirty("Freezecolumntitles");
			}
		}




		[SoapElement(ElementName="GridColumns" )]
		[XmlArray(ElementName="GridColumns"  )]
		[XmlArrayItemAttribute(ElementName="K2BGridColumnsItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtK2BGridColumns_K2BGridColumnsItem> gxTpr_Gridcolumns_GXBaseCollection
		{
			get {
				if ( gxTv_SdtK2BGridConfiguration_Gridcolumns == null )
				{
					gxTv_SdtK2BGridConfiguration_Gridcolumns = new GXBaseCollection<GeneXus.Programs.SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumns", "");
				}
				return gxTv_SdtK2BGridConfiguration_Gridcolumns;
			}
			set {
				gxTv_SdtK2BGridConfiguration_Gridcolumns_N = false;
				gxTv_SdtK2BGridConfiguration_Gridcolumns = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtK2BGridColumns_K2BGridColumnsItem> gxTpr_Gridcolumns
		{
			get {
				if ( gxTv_SdtK2BGridConfiguration_Gridcolumns == null )
				{
					gxTv_SdtK2BGridConfiguration_Gridcolumns = new GXBaseCollection<GeneXus.Programs.SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumns", "");
				}
				gxTv_SdtK2BGridConfiguration_Gridcolumns_N = false;
				return gxTv_SdtK2BGridConfiguration_Gridcolumns ;
			}
			set {
				gxTv_SdtK2BGridConfiguration_Gridcolumns_N = false;
				gxTv_SdtK2BGridConfiguration_Gridcolumns = value;
				SetDirty("Gridcolumns");
			}
		}

		public void gxTv_SdtK2BGridConfiguration_Gridcolumns_SetNull()
		{
			gxTv_SdtK2BGridConfiguration_Gridcolumns_N = true;
			gxTv_SdtK2BGridConfiguration_Gridcolumns = null;
		}

		public bool gxTv_SdtK2BGridConfiguration_Gridcolumns_IsNull()
		{
			return gxTv_SdtK2BGridConfiguration_Gridcolumns == null;
		}
		public bool ShouldSerializegxTpr_Gridcolumns_GXBaseCollection_Json()
		{
			return gxTv_SdtK2BGridConfiguration_Gridcolumns != null && gxTv_SdtK2BGridConfiguration_Gridcolumns.Count > 0;

		}


		[SoapElement(ElementName="GridColumnsOrder" )]
		[XmlArray(ElementName="GridColumnsOrder"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Gridcolumnsorder_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtK2BGridConfiguration_Gridcolumnsorder == null )
				{
					gxTv_SdtK2BGridConfiguration_Gridcolumnsorder = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtK2BGridConfiguration_Gridcolumnsorder;
			}
			set {
				gxTv_SdtK2BGridConfiguration_Gridcolumnsorder_N = false;
				gxTv_SdtK2BGridConfiguration_Gridcolumnsorder = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Gridcolumnsorder
		{
			get {
				if ( gxTv_SdtK2BGridConfiguration_Gridcolumnsorder == null )
				{
					gxTv_SdtK2BGridConfiguration_Gridcolumnsorder = new GxSimpleCollection<string>();
				}
				gxTv_SdtK2BGridConfiguration_Gridcolumnsorder_N = false;
				return gxTv_SdtK2BGridConfiguration_Gridcolumnsorder ;
			}
			set {
				gxTv_SdtK2BGridConfiguration_Gridcolumnsorder_N = false;
				gxTv_SdtK2BGridConfiguration_Gridcolumnsorder = value;
				SetDirty("Gridcolumnsorder");
			}
		}

		public void gxTv_SdtK2BGridConfiguration_Gridcolumnsorder_SetNull()
		{
			gxTv_SdtK2BGridConfiguration_Gridcolumnsorder_N = true;
			gxTv_SdtK2BGridConfiguration_Gridcolumnsorder = null;
		}

		public bool gxTv_SdtK2BGridConfiguration_Gridcolumnsorder_IsNull()
		{
			return gxTv_SdtK2BGridConfiguration_Gridcolumnsorder == null;
		}
		public bool ShouldSerializegxTpr_Gridcolumnsorder_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BGridConfiguration_Gridcolumnsorder != null && gxTv_SdtK2BGridConfiguration_Gridcolumnsorder.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BGridConfiguration_Gridcolumns_N = true;


			gxTv_SdtK2BGridConfiguration_Gridcolumnsorder_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtK2BGridConfiguration_Freezecolumntitles;
		 
		protected bool gxTv_SdtK2BGridConfiguration_Gridcolumns_N;
		protected GXBaseCollection<GeneXus.Programs.SdtK2BGridColumns_K2BGridColumnsItem> gxTv_SdtK2BGridConfiguration_Gridcolumns = null;  
		protected bool gxTv_SdtK2BGridConfiguration_Gridcolumnsorder_N;
		protected GxSimpleCollection<string> gxTv_SdtK2BGridConfiguration_Gridcolumnsorder = null;  


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"K2BGridConfiguration", Namespace="test")]
	public class SdtK2BGridConfiguration_RESTInterface : GxGenericCollectionItem<SdtK2BGridConfiguration>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BGridConfiguration_RESTInterface( ) : base()
		{	
		}

		public SdtK2BGridConfiguration_RESTInterface( SdtK2BGridConfiguration psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="FreezeColumnTitles", Order=0)]
		public bool gxTpr_Freezecolumntitles
		{
			get { 
				return sdt.gxTpr_Freezecolumntitles;

			}
			set { 
				sdt.gxTpr_Freezecolumntitles = value;
			}
		}

		[DataMember(Name="GridColumns", Order=1, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtK2BGridColumns_K2BGridColumnsItem_RESTInterface> gxTpr_Gridcolumns
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Gridcolumns_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtK2BGridColumns_K2BGridColumnsItem_RESTInterface>(sdt.gxTpr_Gridcolumns);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Gridcolumns);
			}
		}

		[DataMember(Name="GridColumnsOrder", Order=2, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Gridcolumnsorder
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Gridcolumnsorder_GxSimpleCollection_Json())
					return sdt.gxTpr_Gridcolumnsorder;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Gridcolumnsorder = value ;
			}
		}


		#endregion

		public SdtK2BGridConfiguration sdt
		{
			get { 
				return (SdtK2BGridConfiguration)Sdt;
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
				sdt = new SdtK2BGridConfiguration() ;
			}
		}
	}
	#endregion
}