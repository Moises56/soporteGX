/*
				   File: type_SdtK2BAttributeValue_Item
			Description: K2BAttributeValue
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
	[XmlRoot(ElementName="Item")]
	[XmlType(TypeName="Item" , Namespace="test" )]
	[Serializable]
	public class SdtK2BAttributeValue_Item : GxUserType
	{
		public SdtK2BAttributeValue_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BAttributeValue_Item_Attributename = "";

			gxTv_SdtK2BAttributeValue_Item_Attributevalue = "";

		}

		public SdtK2BAttributeValue_Item(IGxContext context)
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


			AddObjectProperty("AttributeValue", gxTpr_Attributevalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AttributeName")]
		[XmlElement(ElementName="AttributeName")]
		public string gxTpr_Attributename
		{
			get {
				return gxTv_SdtK2BAttributeValue_Item_Attributename; 
			}
			set {
				gxTv_SdtK2BAttributeValue_Item_Attributename = value;
				SetDirty("Attributename");
			}
		}




		[SoapElement(ElementName="AttributeValue")]
		[XmlElement(ElementName="AttributeValue")]
		public string gxTpr_Attributevalue
		{
			get {
				return gxTv_SdtK2BAttributeValue_Item_Attributevalue; 
			}
			set {
				gxTv_SdtK2BAttributeValue_Item_Attributevalue = value;
				SetDirty("Attributevalue");
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
			gxTv_SdtK2BAttributeValue_Item_Attributename = "";
			gxTv_SdtK2BAttributeValue_Item_Attributevalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BAttributeValue_Item_Attributename;
		 

		protected string gxTv_SdtK2BAttributeValue_Item_Attributevalue;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Item", Namespace="test")]
	public class SdtK2BAttributeValue_Item_RESTInterface : GxGenericCollectionItem<SdtK2BAttributeValue_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BAttributeValue_Item_RESTInterface( ) : base()
		{	
		}

		public SdtK2BAttributeValue_Item_RESTInterface( SdtK2BAttributeValue_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AttributeName", Order=0)]
		public  string gxTpr_Attributename
		{
			get { 
				return sdt.gxTpr_Attributename;

			}
			set { 
				 sdt.gxTpr_Attributename = value;
			}
		}

		[DataMember(Name="AttributeValue", Order=1)]
		public  string gxTpr_Attributevalue
		{
			get { 
				return sdt.gxTpr_Attributevalue;

			}
			set { 
				 sdt.gxTpr_Attributevalue = value;
			}
		}


		#endregion

		public SdtK2BAttributeValue_Item sdt
		{
			get { 
				return (SdtK2BAttributeValue_Item)Sdt;
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
				sdt = new SdtK2BAttributeValue_Item() ;
			}
		}
	}
	#endregion
}