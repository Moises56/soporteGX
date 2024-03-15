/*
				   File: type_SdtK2BTabOptions_K2BTabOptionsItem
			Description: K2BTabOptions
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
	[XmlRoot(ElementName="K2BTabOptionsItem")]
	[XmlType(TypeName="K2BTabOptionsItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BTabOptions_K2BTabOptionsItem : GxUserType
	{
		public SdtK2BTabOptions_K2BTabOptionsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Code = "";

			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Description = "";

			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Webcomponent = "";

			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Link = "";

			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Relatedtransaction = "";

		}

		public SdtK2BTabOptions_K2BTabOptionsItem(IGxContext context)
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
			AddObjectProperty("Code", gxTpr_Code, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("WebComponent", gxTpr_Webcomponent, false);


			AddObjectProperty("Link", gxTpr_Link, false);


			AddObjectProperty("ComponentType", gxTpr_Componenttype, false);


			AddObjectProperty("RelatedTransaction", gxTpr_Relatedtransaction, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public string gxTpr_Code
		{
			get {
				return gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Code; 
			}
			set {
				gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Description; 
			}
			set {
				gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="WebComponent")]
		[XmlElement(ElementName="WebComponent")]
		public string gxTpr_Webcomponent
		{
			get {
				return gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Webcomponent; 
			}
			set {
				gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Webcomponent = value;
				SetDirty("Webcomponent");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get {
				return gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Link; 
			}
			set {
				gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="ComponentType")]
		[XmlElement(ElementName="ComponentType")]
		public short gxTpr_Componenttype
		{
			get {
				return gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Componenttype; 
			}
			set {
				gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Componenttype = value;
				SetDirty("Componenttype");
			}
		}




		[SoapElement(ElementName="RelatedTransaction")]
		[XmlElement(ElementName="RelatedTransaction")]
		public string gxTpr_Relatedtransaction
		{
			get {
				return gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Relatedtransaction; 
			}
			set {
				gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Relatedtransaction = value;
				SetDirty("Relatedtransaction");
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
			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Code = "";
			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Description = "";
			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Webcomponent = "";
			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Link = "";

			gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Relatedtransaction = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Code;
		 

		protected string gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Description;
		 

		protected string gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Webcomponent;
		 

		protected string gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Link;
		 

		protected short gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Componenttype;
		 

		protected string gxTv_SdtK2BTabOptions_K2BTabOptionsItem_Relatedtransaction;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BTabOptionsItem", Namespace="test")]
	public class SdtK2BTabOptions_K2BTabOptionsItem_RESTInterface : GxGenericCollectionItem<SdtK2BTabOptions_K2BTabOptionsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BTabOptions_K2BTabOptionsItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BTabOptions_K2BTabOptionsItem_RESTInterface( SdtK2BTabOptions_K2BTabOptionsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Code", Order=0)]
		public  string gxTpr_Code
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Code);

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="Description", Order=1)]
		public  string gxTpr_Description
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Description);

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="WebComponent", Order=2)]
		public  string gxTpr_Webcomponent
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Webcomponent);

			}
			set { 
				 sdt.gxTpr_Webcomponent = value;
			}
		}

		[DataMember(Name="Link", Order=3)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="ComponentType", Order=4)]
		public short gxTpr_Componenttype
		{
			get { 
				return sdt.gxTpr_Componenttype;

			}
			set { 
				sdt.gxTpr_Componenttype = value;
			}
		}

		[DataMember(Name="RelatedTransaction", Order=5)]
		public  string gxTpr_Relatedtransaction
		{
			get { 
				return sdt.gxTpr_Relatedtransaction;

			}
			set { 
				 sdt.gxTpr_Relatedtransaction = value;
			}
		}


		#endregion

		public SdtK2BTabOptions_K2BTabOptionsItem sdt
		{
			get { 
				return (SdtK2BTabOptions_K2BTabOptionsItem)Sdt;
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
				sdt = new SdtK2BTabOptions_K2BTabOptionsItem() ;
			}
		}
	}
	#endregion
}