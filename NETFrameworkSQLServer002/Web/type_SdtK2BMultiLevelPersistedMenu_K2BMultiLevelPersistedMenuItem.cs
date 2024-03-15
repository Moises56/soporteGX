/*
				   File: type_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem
			Description: K2BMultiLevelPersistedMenu
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
	[XmlRoot(ElementName="K2BMultiLevelPersistedMenuItem")]
	[XmlType(TypeName="K2BMultiLevelPersistedMenuItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem : GxUserType
	{
		public SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Code = "";

			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Title = "";

			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageurl = "";

			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageclass = "";

			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobject = "";

			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobjectparameters = "";

		}

		public SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem(IGxContext context)
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
			AddObjectProperty("Code", gxTpr_Code, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("ImageUrl", gxTpr_Imageurl, false);


			AddObjectProperty("ImageClass", gxTpr_Imageclass, false);

			if (gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items != null)
			{
				AddObjectProperty("Items", gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items, false);
			}

			AddObjectProperty("ShowInExtraSmall", gxTpr_Showinextrasmall, false);


			AddObjectProperty("ShowInSmall", gxTpr_Showinsmall, false);


			AddObjectProperty("ShowInMedium", gxTpr_Showinmedium, false);


			AddObjectProperty("ShowInLarge", gxTpr_Showinlarge, false);

			if (gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity != null)
			{
				AddObjectProperty("Activity", gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity, false);
			}

			AddObjectProperty("GXObject", gxTpr_Gxobject, false);


			AddObjectProperty("GXObjectParameters", gxTpr_Gxobjectparameters, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public string gxTpr_Code
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Code; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Title; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="ImageUrl")]
		[XmlElement(ElementName="ImageUrl")]
		public string gxTpr_Imageurl
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageurl; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageurl = value;
				SetDirty("Imageurl");
			}
		}




		[SoapElement(ElementName="ImageClass")]
		[XmlElement(ElementName="ImageClass")]
		public string gxTpr_Imageclass
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageclass; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageclass = value;
				SetDirty("Imageclass");
			}
		}




		[SoapElement(ElementName="Items" )]
		[XmlArray(ElementName="Items"  )]
		[XmlArrayItemAttribute(ElementName="K2BMultiLevelPersistedMenuItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> gxTpr_Items_GXBaseCollection
		{
			get {
				if ( gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items == null )
				{
					gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items = new GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem>( context, "K2BMultiLevelPersistedMenu", "");
				}
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items;
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items_N = false;
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> gxTpr_Items
		{
			get {
				if ( gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items == null )
				{
					gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items = new GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem>( context, "K2BMultiLevelPersistedMenu", "");
				}
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items_N = false;
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items ;
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items_N = false;
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items = value;
				SetDirty("Items");
			}
		}

		public void gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items_SetNull()
		{
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items_N = true;
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items = null;
		}

		public bool gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items_IsNull()
		{
			return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items == null;
		}
		public bool ShouldSerializegxTpr_Items_GXBaseCollection_Json()
		{
			return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items != null && gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items.Count > 0;

		}


		[SoapElement(ElementName="ShowInExtraSmall")]
		[XmlElement(ElementName="ShowInExtraSmall")]
		public bool gxTpr_Showinextrasmall
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinextrasmall; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinextrasmall = value;
				SetDirty("Showinextrasmall");
			}
		}




		[SoapElement(ElementName="ShowInSmall")]
		[XmlElement(ElementName="ShowInSmall")]
		public bool gxTpr_Showinsmall
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinsmall; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinsmall = value;
				SetDirty("Showinsmall");
			}
		}




		[SoapElement(ElementName="ShowInMedium")]
		[XmlElement(ElementName="ShowInMedium")]
		public bool gxTpr_Showinmedium
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinmedium; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinmedium = value;
				SetDirty("Showinmedium");
			}
		}




		[SoapElement(ElementName="ShowInLarge")]
		[XmlElement(ElementName="ShowInLarge")]
		public bool gxTpr_Showinlarge
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinlarge; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinlarge = value;
				SetDirty("Showinlarge");
			}
		}



		[SoapElement(ElementName="Activity")]
		[XmlElement(ElementName="Activity")]
		public GeneXus.Programs.SdtK2BActivity gxTpr_Activity
		{
			get {
				if ( gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity == null )
				{
					gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity = new GeneXus.Programs.SdtK2BActivity(context);
				}
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity = value;
				SetDirty("Activity");
			}
		}
		public void gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity_SetNull()
		{
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity_N = true;
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity = null;
		}

		public bool gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity_IsNull()
		{
			return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity == null;
		}
		public bool ShouldSerializegxTpr_Activity_Json()
		{
			return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity != null;

		}


		[SoapElement(ElementName="GXObject")]
		[XmlElement(ElementName="GXObject")]
		public string gxTpr_Gxobject
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobject; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobject = value;
				SetDirty("Gxobject");
			}
		}




		[SoapElement(ElementName="GXObjectParameters")]
		[XmlElement(ElementName="GXObjectParameters")]
		public string gxTpr_Gxobjectparameters
		{
			get {
				return gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobjectparameters; 
			}
			set {
				gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobjectparameters = value;
				SetDirty("Gxobjectparameters");
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
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Code = "";
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Title = "";
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageurl = "";
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageclass = "";

			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items_N = true;






			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity_N = true;

			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobject = "";
			gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobjectparameters = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Code;
		 

		protected string gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Title;
		 

		protected string gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageurl;
		 

		protected string gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Imageclass;
		 
		protected bool gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items_N;
		protected GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Items = null;  

		protected bool gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinextrasmall;
		 

		protected bool gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinsmall;
		 

		protected bool gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinmedium;
		 

		protected bool gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Showinlarge;
		 

		protected GeneXus.Programs.SdtK2BActivity gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity = null;
		protected bool gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Activity_N;
		 

		protected string gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobject;
		 

		protected string gxTv_SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_Gxobjectparameters;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BMultiLevelPersistedMenuItem", Namespace="test")]
	public class SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_RESTInterface : GxGenericCollectionItem<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_RESTInterface( SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Code", Order=0)]
		public  string gxTpr_Code
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Code);

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="Title", Order=1)]
		public  string gxTpr_Title
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Title);

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="ImageUrl", Order=2)]
		public  string gxTpr_Imageurl
		{
			get { 
				return sdt.gxTpr_Imageurl;

			}
			set { 
				 sdt.gxTpr_Imageurl = value;
			}
		}

		[DataMember(Name="ImageClass", Order=3)]
		public  string gxTpr_Imageclass
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imageclass);

			}
			set { 
				 sdt.gxTpr_Imageclass = value;
			}
		}

		[DataMember(Name="Items", Order=4, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_RESTInterface> gxTpr_Items
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Items_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem_RESTInterface>(sdt.gxTpr_Items);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Items);
			}
		}

		[DataMember(Name="ShowInExtraSmall", Order=5)]
		public bool gxTpr_Showinextrasmall
		{
			get { 
				return sdt.gxTpr_Showinextrasmall;

			}
			set { 
				sdt.gxTpr_Showinextrasmall = value;
			}
		}

		[DataMember(Name="ShowInSmall", Order=6)]
		public bool gxTpr_Showinsmall
		{
			get { 
				return sdt.gxTpr_Showinsmall;

			}
			set { 
				sdt.gxTpr_Showinsmall = value;
			}
		}

		[DataMember(Name="ShowInMedium", Order=7)]
		public bool gxTpr_Showinmedium
		{
			get { 
				return sdt.gxTpr_Showinmedium;

			}
			set { 
				sdt.gxTpr_Showinmedium = value;
			}
		}

		[DataMember(Name="ShowInLarge", Order=8)]
		public bool gxTpr_Showinlarge
		{
			get { 
				return sdt.gxTpr_Showinlarge;

			}
			set { 
				sdt.gxTpr_Showinlarge = value;
			}
		}

		[DataMember(Name="Activity", Order=9, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtK2BActivity_RESTInterface gxTpr_Activity
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Activity_Json())
					return new GeneXus.Programs.SdtK2BActivity_RESTInterface(sdt.gxTpr_Activity);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Activity = value.sdt;
			}
		}

		[DataMember(Name="GXObject", Order=10)]
		public  string gxTpr_Gxobject
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Gxobject);

			}
			set { 
				 sdt.gxTpr_Gxobject = value;
			}
		}

		[DataMember(Name="GXObjectParameters", Order=11)]
		public  string gxTpr_Gxobjectparameters
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Gxobjectparameters);

			}
			set { 
				 sdt.gxTpr_Gxobjectparameters = value;
			}
		}


		#endregion

		public SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem sdt
		{
			get { 
				return (SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem)Sdt;
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
				sdt = new SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem() ;
			}
		}
	}
	#endregion
}