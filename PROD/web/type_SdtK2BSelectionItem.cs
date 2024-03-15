/*
				   File: type_SdtK2BSelectionItem
			Description: K2BSelectionItem
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
	[XmlRoot(ElementName="K2BSelectionItem")]
	[XmlType(TypeName="K2BSelectionItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BSelectionItem : GxUserType
	{
		public SdtK2BSelectionItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BSelectionItem_Skcharacter1 = "";

			gxTv_SdtK2BSelectionItem_Skcharacter2 = "";

			gxTv_SdtK2BSelectionItem_Skcharacter3 = "";

			gxTv_SdtK2BSelectionItem_Skcharacter4 = "";

			gxTv_SdtK2BSelectionItem_Skcharacter5 = "";

			gxTv_SdtK2BSelectionItem_Skcharacter6 = "";

			gxTv_SdtK2BSelectionItem_Skdatetime1 = (DateTime)(DateTime.MinValue);

			gxTv_SdtK2BSelectionItem_Skdatetime2 = (DateTime)(DateTime.MinValue);

		}

		public SdtK2BSelectionItem(IGxContext context)
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
			AddObjectProperty("SKNumeric1", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Sknumeric1, 18, 0)), false);


			AddObjectProperty("SKNumeric2", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Sknumeric2, 18, 0)), false);


			AddObjectProperty("SKNumeric3", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Sknumeric3, 18, 0)), false);


			AddObjectProperty("SKNumeric4", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Sknumeric4, 18, 0)), false);


			AddObjectProperty("SKNumeric5", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Sknumeric5, 18, 0)), false);


			AddObjectProperty("SKNumeric6", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Sknumeric6, 18, 0)), false);


			AddObjectProperty("SKCharacter1", gxTpr_Skcharacter1, false);


			AddObjectProperty("SKCharacter2", gxTpr_Skcharacter2, false);


			AddObjectProperty("SKCharacter3", gxTpr_Skcharacter3, false);


			AddObjectProperty("SKCharacter4", gxTpr_Skcharacter4, false);


			AddObjectProperty("SKCharacter5", gxTpr_Skcharacter5, false);


			AddObjectProperty("SKCharacter6", gxTpr_Skcharacter6, false);


			AddObjectProperty("SKGUID1", gxTpr_Skguid1, false);


			AddObjectProperty("SKGUID2", gxTpr_Skguid2, false);


			datetime_STZ = gxTpr_Skdatetime1;
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
			AddObjectProperty("SKDateTime1", sDateCnv, false);



			datetime_STZ = gxTpr_Skdatetime2;
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
			AddObjectProperty("SKDateTime2", sDateCnv, false);



			AddObjectProperty("IsSelected", gxTpr_Isselected, false);

			if (gxTv_SdtK2BSelectionItem_Fieldvalues != null)
			{
				AddObjectProperty("FieldValues", gxTv_SdtK2BSelectionItem_Fieldvalues, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SKNumeric1")]
		[XmlElement(ElementName="SKNumeric1")]
		public long gxTpr_Sknumeric1
		{
			get {
				return gxTv_SdtK2BSelectionItem_Sknumeric1; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Sknumeric1 = value;
				SetDirty("Sknumeric1");
			}
		}




		[SoapElement(ElementName="SKNumeric2")]
		[XmlElement(ElementName="SKNumeric2")]
		public long gxTpr_Sknumeric2
		{
			get {
				return gxTv_SdtK2BSelectionItem_Sknumeric2; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Sknumeric2 = value;
				SetDirty("Sknumeric2");
			}
		}




		[SoapElement(ElementName="SKNumeric3")]
		[XmlElement(ElementName="SKNumeric3")]
		public long gxTpr_Sknumeric3
		{
			get {
				return gxTv_SdtK2BSelectionItem_Sknumeric3; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Sknumeric3 = value;
				SetDirty("Sknumeric3");
			}
		}




		[SoapElement(ElementName="SKNumeric4")]
		[XmlElement(ElementName="SKNumeric4")]
		public long gxTpr_Sknumeric4
		{
			get {
				return gxTv_SdtK2BSelectionItem_Sknumeric4; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Sknumeric4 = value;
				SetDirty("Sknumeric4");
			}
		}




		[SoapElement(ElementName="SKNumeric5")]
		[XmlElement(ElementName="SKNumeric5")]
		public long gxTpr_Sknumeric5
		{
			get {
				return gxTv_SdtK2BSelectionItem_Sknumeric5; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Sknumeric5 = value;
				SetDirty("Sknumeric5");
			}
		}




		[SoapElement(ElementName="SKNumeric6")]
		[XmlElement(ElementName="SKNumeric6")]
		public long gxTpr_Sknumeric6
		{
			get {
				return gxTv_SdtK2BSelectionItem_Sknumeric6; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Sknumeric6 = value;
				SetDirty("Sknumeric6");
			}
		}




		[SoapElement(ElementName="SKCharacter1")]
		[XmlElement(ElementName="SKCharacter1")]
		public string gxTpr_Skcharacter1
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skcharacter1; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skcharacter1 = value;
				SetDirty("Skcharacter1");
			}
		}




		[SoapElement(ElementName="SKCharacter2")]
		[XmlElement(ElementName="SKCharacter2")]
		public string gxTpr_Skcharacter2
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skcharacter2; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skcharacter2 = value;
				SetDirty("Skcharacter2");
			}
		}




		[SoapElement(ElementName="SKCharacter3")]
		[XmlElement(ElementName="SKCharacter3")]
		public string gxTpr_Skcharacter3
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skcharacter3; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skcharacter3 = value;
				SetDirty("Skcharacter3");
			}
		}




		[SoapElement(ElementName="SKCharacter4")]
		[XmlElement(ElementName="SKCharacter4")]
		public string gxTpr_Skcharacter4
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skcharacter4; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skcharacter4 = value;
				SetDirty("Skcharacter4");
			}
		}




		[SoapElement(ElementName="SKCharacter5")]
		[XmlElement(ElementName="SKCharacter5")]
		public string gxTpr_Skcharacter5
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skcharacter5; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skcharacter5 = value;
				SetDirty("Skcharacter5");
			}
		}




		[SoapElement(ElementName="SKCharacter6")]
		[XmlElement(ElementName="SKCharacter6")]
		public string gxTpr_Skcharacter6
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skcharacter6; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skcharacter6 = value;
				SetDirty("Skcharacter6");
			}
		}




		[SoapElement(ElementName="SKGUID1")]
		[XmlElement(ElementName="SKGUID1")]
		public Guid gxTpr_Skguid1
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skguid1; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skguid1 = value;
				SetDirty("Skguid1");
			}
		}




		[SoapElement(ElementName="SKGUID2")]
		[XmlElement(ElementName="SKGUID2")]
		public Guid gxTpr_Skguid2
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skguid2; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skguid2 = value;
				SetDirty("Skguid2");
			}
		}



		[SoapElement(ElementName="SKDateTime1")]
		[XmlElement(ElementName="SKDateTime1" , IsNullable=true)]
		public string gxTpr_Skdatetime1_Nullable
		{
			get {
				if ( gxTv_SdtK2BSelectionItem_Skdatetime1 == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtK2BSelectionItem_Skdatetime1).value ;
			}
			set {
				gxTv_SdtK2BSelectionItem_Skdatetime1 = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Skdatetime1
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skdatetime1; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skdatetime1 = value;
				SetDirty("Skdatetime1");
			}
		}


		[SoapElement(ElementName="SKDateTime2")]
		[XmlElement(ElementName="SKDateTime2" , IsNullable=true)]
		public string gxTpr_Skdatetime2_Nullable
		{
			get {
				if ( gxTv_SdtK2BSelectionItem_Skdatetime2 == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtK2BSelectionItem_Skdatetime2).value ;
			}
			set {
				gxTv_SdtK2BSelectionItem_Skdatetime2 = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Skdatetime2
		{
			get {
				return gxTv_SdtK2BSelectionItem_Skdatetime2; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Skdatetime2 = value;
				SetDirty("Skdatetime2");
			}
		}



		[SoapElement(ElementName="IsSelected")]
		[XmlElement(ElementName="IsSelected")]
		public bool gxTpr_Isselected
		{
			get {
				return gxTv_SdtK2BSelectionItem_Isselected; 
			}
			set {
				gxTv_SdtK2BSelectionItem_Isselected = value;
				SetDirty("Isselected");
			}
		}




		[SoapElement(ElementName="FieldValues" )]
		[XmlArray(ElementName="FieldValues"  )]
		[XmlArrayItemAttribute(ElementName="FieldValuesItem" , IsNullable=false )]
		public GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> gxTpr_Fieldvalues
		{
			get {
				if ( gxTv_SdtK2BSelectionItem_Fieldvalues == null )
				{
					gxTv_SdtK2BSelectionItem_Fieldvalues = new GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem>( context, "K2BSelectionItem.FieldValuesItem", "");
				}
				return gxTv_SdtK2BSelectionItem_Fieldvalues;
			}
			set {
				gxTv_SdtK2BSelectionItem_Fieldvalues_N = false;
				gxTv_SdtK2BSelectionItem_Fieldvalues = value;
				SetDirty("Fieldvalues");
			}
		}

		public void gxTv_SdtK2BSelectionItem_Fieldvalues_SetNull()
		{
			gxTv_SdtK2BSelectionItem_Fieldvalues_N = true;
			gxTv_SdtK2BSelectionItem_Fieldvalues = null;
		}

		public bool gxTv_SdtK2BSelectionItem_Fieldvalues_IsNull()
		{
			return gxTv_SdtK2BSelectionItem_Fieldvalues == null;
		}
		public bool ShouldSerializegxTpr_Fieldvalues_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BSelectionItem_Fieldvalues != null && gxTv_SdtK2BSelectionItem_Fieldvalues.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BSelectionItem_Skcharacter1 = "";
			gxTv_SdtK2BSelectionItem_Skcharacter2 = "";
			gxTv_SdtK2BSelectionItem_Skcharacter3 = "";
			gxTv_SdtK2BSelectionItem_Skcharacter4 = "";
			gxTv_SdtK2BSelectionItem_Skcharacter5 = "";
			gxTv_SdtK2BSelectionItem_Skcharacter6 = "";


			gxTv_SdtK2BSelectionItem_Skdatetime1 = (DateTime)(DateTime.MinValue);
			gxTv_SdtK2BSelectionItem_Skdatetime2 = (DateTime)(DateTime.MinValue);


			gxTv_SdtK2BSelectionItem_Fieldvalues_N = true;

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

		protected long gxTv_SdtK2BSelectionItem_Sknumeric1;
		 

		protected long gxTv_SdtK2BSelectionItem_Sknumeric2;
		 

		protected long gxTv_SdtK2BSelectionItem_Sknumeric3;
		 

		protected long gxTv_SdtK2BSelectionItem_Sknumeric4;
		 

		protected long gxTv_SdtK2BSelectionItem_Sknumeric5;
		 

		protected long gxTv_SdtK2BSelectionItem_Sknumeric6;
		 

		protected string gxTv_SdtK2BSelectionItem_Skcharacter1;
		 

		protected string gxTv_SdtK2BSelectionItem_Skcharacter2;
		 

		protected string gxTv_SdtK2BSelectionItem_Skcharacter3;
		 

		protected string gxTv_SdtK2BSelectionItem_Skcharacter4;
		 

		protected string gxTv_SdtK2BSelectionItem_Skcharacter5;
		 

		protected string gxTv_SdtK2BSelectionItem_Skcharacter6;
		 

		protected Guid gxTv_SdtK2BSelectionItem_Skguid1;
		 

		protected Guid gxTv_SdtK2BSelectionItem_Skguid2;
		 

		protected DateTime gxTv_SdtK2BSelectionItem_Skdatetime1;
		 

		protected DateTime gxTv_SdtK2BSelectionItem_Skdatetime2;
		 

		protected bool gxTv_SdtK2BSelectionItem_Isselected;
		 
		protected bool gxTv_SdtK2BSelectionItem_Fieldvalues_N;
		protected GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> gxTv_SdtK2BSelectionItem_Fieldvalues = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"K2BSelectionItem", Namespace="test")]
	public class SdtK2BSelectionItem_RESTInterface : GxGenericCollectionItem<SdtK2BSelectionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BSelectionItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BSelectionItem_RESTInterface( SdtK2BSelectionItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SKNumeric1", Order=0)]
		public  string gxTpr_Sknumeric1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sknumeric1, 18, 0));

			}
			set { 
				sdt.gxTpr_Sknumeric1 = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SKNumeric2", Order=1)]
		public  string gxTpr_Sknumeric2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sknumeric2, 18, 0));

			}
			set { 
				sdt.gxTpr_Sknumeric2 = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SKNumeric3", Order=2)]
		public  string gxTpr_Sknumeric3
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sknumeric3, 18, 0));

			}
			set { 
				sdt.gxTpr_Sknumeric3 = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SKNumeric4", Order=3)]
		public  string gxTpr_Sknumeric4
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sknumeric4, 18, 0));

			}
			set { 
				sdt.gxTpr_Sknumeric4 = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SKNumeric5", Order=4)]
		public  string gxTpr_Sknumeric5
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sknumeric5, 18, 0));

			}
			set { 
				sdt.gxTpr_Sknumeric5 = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SKNumeric6", Order=5)]
		public  string gxTpr_Sknumeric6
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sknumeric6, 18, 0));

			}
			set { 
				sdt.gxTpr_Sknumeric6 = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SKCharacter1", Order=6)]
		public  string gxTpr_Skcharacter1
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Skcharacter1);

			}
			set { 
				 sdt.gxTpr_Skcharacter1 = value;
			}
		}

		[DataMember(Name="SKCharacter2", Order=7)]
		public  string gxTpr_Skcharacter2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Skcharacter2);

			}
			set { 
				 sdt.gxTpr_Skcharacter2 = value;
			}
		}

		[DataMember(Name="SKCharacter3", Order=8)]
		public  string gxTpr_Skcharacter3
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Skcharacter3);

			}
			set { 
				 sdt.gxTpr_Skcharacter3 = value;
			}
		}

		[DataMember(Name="SKCharacter4", Order=9)]
		public  string gxTpr_Skcharacter4
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Skcharacter4);

			}
			set { 
				 sdt.gxTpr_Skcharacter4 = value;
			}
		}

		[DataMember(Name="SKCharacter5", Order=10)]
		public  string gxTpr_Skcharacter5
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Skcharacter5);

			}
			set { 
				 sdt.gxTpr_Skcharacter5 = value;
			}
		}

		[DataMember(Name="SKCharacter6", Order=11)]
		public  string gxTpr_Skcharacter6
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Skcharacter6);

			}
			set { 
				 sdt.gxTpr_Skcharacter6 = value;
			}
		}

		[DataMember(Name="SKGUID1", Order=12)]
		public Guid gxTpr_Skguid1
		{
			get { 
				return sdt.gxTpr_Skguid1;

			}
			set { 
				sdt.gxTpr_Skguid1 = value;
			}
		}

		[DataMember(Name="SKGUID2", Order=13)]
		public Guid gxTpr_Skguid2
		{
			get { 
				return sdt.gxTpr_Skguid2;

			}
			set { 
				sdt.gxTpr_Skguid2 = value;
			}
		}

		[DataMember(Name="SKDateTime1", Order=14)]
		public  string gxTpr_Skdatetime1
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Skdatetime1);

			}
			set { 
				sdt.gxTpr_Skdatetime1 = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="SKDateTime2", Order=15)]
		public  string gxTpr_Skdatetime2
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Skdatetime2);

			}
			set { 
				sdt.gxTpr_Skdatetime2 = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="IsSelected", Order=16)]
		public bool gxTpr_Isselected
		{
			get { 
				return sdt.gxTpr_Isselected;

			}
			set { 
				sdt.gxTpr_Isselected = value;
			}
		}

		[DataMember(Name="FieldValues", Order=17, EmitDefaultValue=false)]
		public GxGenericCollection<SdtK2BSelectionItem_FieldValuesItem_RESTInterface> gxTpr_Fieldvalues
		{
			get {
				if (sdt.ShouldSerializegxTpr_Fieldvalues_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtK2BSelectionItem_FieldValuesItem_RESTInterface>(sdt.gxTpr_Fieldvalues);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Fieldvalues);
			}
		}


		#endregion

		public SdtK2BSelectionItem sdt
		{
			get { 
				return (SdtK2BSelectionItem)Sdt;
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
				sdt = new SdtK2BSelectionItem() ;
			}
		}
	}
	#endregion
}