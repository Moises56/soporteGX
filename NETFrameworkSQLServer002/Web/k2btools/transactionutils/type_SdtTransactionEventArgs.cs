/*
				   File: type_SdtTransactionEventArgs
			Description: TransactionEventArgs
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

using GeneXus.Programs;
using GeneXus.Programs.k2btools;
namespace GeneXus.Programs.k2btools.transactionutils
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="TransactionEventArgs")]
	[XmlType(TypeName="TransactionEventArgs" , Namespace="test" )]
	[Serializable]
	public class SdtTransactionEventArgs : GxUserType
	{
		public SdtTransactionEventArgs( )
		{
			/* Constructor for serialization */
			gxTv_SdtTransactionEventArgs_Programname = "";

			gxTv_SdtTransactionEventArgs_Mode = "";

		}

		public SdtTransactionEventArgs(IGxContext context)
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
			AddObjectProperty("ProgramName", gxTpr_Programname, false);


			AddObjectProperty("Mode", gxTpr_Mode, false);

			if (gxTv_SdtTransactionEventArgs_Keyvalue != null)
			{
				AddObjectProperty("KeyValue", gxTv_SdtTransactionEventArgs_Keyvalue, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProgramName")]
		[XmlElement(ElementName="ProgramName")]
		public string gxTpr_Programname
		{
			get {
				return gxTv_SdtTransactionEventArgs_Programname; 
			}
			set {
				gxTv_SdtTransactionEventArgs_Programname = value;
				SetDirty("Programname");
			}
		}




		[SoapElement(ElementName="Mode")]
		[XmlElement(ElementName="Mode")]
		public string gxTpr_Mode
		{
			get {
				return gxTv_SdtTransactionEventArgs_Mode; 
			}
			set {
				gxTv_SdtTransactionEventArgs_Mode = value;
				SetDirty("Mode");
			}
		}




		[SoapElement(ElementName="KeyValue" )]
		[XmlArray(ElementName="KeyValue"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtK2BAttributeValue_Item> gxTpr_Keyvalue_GXBaseCollection
		{
			get {
				if ( gxTv_SdtTransactionEventArgs_Keyvalue == null )
				{
					gxTv_SdtTransactionEventArgs_Keyvalue = new GXBaseCollection<GeneXus.Programs.SdtK2BAttributeValue_Item>( context, "K2BAttributeValue", "");
				}
				return gxTv_SdtTransactionEventArgs_Keyvalue;
			}
			set {
				gxTv_SdtTransactionEventArgs_Keyvalue_N = false;
				gxTv_SdtTransactionEventArgs_Keyvalue = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtK2BAttributeValue_Item> gxTpr_Keyvalue
		{
			get {
				if ( gxTv_SdtTransactionEventArgs_Keyvalue == null )
				{
					gxTv_SdtTransactionEventArgs_Keyvalue = new GXBaseCollection<GeneXus.Programs.SdtK2BAttributeValue_Item>( context, "K2BAttributeValue", "");
				}
				gxTv_SdtTransactionEventArgs_Keyvalue_N = false;
				return gxTv_SdtTransactionEventArgs_Keyvalue ;
			}
			set {
				gxTv_SdtTransactionEventArgs_Keyvalue_N = false;
				gxTv_SdtTransactionEventArgs_Keyvalue = value;
				SetDirty("Keyvalue");
			}
		}

		public void gxTv_SdtTransactionEventArgs_Keyvalue_SetNull()
		{
			gxTv_SdtTransactionEventArgs_Keyvalue_N = true;
			gxTv_SdtTransactionEventArgs_Keyvalue = null;
		}

		public bool gxTv_SdtTransactionEventArgs_Keyvalue_IsNull()
		{
			return gxTv_SdtTransactionEventArgs_Keyvalue == null;
		}
		public bool ShouldSerializegxTpr_Keyvalue_GXBaseCollection_Json()
		{
			return gxTv_SdtTransactionEventArgs_Keyvalue != null && gxTv_SdtTransactionEventArgs_Keyvalue.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtTransactionEventArgs_Programname = "";
			gxTv_SdtTransactionEventArgs_Mode = "";

			gxTv_SdtTransactionEventArgs_Keyvalue_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtTransactionEventArgs_Programname;
		 

		protected string gxTv_SdtTransactionEventArgs_Mode;
		 
		protected bool gxTv_SdtTransactionEventArgs_Keyvalue_N;
		protected GXBaseCollection<GeneXus.Programs.SdtK2BAttributeValue_Item> gxTv_SdtTransactionEventArgs_Keyvalue = null;  


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"TransactionEventArgs", Namespace="test")]
	public class SdtTransactionEventArgs_RESTInterface : GxGenericCollectionItem<SdtTransactionEventArgs>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtTransactionEventArgs_RESTInterface( ) : base()
		{	
		}

		public SdtTransactionEventArgs_RESTInterface( SdtTransactionEventArgs psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProgramName", Order=0)]
		public  string gxTpr_Programname
		{
			get { 
				return sdt.gxTpr_Programname;

			}
			set { 
				 sdt.gxTpr_Programname = value;
			}
		}

		[DataMember(Name="Mode", Order=1)]
		public  string gxTpr_Mode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mode);

			}
			set { 
				 sdt.gxTpr_Mode = value;
			}
		}

		[DataMember(Name="KeyValue", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtK2BAttributeValue_Item_RESTInterface> gxTpr_Keyvalue
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Keyvalue_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtK2BAttributeValue_Item_RESTInterface>(sdt.gxTpr_Keyvalue);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Keyvalue);
			}
		}


		#endregion

		public SdtTransactionEventArgs sdt
		{
			get { 
				return (SdtTransactionEventArgs)Sdt;
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
				sdt = new SdtTransactionEventArgs() ;
			}
		}
	}
	#endregion
}