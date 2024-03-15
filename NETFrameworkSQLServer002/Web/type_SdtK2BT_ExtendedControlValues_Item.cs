/*
				   File: type_SdtK2BT_ExtendedControlValues_Item
			Description: K2BT_ExtendedControlValues
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
	[XmlRoot(ElementName="Item")]
	[XmlType(TypeName="Item" , Namespace="test" )]
	[Serializable]
	public class SdtK2BT_ExtendedControlValues_Item : GxUserType
	{
		public SdtK2BT_ExtendedControlValues_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BT_ExtendedControlValues_Item_Value = "";

			gxTv_SdtK2BT_ExtendedControlValues_Item_Description = "";

			gxTv_SdtK2BT_ExtendedControlValues_Item_Imageurl = "";

			gxTv_SdtK2BT_ExtendedControlValues_Item_Detail = "";

			gxTv_SdtK2BT_ExtendedControlValues_Item_Trailingtext = "";

		}

		public SdtK2BT_ExtendedControlValues_Item(IGxContext context)
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
			AddObjectProperty("value", gxTpr_Value, false);


			AddObjectProperty("description", gxTpr_Description, false);


			AddObjectProperty("imageUrl", gxTpr_Imageurl, false);


			AddObjectProperty("detail", gxTpr_Detail, false);


			AddObjectProperty("trailingText", gxTpr_Trailingtext, false);

			if (gxTv_SdtK2BT_ExtendedControlValues_Item_Items != null)
			{
				AddObjectProperty("items", gxTv_SdtK2BT_ExtendedControlValues_Item_Items, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="value")]
		[XmlElement(ElementName="value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtK2BT_ExtendedControlValues_Item_Value; 
			}
			set {
				gxTv_SdtK2BT_ExtendedControlValues_Item_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="description")]
		[XmlElement(ElementName="description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtK2BT_ExtendedControlValues_Item_Description; 
			}
			set {
				gxTv_SdtK2BT_ExtendedControlValues_Item_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="imageUrl")]
		[XmlElement(ElementName="imageUrl")]
		public string gxTpr_Imageurl
		{
			get {
				return gxTv_SdtK2BT_ExtendedControlValues_Item_Imageurl; 
			}
			set {
				gxTv_SdtK2BT_ExtendedControlValues_Item_Imageurl = value;
				SetDirty("Imageurl");
			}
		}




		[SoapElement(ElementName="detail")]
		[XmlElement(ElementName="detail")]
		public string gxTpr_Detail
		{
			get {
				return gxTv_SdtK2BT_ExtendedControlValues_Item_Detail; 
			}
			set {
				gxTv_SdtK2BT_ExtendedControlValues_Item_Detail = value;
				SetDirty("Detail");
			}
		}




		[SoapElement(ElementName="trailingText")]
		[XmlElement(ElementName="trailingText")]
		public string gxTpr_Trailingtext
		{
			get {
				return gxTv_SdtK2BT_ExtendedControlValues_Item_Trailingtext; 
			}
			set {
				gxTv_SdtK2BT_ExtendedControlValues_Item_Trailingtext = value;
				SetDirty("Trailingtext");
			}
		}




		[SoapElement(ElementName="items" )]
		[XmlArray(ElementName="items"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtK2BT_ExtendedControlValues_Item> gxTpr_Items_GXBaseCollection
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedControlValues_Item_Items == null )
				{
					gxTv_SdtK2BT_ExtendedControlValues_Item_Items = new GXBaseCollection<GeneXus.Programs.SdtK2BT_ExtendedControlValues_Item>( context, "K2BT_ExtendedControlValues", "");
				}
				return gxTv_SdtK2BT_ExtendedControlValues_Item_Items;
			}
			set {
				gxTv_SdtK2BT_ExtendedControlValues_Item_Items_N = false;
				gxTv_SdtK2BT_ExtendedControlValues_Item_Items = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtK2BT_ExtendedControlValues_Item> gxTpr_Items
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedControlValues_Item_Items == null )
				{
					gxTv_SdtK2BT_ExtendedControlValues_Item_Items = new GXBaseCollection<GeneXus.Programs.SdtK2BT_ExtendedControlValues_Item>( context, "K2BT_ExtendedControlValues", "");
				}
				gxTv_SdtK2BT_ExtendedControlValues_Item_Items_N = false;
				return gxTv_SdtK2BT_ExtendedControlValues_Item_Items ;
			}
			set {
				gxTv_SdtK2BT_ExtendedControlValues_Item_Items_N = false;
				gxTv_SdtK2BT_ExtendedControlValues_Item_Items = value;
				SetDirty("Items");
			}
		}

		public void gxTv_SdtK2BT_ExtendedControlValues_Item_Items_SetNull()
		{
			gxTv_SdtK2BT_ExtendedControlValues_Item_Items_N = true;
			gxTv_SdtK2BT_ExtendedControlValues_Item_Items = null;
		}

		public bool gxTv_SdtK2BT_ExtendedControlValues_Item_Items_IsNull()
		{
			return gxTv_SdtK2BT_ExtendedControlValues_Item_Items == null;
		}
		public bool ShouldSerializegxTpr_Items_GXBaseCollection_Json()
		{
			return gxTv_SdtK2BT_ExtendedControlValues_Item_Items != null && gxTv_SdtK2BT_ExtendedControlValues_Item_Items.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BT_ExtendedControlValues_Item_Value = "";
			gxTv_SdtK2BT_ExtendedControlValues_Item_Description = "";
			gxTv_SdtK2BT_ExtendedControlValues_Item_Imageurl = "";
			gxTv_SdtK2BT_ExtendedControlValues_Item_Detail = "";
			gxTv_SdtK2BT_ExtendedControlValues_Item_Trailingtext = "";

			gxTv_SdtK2BT_ExtendedControlValues_Item_Items_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BT_ExtendedControlValues_Item_Value;
		 

		protected string gxTv_SdtK2BT_ExtendedControlValues_Item_Description;
		 

		protected string gxTv_SdtK2BT_ExtendedControlValues_Item_Imageurl;
		 

		protected string gxTv_SdtK2BT_ExtendedControlValues_Item_Detail;
		 

		protected string gxTv_SdtK2BT_ExtendedControlValues_Item_Trailingtext;
		 
		protected bool gxTv_SdtK2BT_ExtendedControlValues_Item_Items_N;
		protected GXBaseCollection<GeneXus.Programs.SdtK2BT_ExtendedControlValues_Item> gxTv_SdtK2BT_ExtendedControlValues_Item_Items = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Item", Namespace="test")]
	public class SdtK2BT_ExtendedControlValues_Item_RESTInterface : GxGenericCollectionItem<SdtK2BT_ExtendedControlValues_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BT_ExtendedControlValues_Item_RESTInterface( ) : base()
		{	
		}

		public SdtK2BT_ExtendedControlValues_Item_RESTInterface( SdtK2BT_ExtendedControlValues_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="value", Order=0)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value);

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="description", Order=1)]
		public  string gxTpr_Description
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Description);

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="imageUrl", Order=2)]
		public  string gxTpr_Imageurl
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imageurl);

			}
			set { 
				 sdt.gxTpr_Imageurl = value;
			}
		}

		[DataMember(Name="detail", Order=3)]
		public  string gxTpr_Detail
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Detail);

			}
			set { 
				 sdt.gxTpr_Detail = value;
			}
		}

		[DataMember(Name="trailingText", Order=4)]
		public  string gxTpr_Trailingtext
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Trailingtext);

			}
			set { 
				 sdt.gxTpr_Trailingtext = value;
			}
		}

		[DataMember(Name="items", Order=5, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtK2BT_ExtendedControlValues_Item_RESTInterface> gxTpr_Items
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Items_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtK2BT_ExtendedControlValues_Item_RESTInterface>(sdt.gxTpr_Items);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Items);
			}
		}


		#endregion

		public SdtK2BT_ExtendedControlValues_Item sdt
		{
			get { 
				return (SdtK2BT_ExtendedControlValues_Item)Sdt;
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
				sdt = new SdtK2BT_ExtendedControlValues_Item() ;
			}
		}
	}
	#endregion
}