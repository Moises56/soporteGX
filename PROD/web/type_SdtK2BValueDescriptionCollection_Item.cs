/*
				   File: type_SdtK2BValueDescriptionCollection_Item
			Description: K2BValueDescriptionCollection
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
	public class SdtK2BValueDescriptionCollection_Item : GxUserType
	{
		public SdtK2BValueDescriptionCollection_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BValueDescriptionCollection_Item_Value = "";

			gxTv_SdtK2BValueDescriptionCollection_Item_Description = "";

		}

		public SdtK2BValueDescriptionCollection_Item(IGxContext context)
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
			AddObjectProperty("Value", gxTpr_Value, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("CanBeDeleted", gxTpr_Canbedeleted, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtK2BValueDescriptionCollection_Item_Value; 
			}
			set {
				gxTv_SdtK2BValueDescriptionCollection_Item_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtK2BValueDescriptionCollection_Item_Description; 
			}
			set {
				gxTv_SdtK2BValueDescriptionCollection_Item_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="CanBeDeleted")]
		[XmlElement(ElementName="CanBeDeleted")]
		public bool gxTpr_Canbedeleted
		{
			get {
				return gxTv_SdtK2BValueDescriptionCollection_Item_Canbedeleted; 
			}
			set {
				gxTv_SdtK2BValueDescriptionCollection_Item_Canbedeleted = value;
				SetDirty("Canbedeleted");
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
			gxTv_SdtK2BValueDescriptionCollection_Item_Value = "";
			gxTv_SdtK2BValueDescriptionCollection_Item_Description = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BValueDescriptionCollection_Item_Value;
		 

		protected string gxTv_SdtK2BValueDescriptionCollection_Item_Description;
		 

		protected bool gxTv_SdtK2BValueDescriptionCollection_Item_Canbedeleted;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Item", Namespace="test")]
	public class SdtK2BValueDescriptionCollection_Item_RESTInterface : GxGenericCollectionItem<SdtK2BValueDescriptionCollection_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BValueDescriptionCollection_Item_RESTInterface( ) : base()
		{	
		}

		public SdtK2BValueDescriptionCollection_Item_RESTInterface( SdtK2BValueDescriptionCollection_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Value", Order=0)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value);

			}
			set { 
				 sdt.gxTpr_Value = value;
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

		[DataMember(Name="CanBeDeleted", Order=2)]
		public bool gxTpr_Canbedeleted
		{
			get { 
				return sdt.gxTpr_Canbedeleted;

			}
			set { 
				sdt.gxTpr_Canbedeleted = value;
			}
		}


		#endregion

		public SdtK2BValueDescriptionCollection_Item sdt
		{
			get { 
				return (SdtK2BValueDescriptionCollection_Item)Sdt;
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
				sdt = new SdtK2BValueDescriptionCollection_Item() ;
			}
		}
	}
	#endregion
}