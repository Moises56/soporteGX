/*
				   File: type_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem
			Description: K2BFilterValuesSDT
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
	[XmlRoot(ElementName="K2BFilterValuesSDTItem")]
	[XmlType(TypeName="K2BFilterValuesSDTItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem : GxUserType
	{
		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Name = "";

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Description = "";

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Type = "";

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Value = "";

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Valuedescription = "";

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticdaterangevalue = "";

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticnumericrangevalue = "";

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangefromvalue = (DateTime)(DateTime.MinValue);

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangetovalue = (DateTime)(DateTime.MinValue);

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangefromvalue = "";

			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangetovalue = "";

		}

		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Value", gxTpr_Value, false);


			AddObjectProperty("ValueDescription", gxTpr_Valuedescription, false);


			AddObjectProperty("SemanticDateRangeValue", gxTpr_Semanticdaterangevalue, false);


			AddObjectProperty("SemanticNumericRangeValue", gxTpr_Semanticnumericrangevalue, false);


			datetime_STZ = gxTpr_Daterangefromvalue;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("DateRangeFromValue", sDateCnv, false);



			datetime_STZ = gxTpr_Daterangetovalue;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("DateRangeToValue", sDateCnv, false);



			AddObjectProperty("NumericRangeFromValue", gxTpr_Numericrangefromvalue, false);


			AddObjectProperty("NumericRangeToValue", gxTpr_Numericrangetovalue, false);


			AddObjectProperty("CanBeDeleted", gxTpr_Canbedeleted, false);

			if (gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues != null)
			{
				AddObjectProperty("MultipleValues", gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Name; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Description; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Type; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Value; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="ValueDescription")]
		[XmlElement(ElementName="ValueDescription")]
		public string gxTpr_Valuedescription
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Valuedescription; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Valuedescription = value;
				SetDirty("Valuedescription");
			}
		}




		[SoapElement(ElementName="SemanticDateRangeValue")]
		[XmlElement(ElementName="SemanticDateRangeValue")]
		public string gxTpr_Semanticdaterangevalue
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticdaterangevalue; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticdaterangevalue = value;
				SetDirty("Semanticdaterangevalue");
			}
		}




		[SoapElement(ElementName="SemanticNumericRangeValue")]
		[XmlElement(ElementName="SemanticNumericRangeValue")]
		public string gxTpr_Semanticnumericrangevalue
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticnumericrangevalue; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticnumericrangevalue = value;
				SetDirty("Semanticnumericrangevalue");
			}
		}



		[SoapElement(ElementName="DateRangeFromValue")]
		[XmlElement(ElementName="DateRangeFromValue" , IsNullable=true)]
		public string gxTpr_Daterangefromvalue_Nullable
		{
			get {
				if ( gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangefromvalue == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangefromvalue).value ;
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangefromvalue = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Daterangefromvalue
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangefromvalue; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangefromvalue = value;
				SetDirty("Daterangefromvalue");
			}
		}


		[SoapElement(ElementName="DateRangeToValue")]
		[XmlElement(ElementName="DateRangeToValue" , IsNullable=true)]
		public string gxTpr_Daterangetovalue_Nullable
		{
			get {
				if ( gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangetovalue == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangetovalue).value ;
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangetovalue = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Daterangetovalue
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangetovalue; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangetovalue = value;
				SetDirty("Daterangetovalue");
			}
		}



		[SoapElement(ElementName="NumericRangeFromValue")]
		[XmlElement(ElementName="NumericRangeFromValue")]
		public string gxTpr_Numericrangefromvalue
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangefromvalue; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangefromvalue = value;
				SetDirty("Numericrangefromvalue");
			}
		}




		[SoapElement(ElementName="NumericRangeToValue")]
		[XmlElement(ElementName="NumericRangeToValue")]
		public string gxTpr_Numericrangetovalue
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangetovalue; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangetovalue = value;
				SetDirty("Numericrangetovalue");
			}
		}




		[SoapElement(ElementName="CanBeDeleted")]
		[XmlElement(ElementName="CanBeDeleted")]
		public bool gxTpr_Canbedeleted
		{
			get {
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Canbedeleted; 
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Canbedeleted = value;
				SetDirty("Canbedeleted");
			}
		}




		[SoapElement(ElementName="MultipleValues" )]
		[XmlArray(ElementName="MultipleValues"  )]
		[XmlArrayItemAttribute(ElementName="MultipleValuesItem" , IsNullable=false )]
		public GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem> gxTpr_Multiplevalues
		{
			get {
				if ( gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues == null )
				{
					gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem>( context, "K2BFilterValuesSDT.K2BFilterValuesSDTItem.MultipleValuesItem", "");
				}
				return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues;
			}
			set {
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues_N = false;
				gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues = value;
				SetDirty("Multiplevalues");
			}
		}

		public void gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues_SetNull()
		{
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues_N = true;
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues = null;
		}

		public bool gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues_IsNull()
		{
			return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues == null;
		}
		public bool ShouldSerializegxTpr_Multiplevalues_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues != null && gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Name = "";
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Description = "";
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Type = "";
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Value = "";
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Valuedescription = "";
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticdaterangevalue = "";
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticnumericrangevalue = "";
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangefromvalue = (DateTime)(DateTime.MinValue);
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangetovalue = (DateTime)(DateTime.MinValue);
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangefromvalue = "";
			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangetovalue = "";


			gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues_N = true;

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Name;
		 

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Description;
		 

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Type;
		 

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Value;
		 

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Valuedescription;
		 

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticdaterangevalue;
		 

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Semanticnumericrangevalue;
		 

		protected DateTime gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangefromvalue;
		 

		protected DateTime gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Daterangetovalue;
		 

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangefromvalue;
		 

		protected string gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Numericrangetovalue;
		 

		protected bool gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Canbedeleted;
		 
		protected bool gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues_N;
		protected GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem> gxTv_SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_Multiplevalues = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BFilterValuesSDTItem", Namespace="test")]
	public class SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_RESTInterface : GxGenericCollectionItem<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_RESTInterface( SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
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

		[DataMember(Name="Type", Order=2)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Value", Order=3)]
		public  string gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="ValueDescription", Order=4)]
		public  string gxTpr_Valuedescription
		{
			get { 
				return sdt.gxTpr_Valuedescription;

			}
			set { 
				 sdt.gxTpr_Valuedescription = value;
			}
		}

		[DataMember(Name="SemanticDateRangeValue", Order=5)]
		public  string gxTpr_Semanticdaterangevalue
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Semanticdaterangevalue);

			}
			set { 
				 sdt.gxTpr_Semanticdaterangevalue = value;
			}
		}

		[DataMember(Name="SemanticNumericRangeValue", Order=6)]
		public  string gxTpr_Semanticnumericrangevalue
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Semanticnumericrangevalue);

			}
			set { 
				 sdt.gxTpr_Semanticnumericrangevalue = value;
			}
		}

		[DataMember(Name="DateRangeFromValue", Order=7)]
		public  string gxTpr_Daterangefromvalue
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Daterangefromvalue);

			}
			set { 
				sdt.gxTpr_Daterangefromvalue = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DateRangeToValue", Order=8)]
		public  string gxTpr_Daterangetovalue
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Daterangetovalue);

			}
			set { 
				sdt.gxTpr_Daterangetovalue = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NumericRangeFromValue", Order=9)]
		public  string gxTpr_Numericrangefromvalue
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Numericrangefromvalue);

			}
			set { 
				 sdt.gxTpr_Numericrangefromvalue = value;
			}
		}

		[DataMember(Name="NumericRangeToValue", Order=10)]
		public  string gxTpr_Numericrangetovalue
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Numericrangetovalue);

			}
			set { 
				 sdt.gxTpr_Numericrangetovalue = value;
			}
		}

		[DataMember(Name="CanBeDeleted", Order=11)]
		public bool gxTpr_Canbedeleted
		{
			get { 
				return sdt.gxTpr_Canbedeleted;

			}
			set { 
				sdt.gxTpr_Canbedeleted = value;
			}
		}

		[DataMember(Name="MultipleValues", Order=12, EmitDefaultValue=false)]
		public GxGenericCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_RESTInterface> gxTpr_Multiplevalues
		{
			get {
				if (sdt.ShouldSerializegxTpr_Multiplevalues_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem_RESTInterface>(sdt.gxTpr_Multiplevalues);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Multiplevalues);
			}
		}


		#endregion

		public SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem sdt
		{
			get { 
				return (SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem)Sdt;
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
				sdt = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem() ;
			}
		}
	}
	#endregion
}