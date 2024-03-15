/*
				   File: type_SdtSearchableTransactions_SearchableTransactionsItem
			Description: SearchableTransactions
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
	[XmlRoot(ElementName="SearchableTransactionsItem")]
	[XmlType(TypeName="SearchableTransactionsItem" , Namespace="test" )]
	[Serializable]
	public class SdtSearchableTransactions_SearchableTransactionsItem : GxUserType
	{
		public SdtSearchableTransactions_SearchableTransactionsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactiondescription = "";

			gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Entityname = "";

			gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactionname = "";

			gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Searchtype = "";

		}

		public SdtSearchableTransactions_SearchableTransactionsItem(IGxContext context)
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
			AddObjectProperty("TransactionDescription", gxTpr_Transactiondescription, false);


			AddObjectProperty("EntityName", gxTpr_Entityname, false);


			AddObjectProperty("TransactionName", gxTpr_Transactionname, false);


			AddObjectProperty("SearchType", gxTpr_Searchtype, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TransactionDescription")]
		[XmlElement(ElementName="TransactionDescription")]
		public string gxTpr_Transactiondescription
		{
			get {
				return gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactiondescription; 
			}
			set {
				gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactiondescription = value;
				SetDirty("Transactiondescription");
			}
		}




		[SoapElement(ElementName="EntityName")]
		[XmlElement(ElementName="EntityName")]
		public string gxTpr_Entityname
		{
			get {
				return gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Entityname; 
			}
			set {
				gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Entityname = value;
				SetDirty("Entityname");
			}
		}




		[SoapElement(ElementName="TransactionName")]
		[XmlElement(ElementName="TransactionName")]
		public string gxTpr_Transactionname
		{
			get {
				return gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactionname; 
			}
			set {
				gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactionname = value;
				SetDirty("Transactionname");
			}
		}




		[SoapElement(ElementName="SearchType")]
		[XmlElement(ElementName="SearchType")]
		public string gxTpr_Searchtype
		{
			get {
				return gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Searchtype; 
			}
			set {
				gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Searchtype = value;
				SetDirty("Searchtype");
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
			gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactiondescription = "";
			gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Entityname = "";
			gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactionname = "";
			gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Searchtype = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactiondescription;
		 

		protected string gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Entityname;
		 

		protected string gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Transactionname;
		 

		protected string gxTv_SdtSearchableTransactions_SearchableTransactionsItem_Searchtype;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SearchableTransactionsItem", Namespace="test")]
	public class SdtSearchableTransactions_SearchableTransactionsItem_RESTInterface : GxGenericCollectionItem<SdtSearchableTransactions_SearchableTransactionsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSearchableTransactions_SearchableTransactionsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSearchableTransactions_SearchableTransactionsItem_RESTInterface( SdtSearchableTransactions_SearchableTransactionsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TransactionDescription", Order=0)]
		public  string gxTpr_Transactiondescription
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Transactiondescription);

			}
			set { 
				 sdt.gxTpr_Transactiondescription = value;
			}
		}

		[DataMember(Name="EntityName", Order=1)]
		public  string gxTpr_Entityname
		{
			get { 
				return sdt.gxTpr_Entityname;

			}
			set { 
				 sdt.gxTpr_Entityname = value;
			}
		}

		[DataMember(Name="TransactionName", Order=2)]
		public  string gxTpr_Transactionname
		{
			get { 
				return sdt.gxTpr_Transactionname;

			}
			set { 
				 sdt.gxTpr_Transactionname = value;
			}
		}

		[DataMember(Name="SearchType", Order=3)]
		public  string gxTpr_Searchtype
		{
			get { 
				return sdt.gxTpr_Searchtype;

			}
			set { 
				 sdt.gxTpr_Searchtype = value;
			}
		}


		#endregion

		public SdtSearchableTransactions_SearchableTransactionsItem sdt
		{
			get { 
				return (SdtSearchableTransactions_SearchableTransactionsItem)Sdt;
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
				sdt = new SdtSearchableTransactions_SearchableTransactionsItem() ;
			}
		}
	}
	#endregion
}