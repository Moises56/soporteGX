/*
				   File: type_SdtK2BGridOrders_K2BGridOrdersItem
			Description: K2BGridOrders
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
	[XmlRoot(ElementName="K2BGridOrdersItem")]
	[XmlType(TypeName="K2BGridOrdersItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BGridOrders_K2BGridOrdersItem : GxUserType
	{
		public SdtK2BGridOrders_K2BGridOrdersItem( )
		{
			/* Constructor for serialization */
		}

		public SdtK2BGridOrders_K2BGridOrdersItem(IGxContext context)
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
			AddObjectProperty("GridColumnIndex", gxTpr_Gridcolumnindex, false);


			AddObjectProperty("AscendingOrder", gxTpr_Ascendingorder, false);


			AddObjectProperty("DescendingOrder", gxTpr_Descendingorder, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="GridColumnIndex")]
		[XmlElement(ElementName="GridColumnIndex")]
		public short gxTpr_Gridcolumnindex
		{
			get {
				return gxTv_SdtK2BGridOrders_K2BGridOrdersItem_Gridcolumnindex; 
			}
			set {
				gxTv_SdtK2BGridOrders_K2BGridOrdersItem_Gridcolumnindex = value;
				SetDirty("Gridcolumnindex");
			}
		}




		[SoapElement(ElementName="AscendingOrder")]
		[XmlElement(ElementName="AscendingOrder")]
		public short gxTpr_Ascendingorder
		{
			get {
				return gxTv_SdtK2BGridOrders_K2BGridOrdersItem_Ascendingorder; 
			}
			set {
				gxTv_SdtK2BGridOrders_K2BGridOrdersItem_Ascendingorder = value;
				SetDirty("Ascendingorder");
			}
		}




		[SoapElement(ElementName="DescendingOrder")]
		[XmlElement(ElementName="DescendingOrder")]
		public short gxTpr_Descendingorder
		{
			get {
				return gxTv_SdtK2BGridOrders_K2BGridOrdersItem_Descendingorder; 
			}
			set {
				gxTv_SdtK2BGridOrders_K2BGridOrdersItem_Descendingorder = value;
				SetDirty("Descendingorder");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtK2BGridOrders_K2BGridOrdersItem_Gridcolumnindex;
		 

		protected short gxTv_SdtK2BGridOrders_K2BGridOrdersItem_Ascendingorder;
		 

		protected short gxTv_SdtK2BGridOrders_K2BGridOrdersItem_Descendingorder;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BGridOrdersItem", Namespace="test")]
	public class SdtK2BGridOrders_K2BGridOrdersItem_RESTInterface : GxGenericCollectionItem<SdtK2BGridOrders_K2BGridOrdersItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BGridOrders_K2BGridOrdersItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BGridOrders_K2BGridOrdersItem_RESTInterface( SdtK2BGridOrders_K2BGridOrdersItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="GridColumnIndex", Order=0)]
		public short gxTpr_Gridcolumnindex
		{
			get { 
				return sdt.gxTpr_Gridcolumnindex;

			}
			set { 
				sdt.gxTpr_Gridcolumnindex = value;
			}
		}

		[DataMember(Name="AscendingOrder", Order=1)]
		public short gxTpr_Ascendingorder
		{
			get { 
				return sdt.gxTpr_Ascendingorder;

			}
			set { 
				sdt.gxTpr_Ascendingorder = value;
			}
		}

		[DataMember(Name="DescendingOrder", Order=2)]
		public short gxTpr_Descendingorder
		{
			get { 
				return sdt.gxTpr_Descendingorder;

			}
			set { 
				sdt.gxTpr_Descendingorder = value;
			}
		}


		#endregion

		public SdtK2BGridOrders_K2BGridOrdersItem sdt
		{
			get { 
				return (SdtK2BGridOrders_K2BGridOrdersItem)Sdt;
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
				sdt = new SdtK2BGridOrders_K2BGridOrdersItem() ;
			}
		}
	}
	#endregion
}