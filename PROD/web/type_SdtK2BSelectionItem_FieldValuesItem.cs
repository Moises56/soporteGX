/*
				   File: type_SdtK2BSelectionItem_FieldValuesItem
			Description: FieldValues
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
	[XmlRoot(ElementName="K2BSelectionItem.FieldValuesItem")]
	[XmlType(TypeName="K2BSelectionItem.FieldValuesItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BSelectionItem_FieldValuesItem : GxUserType
	{
		public SdtK2BSelectionItem_FieldValuesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BSelectionItem_FieldValuesItem_Name = "";

			gxTv_SdtK2BSelectionItem_FieldValuesItem_Value = "";

			gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue = "";
			gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue_gxi = "";
		}

		public SdtK2BSelectionItem_FieldValuesItem(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Value", gxTpr_Value, false);


			AddObjectProperty("ImageValue", gxTpr_Imagevalue, false);
			AddObjectProperty("ImageValue_GXI", gxTpr_Imagevalue_gxi, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtK2BSelectionItem_FieldValuesItem_Name; 
			}
			set {
				gxTv_SdtK2BSelectionItem_FieldValuesItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtK2BSelectionItem_FieldValuesItem_Value; 
			}
			set {
				gxTv_SdtK2BSelectionItem_FieldValuesItem_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="ImageValue")]
		[XmlElement(ElementName="ImageValue")]
		[GxUpload()]

		public string gxTpr_Imagevalue
		{
			get {
				return gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue; 
			}
			set {
				gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue = value;
				SetDirty("Imagevalue");
			}
		}


		[SoapElement(ElementName="ImageValue_GXI" )]
		[XmlElement(ElementName="ImageValue_GXI" )]
		public string gxTpr_Imagevalue_gxi
		{
			get {
				return gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue_gxi ;
			}
			set {
				gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue_gxi = value;
				SetDirty("Imagevalue_gxi");
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
			gxTv_SdtK2BSelectionItem_FieldValuesItem_Name = "";
			gxTv_SdtK2BSelectionItem_FieldValuesItem_Value = "";
			gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue = "";gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue_gxi = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BSelectionItem_FieldValuesItem_Name;
		 

		protected string gxTv_SdtK2BSelectionItem_FieldValuesItem_Value;
		 
		protected string gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue_gxi;
		protected string gxTv_SdtK2BSelectionItem_FieldValuesItem_Imagevalue;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BSelectionItem.FieldValuesItem", Namespace="test")]
	public class SdtK2BSelectionItem_FieldValuesItem_RESTInterface : GxGenericCollectionItem<SdtK2BSelectionItem_FieldValuesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BSelectionItem_FieldValuesItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BSelectionItem_FieldValuesItem_RESTInterface( SdtK2BSelectionItem_FieldValuesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Value", Order=1)]
		public  string gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="ImageValue", Order=2)]
		[GxUpload()]
		public  string gxTpr_Imagevalue
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Imagevalue)) ? PathUtil.RelativePath( sdt.gxTpr_Imagevalue) : StringUtil.RTrim( sdt.gxTpr_Imagevalue_gxi));

			}
			set { 
				 sdt.gxTpr_Imagevalue = value;
			}
		}


		#endregion

		public SdtK2BSelectionItem_FieldValuesItem sdt
		{
			get { 
				return (SdtK2BSelectionItem_FieldValuesItem)Sdt;
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
				sdt = new SdtK2BSelectionItem_FieldValuesItem() ;
			}
		}
	}
	#endregion
}