/*
				   File: type_SdtK2BT_CSVImportParameters
			Description: K2BT_CSVImportParameters
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
	[XmlRoot(ElementName="K2BT_CSVImportParameters")]
	[XmlType(TypeName="K2BT_CSVImportParameters" , Namespace="test" )]
	[Serializable]
	public class SdtK2BT_CSVImportParameters : GxUserType
	{
		public SdtK2BT_CSVImportParameters( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BT_CSVImportParameters_Fielddelimiter = "";

			gxTv_SdtK2BT_CSVImportParameters_Stringdelimiter = "";

			gxTv_SdtK2BT_CSVImportParameters_Encoding = "";

			gxTv_SdtK2BT_CSVImportParameters_Dateformat = "";

			gxTv_SdtK2BT_CSVImportParameters_Datetimeformat = "";

			gxTv_SdtK2BT_CSVImportParameters_Dateseparator = "";

			gxTv_SdtK2BT_CSVImportParameters_Timeseparator = "";

		}

		public SdtK2BT_CSVImportParameters(IGxContext context)
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
			AddObjectProperty("FieldDelimiter", gxTpr_Fielddelimiter, false);


			AddObjectProperty("StringDelimiter", gxTpr_Stringdelimiter, false);


			AddObjectProperty("Encoding", gxTpr_Encoding, false);


			AddObjectProperty("DateFormat", gxTpr_Dateformat, false);


			AddObjectProperty("DateTimeFormat", gxTpr_Datetimeformat, false);


			AddObjectProperty("DateSeparator", gxTpr_Dateseparator, false);


			AddObjectProperty("TimeSeparator", gxTpr_Timeseparator, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FieldDelimiter")]
		[XmlElement(ElementName="FieldDelimiter")]
		public string gxTpr_Fielddelimiter
		{
			get {
				return gxTv_SdtK2BT_CSVImportParameters_Fielddelimiter; 
			}
			set {
				gxTv_SdtK2BT_CSVImportParameters_Fielddelimiter = value;
				SetDirty("Fielddelimiter");
			}
		}




		[SoapElement(ElementName="StringDelimiter")]
		[XmlElement(ElementName="StringDelimiter")]
		public string gxTpr_Stringdelimiter
		{
			get {
				return gxTv_SdtK2BT_CSVImportParameters_Stringdelimiter; 
			}
			set {
				gxTv_SdtK2BT_CSVImportParameters_Stringdelimiter = value;
				SetDirty("Stringdelimiter");
			}
		}




		[SoapElement(ElementName="Encoding")]
		[XmlElement(ElementName="Encoding")]
		public string gxTpr_Encoding
		{
			get {
				return gxTv_SdtK2BT_CSVImportParameters_Encoding; 
			}
			set {
				gxTv_SdtK2BT_CSVImportParameters_Encoding = value;
				SetDirty("Encoding");
			}
		}




		[SoapElement(ElementName="DateFormat")]
		[XmlElement(ElementName="DateFormat")]
		public string gxTpr_Dateformat
		{
			get {
				return gxTv_SdtK2BT_CSVImportParameters_Dateformat; 
			}
			set {
				gxTv_SdtK2BT_CSVImportParameters_Dateformat = value;
				SetDirty("Dateformat");
			}
		}




		[SoapElement(ElementName="DateTimeFormat")]
		[XmlElement(ElementName="DateTimeFormat")]
		public string gxTpr_Datetimeformat
		{
			get {
				return gxTv_SdtK2BT_CSVImportParameters_Datetimeformat; 
			}
			set {
				gxTv_SdtK2BT_CSVImportParameters_Datetimeformat = value;
				SetDirty("Datetimeformat");
			}
		}




		[SoapElement(ElementName="DateSeparator")]
		[XmlElement(ElementName="DateSeparator")]
		public string gxTpr_Dateseparator
		{
			get {
				return gxTv_SdtK2BT_CSVImportParameters_Dateseparator; 
			}
			set {
				gxTv_SdtK2BT_CSVImportParameters_Dateseparator = value;
				SetDirty("Dateseparator");
			}
		}




		[SoapElement(ElementName="TimeSeparator")]
		[XmlElement(ElementName="TimeSeparator")]
		public string gxTpr_Timeseparator
		{
			get {
				return gxTv_SdtK2BT_CSVImportParameters_Timeseparator; 
			}
			set {
				gxTv_SdtK2BT_CSVImportParameters_Timeseparator = value;
				SetDirty("Timeseparator");
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
			gxTv_SdtK2BT_CSVImportParameters_Fielddelimiter = "";
			gxTv_SdtK2BT_CSVImportParameters_Stringdelimiter = "";
			gxTv_SdtK2BT_CSVImportParameters_Encoding = "";
			gxTv_SdtK2BT_CSVImportParameters_Dateformat = "";
			gxTv_SdtK2BT_CSVImportParameters_Datetimeformat = "";
			gxTv_SdtK2BT_CSVImportParameters_Dateseparator = "";
			gxTv_SdtK2BT_CSVImportParameters_Timeseparator = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BT_CSVImportParameters_Fielddelimiter;
		 

		protected string gxTv_SdtK2BT_CSVImportParameters_Stringdelimiter;
		 

		protected string gxTv_SdtK2BT_CSVImportParameters_Encoding;
		 

		protected string gxTv_SdtK2BT_CSVImportParameters_Dateformat;
		 

		protected string gxTv_SdtK2BT_CSVImportParameters_Datetimeformat;
		 

		protected string gxTv_SdtK2BT_CSVImportParameters_Dateseparator;
		 

		protected string gxTv_SdtK2BT_CSVImportParameters_Timeseparator;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"K2BT_CSVImportParameters", Namespace="test")]
	public class SdtK2BT_CSVImportParameters_RESTInterface : GxGenericCollectionItem<SdtK2BT_CSVImportParameters>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BT_CSVImportParameters_RESTInterface( ) : base()
		{	
		}

		public SdtK2BT_CSVImportParameters_RESTInterface( SdtK2BT_CSVImportParameters psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="FieldDelimiter", Order=0)]
		public  string gxTpr_Fielddelimiter
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Fielddelimiter);

			}
			set { 
				 sdt.gxTpr_Fielddelimiter = value;
			}
		}

		[DataMember(Name="StringDelimiter", Order=1)]
		public  string gxTpr_Stringdelimiter
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Stringdelimiter);

			}
			set { 
				 sdt.gxTpr_Stringdelimiter = value;
			}
		}

		[DataMember(Name="Encoding", Order=2)]
		public  string gxTpr_Encoding
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Encoding);

			}
			set { 
				 sdt.gxTpr_Encoding = value;
			}
		}

		[DataMember(Name="DateFormat", Order=3)]
		public  string gxTpr_Dateformat
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Dateformat);

			}
			set { 
				 sdt.gxTpr_Dateformat = value;
			}
		}

		[DataMember(Name="DateTimeFormat", Order=4)]
		public  string gxTpr_Datetimeformat
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Datetimeformat);

			}
			set { 
				 sdt.gxTpr_Datetimeformat = value;
			}
		}

		[DataMember(Name="DateSeparator", Order=5)]
		public  string gxTpr_Dateseparator
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Dateseparator);

			}
			set { 
				 sdt.gxTpr_Dateseparator = value;
			}
		}

		[DataMember(Name="TimeSeparator", Order=6)]
		public  string gxTpr_Timeseparator
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Timeseparator);

			}
			set { 
				 sdt.gxTpr_Timeseparator = value;
			}
		}


		#endregion

		public SdtK2BT_CSVImportParameters sdt
		{
			get { 
				return (SdtK2BT_CSVImportParameters)Sdt;
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
				sdt = new SdtK2BT_CSVImportParameters() ;
			}
		}
	}
	#endregion
}