/*
				   File: type_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem
			Description: MultipleValues
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
	[XmlRoot(ElementName="K2BFilterValuesSDT.K2BFilterValuesSDTItem.MultipleValuesItem")]
	[XmlType(TypeName="K2BFilterValuesSDT.K2BFilterValuesSDTItem.MultipleValuesItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem : GxUserType
	{
		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemvalue = "";

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemdescription = "";

		}

		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem(IGxContext context)
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
			AddObjectProperty("ItemValue", gxTpr_Itemvalue, false);


			AddObjectProperty("ItemDescription", gxTpr_Itemdescription, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ItemValue")]
		[XmlElement(ElementName="ItemValue")]
		public string gxTpr_Itemvalue
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemvalue; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemvalue = value;
				SetDirty("Itemvalue");
			}
		}




		[SoapElement(ElementName="ItemDescription")]
		[XmlElement(ElementName="ItemDescription")]
		public string gxTpr_Itemdescription
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemdescription; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemdescription = value;
				SetDirty("Itemdescription");
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
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemvalue = "";
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemdescription = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemvalue;
		 

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_Itemdescription;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BFilterValuesSDT.K2BFilterValuesSDTItem.MultipleValuesItem", Namespace="test")]
	public class SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_RESTInterface : GxGenericCollectionItem<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_RESTInterface( SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ItemValue", Order=0)]
		public  string gxTpr_Itemvalue
		{
			get { 
				return sdt.gxTpr_Itemvalue;

			}
			set { 
				 sdt.gxTpr_Itemvalue = value;
			}
		}

		[DataMember(Name="ItemDescription", Order=1)]
		public  string gxTpr_Itemdescription
		{
			get { 
				return sdt.gxTpr_Itemdescription;

			}
			set { 
				 sdt.gxTpr_Itemdescription = value;
			}
		}


		#endregion

		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem sdt
		{
			get { 
				return (SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem)Sdt;
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
				sdt = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem() ;
			}
		}
	}
	#endregion
}