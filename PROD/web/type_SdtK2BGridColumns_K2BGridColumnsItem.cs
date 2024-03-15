/*
				   File: type_SdtK2BGridColumns_K2BGridColumnsItem
			Description: K2BGridColumns
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
	[XmlRoot(ElementName="K2BGridColumnsItem")]
	[XmlType(TypeName="K2BGridColumnsItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BGridColumns_K2BGridColumnsItem : GxUserType
	{
		public SdtK2BGridColumns_K2BGridColumnsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Attributename = "";

			gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Columntitle = "";

		}

		public SdtK2BGridColumns_K2BGridColumnsItem(IGxContext context)
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
			AddObjectProperty("AttributeName", gxTpr_Attributename, false);


			AddObjectProperty("ShowAttribute", gxTpr_Showattribute, false);


			AddObjectProperty("ColumnTitle", gxTpr_Columntitle, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AttributeName")]
		[XmlElement(ElementName="AttributeName")]
		public string gxTpr_Attributename
		{
			get {
				return gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Attributename; 
			}
			set {
				gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Attributename = value;
				SetDirty("Attributename");
			}
		}




		[SoapElement(ElementName="ShowAttribute")]
		[XmlElement(ElementName="ShowAttribute")]
		public bool gxTpr_Showattribute
		{
			get {
				return gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Showattribute; 
			}
			set {
				gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Showattribute = value;
				SetDirty("Showattribute");
			}
		}




		[SoapElement(ElementName="ColumnTitle")]
		[XmlElement(ElementName="ColumnTitle")]
		public string gxTpr_Columntitle
		{
			get {
				return gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Columntitle; 
			}
			set {
				gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Columntitle = value;
				SetDirty("Columntitle");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Attributename = "";

			gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Columntitle = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Attributename;
		 

		protected bool gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Showattribute;
		 

		protected string gxTv_SdtK2BGridColumns_K2BGridColumnsItem_Columntitle;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BGridColumnsItem", Namespace="test")]
	public class SdtK2BGridColumns_K2BGridColumnsItem_RESTInterface : GxGenericCollectionItem<SdtK2BGridColumns_K2BGridColumnsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BGridColumns_K2BGridColumnsItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BGridColumns_K2BGridColumnsItem_RESTInterface( SdtK2BGridColumns_K2BGridColumnsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AttributeName", Order=0)]
		public  string gxTpr_Attributename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Attributename);

			}
			set { 
				 sdt.gxTpr_Attributename = value;
			}
		}

		[DataMember(Name="ShowAttribute", Order=1)]
		public bool gxTpr_Showattribute
		{
			get { 
				return sdt.gxTpr_Showattribute;

			}
			set { 
				sdt.gxTpr_Showattribute = value;
			}
		}

		[DataMember(Name="ColumnTitle", Order=2)]
		public  string gxTpr_Columntitle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Columntitle);

			}
			set { 
				 sdt.gxTpr_Columntitle = value;
			}
		}


		#endregion

		public SdtK2BGridColumns_K2BGridColumnsItem sdt
		{
			get { 
				return (SdtK2BGridColumns_K2BGridColumnsItem)Sdt;
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
				sdt = new SdtK2BGridColumns_K2BGridColumnsItem() ;
			}
		}
	}
	#endregion
}