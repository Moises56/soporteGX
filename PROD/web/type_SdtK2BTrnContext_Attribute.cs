/*
				   File: type_SdtK2BTrnContext_Attribute
			Description: Attributes
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
	[XmlRoot(ElementName="K2BTrnContext.Attribute")]
	[XmlType(TypeName="K2BTrnContext.Attribute" , Namespace="test" )]
	[GxJsonName("Attributes")]
	[Serializable]
	public class SdtK2BTrnContext_Attribute : GxUserType
	{
		public SdtK2BTrnContext_Attribute( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BTrnContext_Attribute_Attributename = "";

			gxTv_SdtK2BTrnContext_Attribute_Attributevalue = "";

			gxTv_SdtK2BTrnContext_Attribute_Valuetype = "";

		}

		public SdtK2BTrnContext_Attribute(IGxContext context)
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
				mapper["Name"] = "Attributename";
				mapper["Value"] = "Attributevalue";
				mapper["ValueType"] = "Valuetype";

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
			if (ShouldSerializegxTpr_Attributename_Json())
			{	
				AddObjectProperty("Name", gxTpr_Attributename, false);
			}


			if (ShouldSerializegxTpr_Attributevalue_Json())
			{	
				AddObjectProperty("Value", gxTpr_Attributevalue, false);
			}


			if (ShouldSerializegxTpr_Valuetype_Json())
			{	
				AddObjectProperty("ValueType", gxTpr_Valuetype, false);
			}

			return;
		}
		#endregion

		#region Properties

		[SoapAttribute(AttributeName="Name")]
		[XmlAttribute(AttributeName="Name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string gxTpr_Attributename
		{
			get {
				return gxTv_SdtK2BTrnContext_Attribute_Attributename; 
			}
			set {
				gxTv_SdtK2BTrnContext_Attribute_Attributename_N = false;
				gxTv_SdtK2BTrnContext_Attribute_Attributename = value;
				SetDirty("Attributename");
			}
		}

		public bool ShouldSerializegxTpr_Attributename()

		{
				return !gxTv_SdtK2BTrnContext_Attribute_Attributename_N;

		}
		public bool ShouldSerializegxTpr_Attributename_Json()
		{
			return !gxTv_SdtK2BTrnContext_Attribute_Attributename_N;

		}



		[SoapAttribute(AttributeName="Value")]
		[XmlAttribute(AttributeName="Value", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string gxTpr_Attributevalue
		{
			get {
				return gxTv_SdtK2BTrnContext_Attribute_Attributevalue; 
			}
			set {
				gxTv_SdtK2BTrnContext_Attribute_Attributevalue_N = false;
				gxTv_SdtK2BTrnContext_Attribute_Attributevalue = value;
				SetDirty("Attributevalue");
			}
		}

		public bool ShouldSerializegxTpr_Attributevalue()

		{
				return !gxTv_SdtK2BTrnContext_Attribute_Attributevalue_N;

		}
		public bool ShouldSerializegxTpr_Attributevalue_Json()
		{
			return !gxTv_SdtK2BTrnContext_Attribute_Attributevalue_N;

		}



		[XmlText]
		public string gxTpr_Valuetype
		{
			get {
				return gxTv_SdtK2BTrnContext_Attribute_Valuetype; 
			}
			set {
				gxTv_SdtK2BTrnContext_Attribute_Valuetype_N = false;
				gxTv_SdtK2BTrnContext_Attribute_Valuetype = value;
				SetDirty("Valuetype");
			}
		}

		public bool ShouldSerializegxTpr_Valuetype_Json()
		{
			return !gxTv_SdtK2BTrnContext_Attribute_Valuetype_N;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Attributename_Json()|| 
				 ShouldSerializegxTpr_Attributevalue_Json()|| 
				 ShouldSerializegxTpr_Valuetype_Json()||  
				false);
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BTrnContext_Attribute_Attributename = "";
			gxTv_SdtK2BTrnContext_Attribute_Attributename_N = true;

			gxTv_SdtK2BTrnContext_Attribute_Attributevalue = "";
			gxTv_SdtK2BTrnContext_Attribute_Attributevalue_N = true;

			gxTv_SdtK2BTrnContext_Attribute_Valuetype = "";
			gxTv_SdtK2BTrnContext_Attribute_Valuetype_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BTrnContext_Attribute_Attributename;
		protected bool gxTv_SdtK2BTrnContext_Attribute_Attributename_N;
		 

		protected string gxTv_SdtK2BTrnContext_Attribute_Attributevalue;
		protected bool gxTv_SdtK2BTrnContext_Attribute_Attributevalue_N;
		 

		protected string gxTv_SdtK2BTrnContext_Attribute_Valuetype;
		protected bool gxTv_SdtK2BTrnContext_Attribute_Valuetype_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonName("Attributes")]
	[DataContract(Name=@"K2BTrnContext.Attribute", Namespace="test")]
	public class SdtK2BTrnContext_Attribute_RESTInterface : GxGenericCollectionItem<SdtK2BTrnContext_Attribute>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BTrnContext_Attribute_RESTInterface( ) : base()
		{	
		}

		public SdtK2BTrnContext_Attribute_RESTInterface( SdtK2BTrnContext_Attribute psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0, EmitDefaultValue=false)]
		public  string gxTpr_Attributename
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Attributename_Json())
					return sdt.gxTpr_Attributename;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Attributename = value;
			}
		}

		[DataMember(Name="Value", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Attributevalue
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Attributevalue_Json())
					return sdt.gxTpr_Attributevalue;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Attributevalue = value;
			}
		}

		[DataMember(Name="ValueType", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Valuetype
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Valuetype_Json())
					return StringUtil.RTrim( sdt.gxTpr_Valuetype);
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Valuetype = value;
			}
		}


		#endregion

		public SdtK2BTrnContext_Attribute sdt
		{
			get { 
				return (SdtK2BTrnContext_Attribute)Sdt;
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
				sdt = new SdtK2BTrnContext_Attribute() ;
			}
		}
	}
	#endregion
}