/*
				   File: type_SdtK2BT_ExtendedGridMetadata_Column_Aggregation
			Description: Aggregations
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
	[XmlRoot(ElementName="K2BT_ExtendedGridMetadata.Column.Aggregation")]
	[XmlType(TypeName="K2BT_ExtendedGridMetadata.Column.Aggregation" , Namespace="test" )]
	[Serializable]
	public class SdtK2BT_ExtendedGridMetadata_Column_Aggregation : GxUserType
	{
		public SdtK2BT_ExtendedGridMetadata_Column_Aggregation( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Caption = "";

			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Value = "";

		}

		public SdtK2BT_ExtendedGridMetadata_Column_Aggregation(IGxContext context)
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
			AddObjectProperty("Caption", gxTpr_Caption, false);


			AddObjectProperty("Value", gxTpr_Value, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Caption")]
		[XmlElement(ElementName="Caption")]
		public string gxTpr_Caption
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Caption; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Caption = value;
				SetDirty("Caption");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Value; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Value = value;
				SetDirty("Value");
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
			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Caption = "";
			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Value = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Caption;
		 

		protected string gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregation_Value;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BT_ExtendedGridMetadata.Column.Aggregation", Namespace="test")]
	public class SdtK2BT_ExtendedGridMetadata_Column_Aggregation_RESTInterface : GxGenericCollectionItem<SdtK2BT_ExtendedGridMetadata_Column_Aggregation>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BT_ExtendedGridMetadata_Column_Aggregation_RESTInterface( ) : base()
		{	
		}

		public SdtK2BT_ExtendedGridMetadata_Column_Aggregation_RESTInterface( SdtK2BT_ExtendedGridMetadata_Column_Aggregation psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Caption", Order=0)]
		public  string gxTpr_Caption
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Caption);

			}
			set { 
				 sdt.gxTpr_Caption = value;
			}
		}

		[DataMember(Name="Value", Order=1)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value);

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}


		#endregion

		public SdtK2BT_ExtendedGridMetadata_Column_Aggregation sdt
		{
			get { 
				return (SdtK2BT_ExtendedGridMetadata_Column_Aggregation)Sdt;
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
				sdt = new SdtK2BT_ExtendedGridMetadata_Column_Aggregation() ;
			}
		}
	}
	#endregion
}