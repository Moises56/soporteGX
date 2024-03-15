/*
				   File: type_SdtK2BTrnContext
			Description: K2BTrnContext
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
	[XmlRoot(ElementName="K2BTrnContext")]
	[XmlType(TypeName="K2BTrnContext" , Namespace="test" )]
	[GxJsonName("TrnContext")]
	[Serializable]
	public class SdtK2BTrnContext : GxUserType
	{
		public SdtK2BTrnContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BTrnContext_Transactionname = "";

			gxTv_SdtK2BTrnContext_Callerurl = "";

			gxTv_SdtK2BTrnContext_Entitymanagername = "";

			gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode = "";

			gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode = "";

			gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters = "";

			gxTv_SdtK2BTrnContext_Returnmode = "";

			gxTv_SdtK2BTrnContext_Raiseafterconfirmevent = "";

			gxTv_SdtK2BTrnContext_Raiseaftercancelevent = "";

		}

		public SdtK2BTrnContext(IGxContext context)
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
				mapper["Transaction"] = "Transactionname";
				mapper["CallerUrl"] = "Callerurl";
				mapper["EMName"] = "Entitymanagername";
				mapper["NextTaskCode"] = "Entitymanagernexttaskcode";
				mapper["NextTaskMode"] = "Entitymanagernexttaskmode";
				mapper["EncryptUrlParms"] = "Entitymanagerencrypturlparameters";
				mapper["ReturnMode"] = "Returnmode";
				mapper["SavePK"] = "Savepk";
				mapper["Attributes"] = "Attributes";

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
			if (ShouldSerializegxTpr_Transactionname_Json())
			{	
				AddObjectProperty("Transaction", gxTpr_Transactionname, false);
			}


			if (ShouldSerializegxTpr_Callerurl_Json())
			{	
				AddObjectProperty("CallerUrl", gxTpr_Callerurl, false);
			}


			if (ShouldSerializegxTpr_Entitymanagername_Json())
			{	
				AddObjectProperty("EMName", gxTpr_Entitymanagername, false);
			}


			if (ShouldSerializegxTpr_Entitymanagernexttaskcode_Json())
			{	
				AddObjectProperty("NextTaskCode", gxTpr_Entitymanagernexttaskcode, false);
			}


			if (ShouldSerializegxTpr_Entitymanagernexttaskmode_Json())
			{	
				AddObjectProperty("NextTaskMode", gxTpr_Entitymanagernexttaskmode, false);
			}


			if (ShouldSerializegxTpr_Entitymanagerencrypturlparameters_Json())
			{	
				AddObjectProperty("EncryptUrlParms", gxTpr_Entitymanagerencrypturlparameters, false);
			}


			if (ShouldSerializegxTpr_Returnmode_Json())
			{	
				AddObjectProperty("ReturnMode", gxTpr_Returnmode, false);
			}


			if (ShouldSerializegxTpr_Savepk_Json())
			{	
				AddObjectProperty("SavePK", gxTpr_Savepk, false);
			}

			if (gxTv_SdtK2BTrnContext_Afterinsert != null)
			{
				AddObjectProperty("AfterInsert", gxTv_SdtK2BTrnContext_Afterinsert, false);
			}
			if (gxTv_SdtK2BTrnContext_Afterupdate != null)
			{
				AddObjectProperty("AfterUpdate", gxTv_SdtK2BTrnContext_Afterupdate, false);
			}
			if (gxTv_SdtK2BTrnContext_Afterdelete != null)
			{
				AddObjectProperty("AfterDelete", gxTv_SdtK2BTrnContext_Afterdelete, false);
			}

			AddObjectProperty("RaiseAfterConfirmEvent", gxTpr_Raiseafterconfirmevent, false);


			AddObjectProperty("RaiseAfterCancelEvent", gxTpr_Raiseaftercancelevent, false);

			if (gxTv_SdtK2BTrnContext_Attributes != null)
			{
				AddObjectProperty("Attributes", gxTv_SdtK2BTrnContext_Attributes, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapAttribute(AttributeName="Transaction")]
		[XmlAttribute(AttributeName="Transaction", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string gxTpr_Transactionname
		{
			get {
				return gxTv_SdtK2BTrnContext_Transactionname; 
			}
			set {
				gxTv_SdtK2BTrnContext_Transactionname_N = false;
				gxTv_SdtK2BTrnContext_Transactionname = value;
				SetDirty("Transactionname");
			}
		}

		public bool ShouldSerializegxTpr_Transactionname()

		{
				return !gxTv_SdtK2BTrnContext_Transactionname_N;

		}
		public bool ShouldSerializegxTpr_Transactionname_Json()
		{
			return !gxTv_SdtK2BTrnContext_Transactionname_N;

		}



		[SoapAttribute(AttributeName="CallerUrl")]
		[XmlAttribute(AttributeName="CallerUrl", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string gxTpr_Callerurl
		{
			get {
				return gxTv_SdtK2BTrnContext_Callerurl; 
			}
			set {
				gxTv_SdtK2BTrnContext_Callerurl_N = false;
				gxTv_SdtK2BTrnContext_Callerurl = value;
				SetDirty("Callerurl");
			}
		}

		public bool ShouldSerializegxTpr_Callerurl()

		{
				return !gxTv_SdtK2BTrnContext_Callerurl_N;

		}
		public bool ShouldSerializegxTpr_Callerurl_Json()
		{
			return !gxTv_SdtK2BTrnContext_Callerurl_N;

		}



		[SoapAttribute(AttributeName="EMName")]
		[XmlAttribute(AttributeName="EMName", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string gxTpr_Entitymanagername
		{
			get {
				return gxTv_SdtK2BTrnContext_Entitymanagername; 
			}
			set {
				gxTv_SdtK2BTrnContext_Entitymanagername_N = false;
				gxTv_SdtK2BTrnContext_Entitymanagername = value;
				SetDirty("Entitymanagername");
			}
		}

		public bool ShouldSerializegxTpr_Entitymanagername()

		{
				return !gxTv_SdtK2BTrnContext_Entitymanagername_N;

		}
		public bool ShouldSerializegxTpr_Entitymanagername_Json()
		{
			return !gxTv_SdtK2BTrnContext_Entitymanagername_N;

		}



		[SoapAttribute(AttributeName="NextTaskCode")]
		[XmlAttribute(AttributeName="NextTaskCode", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string gxTpr_Entitymanagernexttaskcode
		{
			get {
				return gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode; 
			}
			set {
				gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode_N = false;
				gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode = value;
				SetDirty("Entitymanagernexttaskcode");
			}
		}

		public bool ShouldSerializegxTpr_Entitymanagernexttaskcode()

		{
				return !gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode_N;

		}
		public bool ShouldSerializegxTpr_Entitymanagernexttaskcode_Json()
		{
			return !gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode_N;

		}



		[SoapAttribute(AttributeName="NextTaskMode")]
		[XmlAttribute(AttributeName="NextTaskMode", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string gxTpr_Entitymanagernexttaskmode
		{
			get {
				return gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode; 
			}
			set {
				gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode_N = false;
				gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode = value;
				SetDirty("Entitymanagernexttaskmode");
			}
		}

		public bool ShouldSerializegxTpr_Entitymanagernexttaskmode()

		{
				return !gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode_N;

		}
		public bool ShouldSerializegxTpr_Entitymanagernexttaskmode_Json()
		{
			return !gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode_N;

		}



		[SoapAttribute(AttributeName="EncryptUrlParms")]
		[XmlAttribute(AttributeName="EncryptUrlParms", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string gxTpr_Entitymanagerencrypturlparameters
		{
			get {
				return gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters; 
			}
			set {
				gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters_N = false;
				gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters = value;
				SetDirty("Entitymanagerencrypturlparameters");
			}
		}

		public bool ShouldSerializegxTpr_Entitymanagerencrypturlparameters()

		{
				return !gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters_N;

		}
		public bool ShouldSerializegxTpr_Entitymanagerencrypturlparameters_Json()
		{
			return !gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters_N;

		}



		[SoapAttribute(AttributeName="ReturnMode")]
		[XmlAttribute(AttributeName="ReturnMode", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string gxTpr_Returnmode
		{
			get {
				return gxTv_SdtK2BTrnContext_Returnmode; 
			}
			set {
				gxTv_SdtK2BTrnContext_Returnmode_N = false;
				gxTv_SdtK2BTrnContext_Returnmode = value;
				SetDirty("Returnmode");
			}
		}

		public bool ShouldSerializegxTpr_Returnmode()

		{
				return !gxTv_SdtK2BTrnContext_Returnmode_N;

		}
		public bool ShouldSerializegxTpr_Returnmode_Json()
		{
			return !gxTv_SdtK2BTrnContext_Returnmode_N;

		}



		[SoapAttribute(AttributeName="SavePK")]
		[XmlAttribute(AttributeName="SavePK", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public bool gxTpr_Savepk
		{
			get {
				return gxTv_SdtK2BTrnContext_Savepk; 
			}
			set {
				gxTv_SdtK2BTrnContext_Savepk_N = false;
				gxTv_SdtK2BTrnContext_Savepk = value;
				SetDirty("Savepk");
			}
		}

		public bool ShouldSerializegxTpr_Savepk()

		{
				return !gxTv_SdtK2BTrnContext_Savepk_N;

		}
		public bool ShouldSerializegxTpr_Savepk_Json()
		{
			return !gxTv_SdtK2BTrnContext_Savepk_N;

		}


		[SoapElement(ElementName="AfterInsert")]
		[XmlElement(ElementName="AfterInsert")]
		public GeneXus.Programs.SdtK2BTrnNavigation gxTpr_Afterinsert
		{
			get {
				if ( gxTv_SdtK2BTrnContext_Afterinsert == null )
				{
					gxTv_SdtK2BTrnContext_Afterinsert = new GeneXus.Programs.SdtK2BTrnNavigation(context);
				}
				return gxTv_SdtK2BTrnContext_Afterinsert; 
			}
			set {
				gxTv_SdtK2BTrnContext_Afterinsert = value;
				SetDirty("Afterinsert");
			}
		}
		public void gxTv_SdtK2BTrnContext_Afterinsert_SetNull()
		{
			gxTv_SdtK2BTrnContext_Afterinsert_N = true;
			gxTv_SdtK2BTrnContext_Afterinsert = null;
		}

		public bool gxTv_SdtK2BTrnContext_Afterinsert_IsNull()
		{
			return gxTv_SdtK2BTrnContext_Afterinsert == null;
		}
		public bool ShouldSerializegxTpr_Afterinsert_Json()
		{
			return gxTv_SdtK2BTrnContext_Afterinsert != null;

		}

		[SoapElement(ElementName="AfterUpdate")]
		[XmlElement(ElementName="AfterUpdate")]
		public GeneXus.Programs.SdtK2BTrnNavigation gxTpr_Afterupdate
		{
			get {
				if ( gxTv_SdtK2BTrnContext_Afterupdate == null )
				{
					gxTv_SdtK2BTrnContext_Afterupdate = new GeneXus.Programs.SdtK2BTrnNavigation(context);
				}
				return gxTv_SdtK2BTrnContext_Afterupdate; 
			}
			set {
				gxTv_SdtK2BTrnContext_Afterupdate = value;
				SetDirty("Afterupdate");
			}
		}
		public void gxTv_SdtK2BTrnContext_Afterupdate_SetNull()
		{
			gxTv_SdtK2BTrnContext_Afterupdate_N = true;
			gxTv_SdtK2BTrnContext_Afterupdate = null;
		}

		public bool gxTv_SdtK2BTrnContext_Afterupdate_IsNull()
		{
			return gxTv_SdtK2BTrnContext_Afterupdate == null;
		}
		public bool ShouldSerializegxTpr_Afterupdate_Json()
		{
			return gxTv_SdtK2BTrnContext_Afterupdate != null;

		}

		[SoapElement(ElementName="AfterDelete")]
		[XmlElement(ElementName="AfterDelete")]
		public GeneXus.Programs.SdtK2BTrnNavigation gxTpr_Afterdelete
		{
			get {
				if ( gxTv_SdtK2BTrnContext_Afterdelete == null )
				{
					gxTv_SdtK2BTrnContext_Afterdelete = new GeneXus.Programs.SdtK2BTrnNavigation(context);
				}
				return gxTv_SdtK2BTrnContext_Afterdelete; 
			}
			set {
				gxTv_SdtK2BTrnContext_Afterdelete = value;
				SetDirty("Afterdelete");
			}
		}
		public void gxTv_SdtK2BTrnContext_Afterdelete_SetNull()
		{
			gxTv_SdtK2BTrnContext_Afterdelete_N = true;
			gxTv_SdtK2BTrnContext_Afterdelete = null;
		}

		public bool gxTv_SdtK2BTrnContext_Afterdelete_IsNull()
		{
			return gxTv_SdtK2BTrnContext_Afterdelete == null;
		}
		public bool ShouldSerializegxTpr_Afterdelete_Json()
		{
			return gxTv_SdtK2BTrnContext_Afterdelete != null;

		}


		[SoapElement(ElementName="RaiseAfterConfirmEvent")]
		[XmlElement(ElementName="RaiseAfterConfirmEvent")]
		public string gxTpr_Raiseafterconfirmevent
		{
			get {
				return gxTv_SdtK2BTrnContext_Raiseafterconfirmevent; 
			}
			set {
				gxTv_SdtK2BTrnContext_Raiseafterconfirmevent = value;
				SetDirty("Raiseafterconfirmevent");
			}
		}




		[SoapElement(ElementName="RaiseAfterCancelEvent")]
		[XmlElement(ElementName="RaiseAfterCancelEvent")]
		public string gxTpr_Raiseaftercancelevent
		{
			get {
				return gxTv_SdtK2BTrnContext_Raiseaftercancelevent; 
			}
			set {
				gxTv_SdtK2BTrnContext_Raiseaftercancelevent = value;
				SetDirty("Raiseaftercancelevent");
			}
		}




		[SoapElement(ElementName="Attributes" )]
		[XmlArray(ElementName="Attributes" , Form = System.Xml.Schema.XmlSchemaForm.Unqualified )]
		[XmlArrayItemAttribute(ElementName="Item" , Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false )]
		public GXBaseCollection<SdtK2BTrnContext_Attribute> gxTpr_Attributes
		{
			get {
				if ( gxTv_SdtK2BTrnContext_Attributes == null )
				{
					gxTv_SdtK2BTrnContext_Attributes = new GXBaseCollection<SdtK2BTrnContext_Attribute>( context, "K2BTrnContext.Attribute", "");
				}
				return gxTv_SdtK2BTrnContext_Attributes;
			}
			set {
				gxTv_SdtK2BTrnContext_Attributes_N = false;
				gxTv_SdtK2BTrnContext_Attributes = value;
				SetDirty("Attributes");
			}
		}

		public void gxTv_SdtK2BTrnContext_Attributes_SetNull()
		{
			gxTv_SdtK2BTrnContext_Attributes_N = true;
			gxTv_SdtK2BTrnContext_Attributes = null;
		}

		public bool gxTv_SdtK2BTrnContext_Attributes_IsNull()
		{
			return gxTv_SdtK2BTrnContext_Attributes == null;
		}
		public bool ShouldSerializegxTpr_Attributes()

		{
				return gxTv_SdtK2BTrnContext_Attributes != null && gxTv_SdtK2BTrnContext_Attributes.Count > 0;

		}
		public bool ShouldSerializegxTpr_Attributes_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BTrnContext_Attributes != null && gxTv_SdtK2BTrnContext_Attributes.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BTrnContext_Transactionname = "";
			gxTv_SdtK2BTrnContext_Transactionname_N = true;

			gxTv_SdtK2BTrnContext_Callerurl = "";
			gxTv_SdtK2BTrnContext_Callerurl_N = true;

			gxTv_SdtK2BTrnContext_Entitymanagername = "";
			gxTv_SdtK2BTrnContext_Entitymanagername_N = true;

			gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode = "";
			gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode_N = true;

			gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode = "";
			gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode_N = true;

			gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters = "";
			gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters_N = true;

			gxTv_SdtK2BTrnContext_Returnmode = "";
			gxTv_SdtK2BTrnContext_Returnmode_N = true;


			gxTv_SdtK2BTrnContext_Savepk_N = true;


			gxTv_SdtK2BTrnContext_Afterinsert_N = true;


			gxTv_SdtK2BTrnContext_Afterupdate_N = true;


			gxTv_SdtK2BTrnContext_Afterdelete_N = true;

			gxTv_SdtK2BTrnContext_Raiseafterconfirmevent = "";
			gxTv_SdtK2BTrnContext_Raiseaftercancelevent = "";

			gxTv_SdtK2BTrnContext_Attributes_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BTrnContext_Transactionname;
		protected bool gxTv_SdtK2BTrnContext_Transactionname_N;
		 

		protected string gxTv_SdtK2BTrnContext_Callerurl;
		protected bool gxTv_SdtK2BTrnContext_Callerurl_N;
		 

		protected string gxTv_SdtK2BTrnContext_Entitymanagername;
		protected bool gxTv_SdtK2BTrnContext_Entitymanagername_N;
		 

		protected string gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode;
		protected bool gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode_N;
		 

		protected string gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode;
		protected bool gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode_N;
		 

		protected string gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters;
		protected bool gxTv_SdtK2BTrnContext_Entitymanagerencrypturlparameters_N;
		 

		protected string gxTv_SdtK2BTrnContext_Returnmode;
		protected bool gxTv_SdtK2BTrnContext_Returnmode_N;
		 

		protected bool gxTv_SdtK2BTrnContext_Savepk;
		protected bool gxTv_SdtK2BTrnContext_Savepk_N;
		 

		protected GeneXus.Programs.SdtK2BTrnNavigation gxTv_SdtK2BTrnContext_Afterinsert = null;
		protected bool gxTv_SdtK2BTrnContext_Afterinsert_N;
		 

		protected GeneXus.Programs.SdtK2BTrnNavigation gxTv_SdtK2BTrnContext_Afterupdate = null;
		protected bool gxTv_SdtK2BTrnContext_Afterupdate_N;
		 

		protected GeneXus.Programs.SdtK2BTrnNavigation gxTv_SdtK2BTrnContext_Afterdelete = null;
		protected bool gxTv_SdtK2BTrnContext_Afterdelete_N;
		 

		protected string gxTv_SdtK2BTrnContext_Raiseafterconfirmevent;
		 

		protected string gxTv_SdtK2BTrnContext_Raiseaftercancelevent;
		 
		protected bool gxTv_SdtK2BTrnContext_Attributes_N;
		protected GXBaseCollection<SdtK2BTrnContext_Attribute> gxTv_SdtK2BTrnContext_Attributes = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[GxJsonName("TrnContext")]
	[DataContract(Name=@"K2BTrnContext", Namespace="test")]
	public class SdtK2BTrnContext_RESTInterface : GxGenericCollectionItem<SdtK2BTrnContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BTrnContext_RESTInterface( ) : base()
		{	
		}

		public SdtK2BTrnContext_RESTInterface( SdtK2BTrnContext psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Transaction", Order=0, EmitDefaultValue=false)]
		public  string gxTpr_Transactionname
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Transactionname_Json())
					return sdt.gxTpr_Transactionname;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Transactionname = value;
			}
		}

		[DataMember(Name="CallerUrl", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Callerurl
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Callerurl_Json())
					return sdt.gxTpr_Callerurl;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Callerurl = value;
			}
		}

		[DataMember(Name="EMName", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Entitymanagername
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Entitymanagername_Json())
					return sdt.gxTpr_Entitymanagername;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Entitymanagername = value;
			}
		}

		[DataMember(Name="NextTaskCode", Order=3, EmitDefaultValue=false)]
		public  string gxTpr_Entitymanagernexttaskcode
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Entitymanagernexttaskcode_Json())
					return StringUtil.RTrim( sdt.gxTpr_Entitymanagernexttaskcode);
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Entitymanagernexttaskcode = value;
			}
		}

		[DataMember(Name="NextTaskMode", Order=4, EmitDefaultValue=false)]
		public  string gxTpr_Entitymanagernexttaskmode
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Entitymanagernexttaskmode_Json())
					return StringUtil.RTrim( sdt.gxTpr_Entitymanagernexttaskmode);
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Entitymanagernexttaskmode = value;
			}
		}

		[DataMember(Name="EncryptUrlParms", Order=5, EmitDefaultValue=false)]
		public  string gxTpr_Entitymanagerencrypturlparameters
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Entitymanagerencrypturlparameters_Json())
					return StringUtil.RTrim( sdt.gxTpr_Entitymanagerencrypturlparameters);
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Entitymanagerencrypturlparameters = value;
			}
		}

		[DataMember(Name="ReturnMode", Order=6, EmitDefaultValue=false)]
		public  string gxTpr_Returnmode
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Returnmode_Json())
					return StringUtil.RTrim( sdt.gxTpr_Returnmode);
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Returnmode = value;
			}
		}

		[DataMember(Name="SavePK", Order=7, EmitDefaultValue=false)]
		public  Nullable<bool> gxTpr_Savepk
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Savepk_Json())
					return sdt.gxTpr_Savepk;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Savepk = (bool) (value.HasValue ? value.Value : false);
			}
		}

		[DataMember(Name="AfterInsert", Order=8, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface gxTpr_Afterinsert
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Afterinsert_Json())
					return new GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface(sdt.gxTpr_Afterinsert);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Afterinsert = value.sdt;
			}
		}

		[DataMember(Name="AfterUpdate", Order=9, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface gxTpr_Afterupdate
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Afterupdate_Json())
					return new GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface(sdt.gxTpr_Afterupdate);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Afterupdate = value.sdt;
			}
		}

		[DataMember(Name="AfterDelete", Order=10, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface gxTpr_Afterdelete
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Afterdelete_Json())
					return new GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface(sdt.gxTpr_Afterdelete);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Afterdelete = value.sdt;
			}
		}

		[DataMember(Name="RaiseAfterConfirmEvent", Order=11)]
		public  string gxTpr_Raiseafterconfirmevent
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Raiseafterconfirmevent);

			}
			set { 
				 sdt.gxTpr_Raiseafterconfirmevent = value;
			}
		}

		[DataMember(Name="RaiseAfterCancelEvent", Order=12)]
		public  string gxTpr_Raiseaftercancelevent
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Raiseaftercancelevent);

			}
			set { 
				 sdt.gxTpr_Raiseaftercancelevent = value;
			}
		}

		[DataMember(Name="Attributes", Order=13, EmitDefaultValue=false)]
		public GxGenericCollection<SdtK2BTrnContext_Attribute_RESTInterface> gxTpr_Attributes
		{
			get {
				if (sdt.ShouldSerializegxTpr_Attributes_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtK2BTrnContext_Attribute_RESTInterface>(sdt.gxTpr_Attributes);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Attributes);
			}
		}


		#endregion

		public SdtK2BTrnContext sdt
		{
			get { 
				return (SdtK2BTrnContext)Sdt;
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
				sdt = new SdtK2BTrnContext() ;
			}
		}
	}
	#endregion
}